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
    /// Logika interakcji dla klasy Modify_prices.xaml
    /// </summary>
    public partial class Modify_prices : Window
    {
        Cennik prices;

        private Konto _loggedInAccount = new Konto();
        public Modify_prices()
        {
            InitializeComponent();
        }

       public Modify_prices(Konto account)
        {
            _loggedInAccount = account;
            InitializeComponent();
            using (SQLiteConnection conn2 = new SQLiteConnection(App.databasePath))
            {
                conn2.CreateTable<Cennik>();
                prices = (conn2.Table<Cennik>().FirstOrDefault());

                E95.Text = prices.Benzyna_E95.ToString();
                E98.Text = prices.Benzyna_E98.ToString();
                ON.Text = prices.Olej_napedowy_ON.ToString();
                LPG.Text = prices.LPG.ToString();
                mstand.Text = prices.Mycie_standardowe.ToString();
                mwosk.Text = prices.Mycie_z_woskiem.ToString();
            }
        }

        private void UpdateData(object sender, RoutedEventArgs e)
        {

            Cennik updatedPrices = new Cennik();
            updatedPrices.Benzyna_E95 = double.Parse(E95.Text);
            updatedPrices.Benzyna_E98 = double.Parse(E98.Text);
            updatedPrices.Olej_napedowy_ON = double.Parse(ON.Text);
            updatedPrices.LPG = double.Parse(LPG.Text);
            updatedPrices.Mycie_standardowe = double.Parse(mstand.Text);
            updatedPrices.Mycie_z_woskiem = double.Parse(mwosk.Text);

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Cennik>();
                conn.InsertOrReplace(updatedPrices);
            }

            MainWindow mainwindow = new MainWindow(_loggedInAccount);
            this.Close();
            mainwindow.Show();
        }

        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow(_loggedInAccount);
            this.Close();
            mainwindow.Show();
        }
    }
}
