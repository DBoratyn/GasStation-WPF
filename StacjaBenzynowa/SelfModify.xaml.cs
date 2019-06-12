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
using StacjaBenzynowa.Models;

namespace StacjaBenzynowa
{
    /// <summary>
    /// Interaction logic for SelfModify.xaml
    /// </summary>
    public partial class SelfModify : Window
    {
        private Konto _loggedInAccount = new Konto();
        public SelfModify(Konto account)
        {
            InitializeComponent();
            _loggedInAccount = account;

            Company_name.Text = _loggedInAccount.Nazwa_firmy;
            Name.Text = _loggedInAccount.Imie;
            Surname.Text = _loggedInAccount.Nazwisko;
            PESEL.Text = _loggedInAccount.Pesel;
            REGON.Text = _loggedInAccount.Regon;
            NIP.Text = _loggedInAccount.Nip;
            Street.Text = _loggedInAccount.Ulica;
            Number.Text = _loggedInAccount.Numer;
            City.Text = _loggedInAccount.Miasto;
            ZIP_code.Text = _loggedInAccount.Kod_pocztowy;
            
        }

        private void Mod_button_Click(object sender, RoutedEventArgs e)
        {
            Konto newInfo = new Konto()
            {
                Id = _loggedInAccount.Id,
                Nazwa_firmy = Company_name.Text,
                Imie = Name.Text,
                Nazwisko = Surname.Text,
                Pesel = PESEL.Text,
                Regon = REGON.Text,
                Nip = NIP.Text,
                Ulica = Street.Text,
                Numer = Number.Text,
                Miasto = City.Text,
                Kod_pocztowy = ZIP_code.Text,
                Email = _loggedInAccount.Email,
                Login = _loggedInAccount.Login,
                Haslo = _loggedInAccount.Haslo,
                Role = _loggedInAccount.Role,
                Points = _loggedInAccount.Points
            };

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Konto>();
                conn.InsertOrReplace(newInfo);
            }
            MessageBox.Show("Account updated.");
            MainWindow mw = new MainWindow(_loggedInAccount);
            mw.Show();
            this.Close();
        }

        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow(_loggedInAccount);
            mw.Show();
            this.Close();

        }
    }
}
