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
    /// Interaction logic for My_Data_Window.xaml
    /// </summary>
    public partial class My_Data_Window : Window
    {
        Konto account;
        private Konto _loggedInAccount = new Konto();
        public My_Data_Window(Konto account)
        {
            InitializeComponent();
            _loggedInAccount = account;
            readKontoDatabase();
        }
        public My_Data_Window(Konto account, bool modify)
        {
            InitializeComponent();
            _loggedInAccount = account;
            readKontoDatabase();
            mod_button.Visibility = Visibility.Visible;
        }
        public void readKontoDatabase()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Konto>();
                account = (conn.Table<Konto>().FirstOrDefault(a => a.Login == _loggedInAccount.Login));

                Company_name.Content = account.Nazwa_firmy;
                Name.Content = account.Imie;
                Surname.Content = account.Nazwisko;
                PESEL.Content = account.Pesel;
                REGON.Content = account.Regon;
                NIP.Content = account.Nip;
                Street.Content = account.Ulica;
                City.Content = account.Miasto;
                Number.Content = account.Numer;
                ZIP_code.Content = account.Kod_pocztowy;
                E_mail.Content = account.Email;
            }      
        }
        //otwiera okno do modyfikacji danych
        private void Mod_button_Click(object sender, RoutedEventArgs e)
        {
            // Modify_Window modify_window = new Modify_Window(_loggedInAccount); 
            this.Close();
           // modify_window.ShowDialog();
        }
        //przycisk powrotu do strony głównej
        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(_loggedInAccount);
            mainWindow.Show();
            this.Close();
        }
    }
}
