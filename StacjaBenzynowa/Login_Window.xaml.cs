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
using SQLite;

namespace StacjaBenzynowa
{
    /// <summary>
    /// Interaction logic for Login_Window.xaml
    /// </summary>
    public partial class Login_Window : Window
    {
        public Login_Window()
        {
            InitializeComponent();
        }
        private void zaloguj_button(object sender, RoutedEventArgs e)
        {
            Konto user;
            //string login = loginbox.Text;
            //string haslo = passwordbox.Text;

            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Konto>();
                user = (connection.Table<Konto>().FirstOrDefault(u => u.Login == loginbox.Text && u.Haslo == passwordbox.Text));
            }
            if (user != null)
            {
                MainWindow mainWindow = new MainWindow(user);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                this.ErrorLbl.Visibility = Visibility.Visible;
            }
        }

     private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }
    }
}
