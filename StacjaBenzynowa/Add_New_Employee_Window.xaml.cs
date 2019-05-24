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
    /// Interaction logic for Add_New_Employee_Window.xaml
    /// </summary>
    public partial class Add_New_Employee_Window : Window
    {
        public Add_New_Employee_Window()
        {
            InitializeComponent();
        }

        private Konto _loggedInAccount = new Konto();
        public Add_New_Employee_Window(Konto account)
        {
            InitializeComponent();
            _loggedInAccount = account;
        }

        private void A2_button_Click(object sender, RoutedEventArgs e)
        {
            Konto newEmployee = new Konto()
            {
                Role = Role.Text,
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
                Haslo = Haslo.Text
            };
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Konto>();
                conn.Insert(newEmployee);
            }

            Employess_Window emplWindow = new Employess_Window(_loggedInAccount);
            emplWindow.Show();
            this.Close();
        }

        private void Back_button_Click(object sender, RoutedEventArgs e)
        {

            Employess_Window emplWindow = new Employess_Window(_loggedInAccount);
            emplWindow.Show();
            this.Close();

        }
    }
}
