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
    /// Logika interakcji dla klasy Contact_Data_Window.xaml
    /// </summary>
    public partial class Contact_Data_Window : Window
    {
        private Konto _loggedInAccount = new Konto();
        public Contact_Data_Window()
        {
            InitializeComponent();
        }
        public Contact_Data_Window(Konto account)
        {
            _loggedInAccount = account;
            InitializeComponent();
            Informacje data = new Informacje();

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                data = conn.Table<Informacje>().FirstOrDefault();
            }
            if (data != null)
            {
                Owner.Text = data.Wlasciciel;
                Address.Text = data.Adres;
                PhoneNumber.Text = data.Telefon;
                Fax.Text = data.Fax;
                Cashiers.Text = data.Kasjerzy;
                Wash_Stuff.Text = data.Myjnia;
                Monitoring_Stuff.Text = data.Monitoring;
                LPG_Stuff.Text = data.ObslugaLPG;
            }
        }
        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(_loggedInAccount);
            this.Close();
            mainWindow.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Informacje newInfo = new Informacje()
            {
                Id = 1,
                Wlasciciel = Owner.Text,
                Adres = Address.Text,
                Telefon = PhoneNumber.Text,
                Fax = Fax.Text,
                Kasjerzy = Cashiers.Text,
                Myjnia = Wash_Stuff.Text,
                Monitoring = Monitoring_Stuff.Text,
                ObslugaLPG = LPG_Stuff.Text
            };

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Informacje>();
                conn.InsertOrReplace(newInfo);
            }

            MessageBox.Show("Updated.");
            MainWindow mainWindow = new MainWindow(_loggedInAccount);
            this.Close();
            mainWindow.Show();

        }
    }
}
