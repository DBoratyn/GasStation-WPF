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
    /// Logika interakcji dla klasy Mycie_Window.xaml
    /// </summary>
    public partial class Mycie_Window : Window
    {
        Konto account;
        private Konto _loggedInAccount = new Konto();
        public Mycie_Window()
        {
            InitializeComponent();
        }
        public Mycie_Window(Konto account)
        {
            _loggedInAccount = account;
            InitializeComponent();
        }
        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow(_loggedInAccount);
            this.Close();
            mainwindow.Show();
        }
    }
}
