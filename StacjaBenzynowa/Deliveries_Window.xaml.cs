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
    /// Interaction logic for Deliveries_Window.xaml
    /// </summary>
    public partial class Deliveries_Window : Window
    {
        Konto account;
        private Konto _loggedInAccount = new Konto();
        public Deliveries_Window()
        {
            InitializeComponent();
        }
        public Deliveries_Window(Konto account)
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
