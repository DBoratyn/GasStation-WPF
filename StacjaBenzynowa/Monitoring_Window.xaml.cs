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
using System.Windows.Threading;
using SQLite;
using StacjaBenzynowa.Models;

namespace StacjaBenzynowa
{
    /// <summary>
    /// Interaction logic for Monitoring_Window.xaml
    /// </summary>
    public partial class Monitoring_Window : Window
    {
        private const int MinValue = 90;
        private const int MaxValue = 210;
        private Konto _loggedInAccount = new Konto();
        private Data be95 = new Data();
        private Data be98 = new Data();
        private Data ON = new Data();
        private Data LPG = new Data();

        Random rnd = new Random();
        int rng;
        
        public Monitoring_Window()
        {
            InitializeComponent();
        }
        public Monitoring_Window(Konto account)
        {
            _loggedInAccount = account;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                be95 = connection.Table<Data>().FirstOrDefault(t => t.Id == 1);
                be98 = connection.Table<Data>().FirstOrDefault(t => t.Id == 2);
                ON = connection.Table<Data>().FirstOrDefault(t => t.Id == 3);
                LPG = connection.Table<Data>().FirstOrDefault(t => t.Id == 4);

                e95_l.Text = be95.Litres.ToString();
                lpg_l.Text = LPG.Litres.ToString();
                e98_l.Text = be98.Litres.ToString();
                on_l.Text = ON.Litres.ToString();

                e95_temp.Text = be95.Temperature.ToString();
                e98_temp.Text = be98.Temperature.ToString();
                on_temp.Text = ON.Temperature.ToString();
                lpg_temp.Text = LPG.Temperature.ToString();

                e95_p.Text = be95.Pressure.ToString();
                e98_p.Text = be98.Pressure.ToString();
                on_p.Text = ON.Pressure.ToString();
                lpg_p.Text = LPG.Pressure.ToString();

            }
        }

        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow(_loggedInAccount);
            this.Close();
            mainwindow.Show();
        }

        private void Camera1_Click(object sender, RoutedEventArgs e)
        {
            Monitor1_WIndow mw = new Monitor1_WIndow();
            mw.Show();
        }

        private void Camera2_Click(object sender, RoutedEventArgs e)
        {
            Monitor2_Window mw = new Monitor2_Window();
            mw.Show();
        }

        private void Camera3_Click(object sender, RoutedEventArgs e)
        {
            Monitor3_Window mw = new Monitor3_Window();
            mw.Show();
        }

        private void Camera4_Click(object sender, RoutedEventArgs e)
        {
            Monitor4_Window mw = new Monitor4_Window();
            mw.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += Dt_Tick;
            dt.Start();
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            increment++;


            TimerLabel.Content = increment.ToString();
            if (increment % 1 == 0)
            {

                e95_temp.Text = rnd.Next(MinValue, MaxValue).ToString();
                e98_temp.Text = rnd.Next(MinValue, MaxValue).ToString();
                on_temp.Text = rnd.Next(MinValue, MaxValue).ToString();
                lpg_temp.Text = rnd.Next(MinValue, MaxValue).ToString();

                e95_p.Text = rnd.Next(MinValue, MaxValue).ToString();
                e98_p.Text = rnd.Next(MinValue, MaxValue).ToString();
                on_p.Text = rnd.Next(MinValue, MaxValue).ToString();
                lpg_p.Text = rnd.Next(MinValue, MaxValue).ToString();
            }

            if (100 > int.Parse(e95_temp.Text))
            {
                e95_temp.Foreground = new SolidColorBrush(Colors.Blue);
            }
            else if ( 200 < int.Parse(e95_temp.Text))
            {
                e95_temp.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                e95_temp.Foreground = new SolidColorBrush(Colors.White);

            }
        }

        private int increment = 1;

    }
}
