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
                conn.CreateTable<Deliveries>();
                conn.Insert(newOrder);
            }

            Data be95, be98, on, lpg;

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                be95 = conn.Table<Data>().Where(f => f.FuelName == "be95").FirstOrDefault();
                be98 = conn.Table<Data>().Where(f => f.FuelName == "be98").FirstOrDefault();
                on = conn.Table<Data>().Where(f => f.FuelName == "ON").FirstOrDefault();
                lpg = conn.Table<Data>().Where(f => f.FuelName == "LPG").FirstOrDefault();
            }

            be95.Litres = be95.Litres + int.Parse(be95textBox.Text);
            be98.Litres = be98.Litres + int.Parse(be98textBox.Text);
            on.Litres = on.Litres + int.Parse(ontextBox.Text);
            lpg.Litres = lpg.Litres + int.Parse(lpgtextBox.Text);


            string command = $"update  Data set litres= {be95.Litres} where fuelname='be95'";
            string command1 = $"update  Data set litres= {be98.Litres} where fuelname='be98'";
            string command2 = $"update  Data set litres= {on.Litres} where fuelname='ON'";
            string command3 = $"update  Data set litres= {lpg.Litres} where fuelname='LPG'";

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                SQLiteCommand cm = new SQLiteCommand(conn);
                cm.CommandText = command;
                cm.ExecuteNonQuery();
            }
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                SQLiteCommand cm = new SQLiteCommand(conn);
                cm.CommandText = command1;
                cm.ExecuteNonQuery();
            }
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                SQLiteCommand cm = new SQLiteCommand(conn);
                cm.CommandText = command2;
                cm.ExecuteNonQuery();
            }
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                SQLiteCommand cm = new SQLiteCommand(conn);
                cm.CommandText = command3;
                cm.ExecuteNonQuery();
            }

            MessageBox.Show("Zamówiono");

            lpgtextBox.Text = "0";
            ontextBox.Text = "0";
            be95textBox.Text = "0";
            be98textBox.Text = "0";
        }
    }
}
