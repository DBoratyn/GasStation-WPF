using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SQLite;
using StacjaBenzynowa.Models;

namespace StacjaBenzynowa
{
    /// <summary>
    /// Logika interakcji dla klasy Tankowanie_Window.xaml
    /// </summary>
    public partial class Tankowanie_Window : Window
    {
        private Konto _loggedInAccount = new Konto();
        Cennik prices;

        double totalPrice = 0;

        private double be95, be98, on, lpg, mycie_stand, mycie_wosk;

        public List<Konto> customerList { get; set; }
        private string selectedEmail;

        private void SaveInvoice(object sender, RoutedEventArgs e)
        {
            Invoices newInvoice = new Invoices()
            {
                email = selectedEmail,
                Nazwa_firmy = this.FirmaTxtBox.Text,
                Imie = this.ImieTxtBox.Text,
                Nazwisko = this.NazwiskoTxtBox.Text,
                Ulica = this.UlicaTxtBox.Text,
                Numer = this.NumberTxtBox.Text,
                Miasto = this.MiastoTxtBox.Text,
                Kod_pocztowy = this.KodTxtBox.Text,
                BenzynaE95 = double.Parse(this.Be95txtBox.Text),
                BenzynaE98 = double.Parse(this.Be95txtBox.Text),
                OlejNapowy = double.Parse(this.OlejtxtBox.Text),
                LPG = double.Parse(this.LPGTxtBox.Text),
                TotalPrice = totalPrice,
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Invoices>();
                conn.Insert(newInvoice);
            }

            this.FirmaTxtBox.Text = "";
            this.ImieTxtBox.Text = "";
            this.NazwiskoTxtBox.Text = "";
            this.UlicaTxtBox.Text = "";
            this.NumberTxtBox.Text = "";
            this.MiastoTxtBox.Text = "";
            this.KodTxtBox.Text = "";
            this.Be95txtBox.Text = "";
            this.Be98txtBox.Text = "";
            this.OlejtxtBox.Text = "";
            this.LPGTxtBox.Text = "";
            CustomersComboBox.SelectedItem = customerList[0];
            MessageBox.Show("Invoice added.");

            /*
            MainWindow mainwindow = new MainWindow(_loggedInAccount);
            mainwindow.Show();
            this.Close();
            */

        }

        // public Konto SelectedCustomer { get; set; }

        private void UpdateInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Konto SelectedCustomer = (Konto)CustomersComboBox.SelectedItem;
            this.FirmaTxtBox.Text = SelectedCustomer.Nazwa_firmy;
            this.ImieTxtBox.Text = SelectedCustomer.Imie;
            this.NazwiskoTxtBox.Text = SelectedCustomer.Nazwisko;
            this.UlicaTxtBox.Text = SelectedCustomer.Ulica;
            this.NumberTxtBox.Text = SelectedCustomer.Numer;
            this.MiastoTxtBox.Text = SelectedCustomer.Miasto;
            this.KodTxtBox.Text = SelectedCustomer.Kod_pocztowy;
            selectedEmail = SelectedCustomer.Email;
        }

        public Tankowanie_Window()
        {
            InitializeComponent();
        }
        public Tankowanie_Window(Konto account)
        {
            _loggedInAccount = account;
            InitializeComponent();

            using (SQLiteConnection conn2 = new SQLiteConnection(App.databasePath))
            {
                conn2.CreateTable<Cennik>();
                prices = (conn2.Table<Cennik>().FirstOrDefault());

                be95 = prices.Benzyna_E95;
                be98 = prices.Benzyna_E98;
                on = prices.Olej_napedowy_ON;
                lpg = prices.LPG;
                mycie_stand = prices.Mycie_standardowe;
                mycie_wosk = prices.Mycie_z_woskiem;                
            }

            using (SQLiteConnection conn3 = new SQLiteConnection(App.databasePath))
            {
                customerList = conn3.Table<Konto>().OrderBy(c => c.Email).Where(c => c.Role.ToUpper() == "CUSTOMER").ToList();
            }
            if (customerList != null)
            {
                this.CustomersComboBox.ItemsSource = customerList;
            }


        }

        private void getTotal (object sender, RoutedEventArgs e)
        {
            totalPrice = 0;
            if (string.IsNullOrEmpty(this.Be95txtBox.Text))
            {
                Be95txtBox.Text = "0";
            } else
            {
                totalPrice += (be95 * double.Parse(Be95txtBox.Text));
            }

            if (string.IsNullOrEmpty(this.Be98txtBox.Text))
            {
                Be98txtBox.Text = "0";
            } else
            {
                totalPrice += (be98 * double.Parse(Be98txtBox.Text));
            }

            if (string.IsNullOrEmpty(this.OlejtxtBox.Text))
            {
                OlejtxtBox.Text = "0";
            } else
            {
                totalPrice += (on * double.Parse(OlejtxtBox.Text));
            }

            if (string.IsNullOrEmpty(this.LPGTxtBox.Text))
            {
                LPGTxtBox.Text = "0";
            } else
            {
                totalPrice += (lpg * double.Parse(LPGTxtBox.Text));
            }

            totalPrice = Math.Truncate(totalPrice * 100) / 100;

            this.TotalPriceLbl.Content = totalPrice;
        }

        private void Back_button_Click(object sender, RoutedEventArgs e)
        {


            MainWindow mainwindow = new MainWindow(_loggedInAccount);
            this.Close();
            mainwindow.Show();
        }
    }
}
