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
    }
}
