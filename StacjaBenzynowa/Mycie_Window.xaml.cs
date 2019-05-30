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
    /// Logika interakcji dla klasy Mycie_Window.xaml
    /// </summary>
    public partial class Mycie_Window : Window
    {

        private Konto _loggedInAccount = new Konto();
        public List<Konto> customerList { get; set; }
        private string selectedEmail;
        string couponOwner;
        double totalPrice = 0;
        private double mycie_stand, mycie_wosk;
        Cennik prices;
        Coupon SelectedCoupon = new Coupon();

        public Mycie_Window()
        {
            InitializeComponent();
        }
        public Mycie_Window(Konto account)
        {
            _loggedInAccount = account;
            InitializeComponent();

            using (SQLiteConnection conn2 = new SQLiteConnection(App.databasePath))
            {
                conn2.CreateTable<Cennik>();
                prices = (conn2.Table<Cennik>().FirstOrDefault());
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

            StandardowetxtBox.Text = "0";
            woskiemTxtBx.Text = "0";
        }

        private void Coupons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedCoupon = (Coupon)CouponList.SelectedItem;
        }

        private void getTotal(object sender, RoutedEventArgs e)
        {
            totalPrice = 0;
            if (string.IsNullOrEmpty(this.StandardowetxtBox.Text))
            {
                StandardowetxtBox.Text = "0";
            }
            else
            {
                totalPrice += (mycie_stand * double.Parse(StandardowetxtBox.Text));
            }

            if (string.IsNullOrEmpty(this.woskiemTxtBx.Text))
            {
                woskiemTxtBx.Text = "0";
            }
            else
            {
                totalPrice += (mycie_wosk * double.Parse(woskiemTxtBx.Text));
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
                Standardowe = double.Parse(this.StandardowetxtBox.Text),
                Zwoskiem = double.Parse(this.woskiemTxtBx.Text),
                TotalPrice = totalPrice,
            };

            if (SelectedCoupon != null)
            {
                if (SelectedCoupon.Name == "Mycie Standardowe")
                {
                    if (int.Parse(StandardowetxtBox.Text) > 0)
                    {
                        newInvoice.TotalPrice -= mycie_stand;
                        if (newInvoice.TotalPrice < 0)
                        {
                            newInvoice.TotalPrice = 0;
                        }

                        string command = $"delete from Coupon where id in ( select id FROM Coupon where name='Mycie Standardowe' AND  Owner='{couponOwner}'  Limit 1 )";
                        using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
                        {
                            SQLiteCommand cm = new SQLiteCommand(connection);
                            cm.CommandText = command;
                            cm.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    if (int.Parse(woskiemTxtBx.Text) > 0)
                    {
                        newInvoice.TotalPrice -= mycie_wosk;
                        if (newInvoice.TotalPrice < 0)
                        {
                            newInvoice.TotalPrice = 0;
                        }

                        string command = $"delete from Coupon where id in ( select id FROM Coupon where name='Mycie Woskiem' AND  Owner='{couponOwner}'  Limit 1 )";
                        using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
                        {
                            SQLiteCommand cm = new SQLiteCommand(connection);
                            cm.CommandText = command;
                            cm.ExecuteNonQuery();
                        }
                    }
                }
            }

            if (newInvoice.TotalPrice != 0)
            {
                newInvoice.TotalPrice = Math.Truncate(newInvoice.TotalPrice * 100) / 100;
            }

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
            this.StandardowetxtBox.Text = "";
            this.woskiemTxtBx.Text = "";
            CustomersComboBox.SelectedItem = customerList[0];

            double standard_point, woskiem_point;

            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                standard_point = connection.Table<ProgramLojalnościowy>().Select(s => s.mycie_standardowe).FirstOrDefault();
                woskiem_point = connection.Table<ProgramLojalnościowy>().Select(s => s.mycie_z_woskiem).FirstOrDefault();
            }

            Konto AccountToUpdate = new Konto();
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                AccountToUpdate = connection.Table<Konto>().FirstOrDefault(a => a.Email == selectedEmail);
            }

            AccountToUpdate.Points += ((int)standard_point * (int)newInvoice.Standardowe) + ((int)woskiem_point * (int)newInvoice.Zwoskiem);

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Konto>();
                conn.InsertOrReplace(AccountToUpdate);
            }

            MessageBox.Show("Invoice added.");
            MainWindow mainwindow = new MainWindow(_loggedInAccount);
            mainwindow.Show();
            this.Close();

        }

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

            couponOwner = SelectedCustomer.Email;

            List<Coupon> coupons = new List<Coupon>();
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                coupons = connection.Table<Coupon>().Where(n => n.Owner == SelectedCustomer.Email && (n.Name.Contains("Mycie"))).ToList();
            }

            if (coupons != null)
            {
                this.CouponList.ItemsSource = coupons;
            }

        }
    }
}
