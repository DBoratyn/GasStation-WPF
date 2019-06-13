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
    /// Logika interakcji dla klasy Modify_Window.xaml
    /// </summary>
    public partial class Modify_Window : Window
    {
        private Konto _loggedInAccount = new Konto();
        List<Konto> customerList;
        string _origin = "";
        Konto updatedAccount;
        Konto AccountToUpdate = new Konto();

        public Modify_Window()
        {
            InitializeComponent();
        }
        public Modify_Window(Konto account, Konto accountToUpdate)
        {
            updatedAccount = accountToUpdate;
            _loggedInAccount = account;
            InitializeComponent();
        }

        public Modify_Window(Konto account, Konto accountToUpdate, string origin)
        {
            AccountToUpdate = accountToUpdate;
            _origin = origin;
            _loggedInAccount = account;
            InitializeComponent();
        }
        private void loadData(object sender, RoutedEventArgs e)
        {
            Company_name.Text = AccountToUpdate.Nazwa_firmy;
            Name.Text = AccountToUpdate.Imie;
            Surname.Text = AccountToUpdate.Nazwisko;
            PESEL.Text = AccountToUpdate.Pesel;
            Role.Text = AccountToUpdate.Role;
            REGON.Text = AccountToUpdate.Regon;
            Street.Text = AccountToUpdate.Ulica;
            NIP.Text = AccountToUpdate.Nip;
            ZIP_code.Text = AccountToUpdate.Kod_pocztowy;
            City.Text = AccountToUpdate.Miasto;
            Number.Text = AccountToUpdate.Numer;
            E_mail.Text = AccountToUpdate.Email;
            Login.Content = AccountToUpdate.Login;
        }

        private void UpdateData(object sender, RoutedEventArgs e)
        {
            updatedAccount = new Konto();
            updatedAccount.Haslo = this.AccountToUpdate.Haslo;
            updatedAccount.Id = this.AccountToUpdate.Id;
            updatedAccount.Role = Role.Text;
            updatedAccount.Nazwa_firmy = Company_name.Text;
            updatedAccount.Imie = Name.Text;
            updatedAccount.Nazwisko = Surname.Text;
            updatedAccount.Pesel = PESEL.Text;
            updatedAccount.Regon = REGON.Text;
            updatedAccount.Nip = NIP.Text;
            updatedAccount.Ulica = Street.Text;
            updatedAccount.Numer = Number.Text;
            updatedAccount.Miasto = City.Text;
            updatedAccount.Email = E_mail.Text;
            updatedAccount.Login = this.AccountToUpdate.Login;

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Konto>();
                conn.Update(updatedAccount);
            }

            if (_origin == "CUSTOMER")
            {
                Customers_Window emplWindow = new Customers_Window(_loggedInAccount);
                this.Close();
                emplWindow.Show();
            } else
            {
                Employess_Window emplWindow = new Employess_Window(_loggedInAccount);
                this.Close();
                emplWindow.Show();
            }            
        }
        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            if(_origin == "CUSTOMER")
            {
                Customers_Window my_data_window = new Customers_Window(_loggedInAccount);
                this.Close();
                my_data_window.Show();
            }
            else
            {
                Employess_Window emplWindow = new Employess_Window(_loggedInAccount);
                this.Close();
                emplWindow.Show();
            }

        }

        private void Deletebtn_click(object sender, RoutedEventArgs e)
        {
            string command = $"delete FROM KONTO where id= '{AccountToUpdate.Id}'";

            if ( _loggedInAccount.Role == "ADMIN")
            {
                using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
                {
                    SQLiteCommand cm = new SQLiteCommand(connection);
                    cm.CommandText = command;
                    cm.ExecuteNonQuery();
                }
            } else if (_origin == "CUSTOMER")
            {
                using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
                {
                    SQLiteCommand cm = new SQLiteCommand(connection);
                    cm.CommandText = command;
                    cm.ExecuteNonQuery();
                }
            }     

            if (_origin == "CUSTOMER")
            {
                Customers_Window my_data_window = new Customers_Window(_loggedInAccount);
                this.Close();
                my_data_window.Show();
            }
            else
            {
                Employess_Window emplWindow = new Employess_Window(_loggedInAccount);
                this.Close();
                emplWindow.Show();
            }

        }

        private void Role_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_loggedInAccount.Role != "ADMIN")
            {
                if (_origin == "CUSTOMER")
                {
                    this.Role.Text = "CUSTOMER";
                }
                else
                {
                    this.Role.Text = AccountToUpdate.Role;
                }
            }
            
        }
    }
}
