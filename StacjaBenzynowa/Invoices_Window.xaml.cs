using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for Invoices_Window.xaml
    /// </summary>
    public partial class Invoices_Window : Window
    {

        private Konto _loggedInAccount = new Konto();
        List<Invoices> invoiceList;

        public Invoices_Window()
        {
            InitializeComponent();
            displayInvoices();
        }
        public Invoices_Window(Konto account)
        {
            _loggedInAccount = account;
            InitializeComponent();
            displayInvoices();
        }

        private void displayInvoices()
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                invoiceList = connection.Table<Invoices>().OrderBy(i => i.Id).ToList();
            }
            if(invoiceList != null)
            {
                invoiceListView.ItemsSource = invoiceList;
            }
        }


        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow(_loggedInAccount);
            this.Close();
            mainwindow.Show();
        }

        private void InvoiceListView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Invoices selectedInvoice = (Invoices)invoiceListView.SelectedItem;

            string dt = DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss") + ".txt";

            StreamWriter File = new StreamWriter(@"..\..\Invoices\Faktura " + selectedInvoice.email.ToString() + " " + dt, true);

            File.WriteLine("Klinet: " + selectedInvoice.email.ToString());
            if (selectedInvoice.CouponUsed != null)
            {
                File.WriteLine("Kupon: " + selectedInvoice.CouponUsed);
            }

            File.WriteLine("_______________________________");
            File.WriteLine("Firma: " + selectedInvoice.Nazwa_firmy);
            File.WriteLine("Imie: " + selectedInvoice.Imie);
            File.WriteLine("Nazwisko: " + selectedInvoice.Nazwisko);
            File.WriteLine("Ulica: " + selectedInvoice.Ulica);
            File.WriteLine("Numer: " + selectedInvoice.Numer);
            File.WriteLine("Miasto: " + selectedInvoice.Miasto);
            File.WriteLine("Kod Pocztowy: " + selectedInvoice.Kod_pocztowy);

            File.WriteLine("_______________________________");
            File.WriteLine("Benzyna E95: " + selectedInvoice.BenzynaE95);
            File.WriteLine("Benzyna E98: " + selectedInvoice.BenzynaE98);
            File.WriteLine("Olej Napedowy: " + selectedInvoice.OlejNapowy);
            File.WriteLine("LPG: " + selectedInvoice.LPG);
            File.WriteLine("");
            File.WriteLine("Kwota calkowita: " + selectedInvoice.TotalPrice);

            File.Close();
            MessageBox.Show("Faktura utworzona.");
        }
    }
}
