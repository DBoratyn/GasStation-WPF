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
    /// Interaction logic for Add_New_Customer_Window.xaml
    /// </summary>
    public partial class Add_New_Customer_Window : Window
    {
        public Add_New_Customer_Window()
        {
            InitializeComponent();
        }

        private Konto _loggedInAccount = new Konto();
        public Add_New_Customer_Window(Konto account)
        {
            InitializeComponent();
            _loggedInAccount = account;
        }

        public void A1_button_Click_TEST(Konto newCustomer)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Konto>();
                conn.Insert(newCustomer);
            }
        }

        private void A1_button_Click (object sender, RoutedEventArgs e)
        {
            Konto newCustomer = new Konto()
            {
                Role = "Customer",
                Nazwa_firmy = Company_name.Text,
                Imie = Name.Text,
                Nazwisko = Surname.Text,
                Pesel = PESEL.Text,
                Regon = REGON.Text,
                Nip = NIP.Text,
                Ulica = Street.Text,
                Numer = Number.Text,
                Kod_pocztowy = ZIP_code.Text,
                Miasto = City.Text,
                Email = E_mail.Text,
                Login = Login.Text,
                Haslo = Haslo.Text,
                Points = 0
            };
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Konto>();
                conn.Insert(newCustomer);
            }

            Customers_Window custWindow = new Customers_Window(_loggedInAccount);
            custWindow.Show();

            this.Close();
        }

        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            Customers_Window my_data_window = new Customers_Window(_loggedInAccount);
            this.Close();
            my_data_window.Show();
        }
    }
}
