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
    /// Interaction logic for Customers_Window.xaml
    /// </summary>
    public partial class Customers_Window : Window
    {
        List<Konto> customerList;
        public Customers_Window()
        {
            InitializeComponent();
        }
        private Konto _loggedInAccount = new Konto();
        public Customers_Window(Konto account)
        {
            _loggedInAccount = account;
            InitializeComponent();
        }
        private void displayCustomers(object sender, RoutedEventArgs e)
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                customerList = connection.Table<Konto>().OrderBy(t => t.Email).Where(t => t.Role.ToUpper() == "CUSTOMER").ToList();
            }
            if (customerList !=null)
            {
                customerListView.ItemsSource = customerList;
            }
        }
        private void ANC_button_Click(object sender, RoutedEventArgs e)
        {
            Add_New_Customer_Window addCustomer = new Add_New_Customer_Window(_loggedInAccount);
            this.Close();
            addCustomer.ShowDialog();
        }

        private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
                Konto selectedAccount = (Konto)customerListView.SelectedItem;

                Modify_Window modify_window = new Modify_Window(_loggedInAccount, selectedAccount, "CUSTOMER");
                this.Close();
                modify_window.ShowDialog();

            
        }

        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(_loggedInAccount);
            this.Close();
            mainWindow.Show();
        }
    }
}
