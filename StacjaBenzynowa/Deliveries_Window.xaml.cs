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

            be95textBox.Text = "0";
            be98textBox.Text = "0";
            ontextBox.Text = "0";
            lpgtextBox.Text = "0";

        }
        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow(_loggedInAccount);
            this.Close();
            mainwindow.Show();
        }

        private void Be95textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(be95textBox.Text))
            {
                be95textBox.Text = "0";            }
        }

        private void Be98textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(be98textBox.Text))
            {
                be98textBox.Text = "0";
            }
        }

        private void OntextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(ontextBox.Text))
            {
                ontextBox.Text = "0";
            }
        }

        private void LpgtextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(lpgtextBox.Text))
            {
                lpgtextBox.Text = "0";
            }
        }

        private void Order_button_Click(object sender, RoutedEventArgs e)
        {
            Deliveries newOrder = new Deliveries()
            {
                Benzyna_E95 = double.Parse(be95textBox.Text),
                Benzyna_E98 = double.Parse(be95textBox.Text),
                Olej_napedowy_ON = double.Parse(be95textBox.Text),
                LPG = double.Parse(be95textBox.Text)
            };
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Konto>();
                conn.Insert(newOrder);
            }
            MessageBox.Show("Delivery Created");

            lpgtextBox.Text = "0";
            ontextBox.Text = "0";
            be95textBox.Text = "0";
            be98textBox.Text = "0";
        }
    }
}
