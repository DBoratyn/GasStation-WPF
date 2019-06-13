using System;
using System.Collections.Generic;
using System.IO;
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
        List<int> years = new List<int>();
        List<int> Months = new List<int>();


        DispatcherTimer dt = new DispatcherTimer();

        Random rnd = new Random();
        
        public Monitoring_Window()
        {
            InitializeComponent();
        }
        public Monitoring_Window(Konto account)
        {
            _loggedInAccount = account;
            InitializeComponent();
            LoadData();

            for (int i = 1; i <= 12; i++)
            {
                Months.Add(i);
            }
            this.MonthList.ItemsSource = Months;
            this.MonthList.SelectedItem = Months[DateTime.Now.Month-1];

            for (int i = DateTime.Now.Year; i >= (DateTime.Now.Year-3); i--)
            {
                years.Add(i);
            }
            this.YearList.ItemsSource = years;
            this.YearList.SelectedItem = years[0];
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
            dt.Stop();
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
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += Dt_Tick;
            dt.Start();
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            increment++;
            
            if (increment == 60)
            {

                e95_temp.Text = rnd.Next(MinValue, MaxValue).ToString();
                e98_temp.Text = rnd.Next(MinValue, MaxValue).ToString();
                on_temp.Text = rnd.Next(MinValue, MaxValue).ToString();
                lpg_temp.Text = rnd.Next(MinValue, MaxValue).ToString();

                e95_p.Text = rnd.Next(MinValue, MaxValue).ToString();
                e98_p.Text = rnd.Next(MinValue, MaxValue).ToString();
                on_p.Text = rnd.Next(MinValue, MaxValue).ToString();
                lpg_p.Text = rnd.Next(MinValue, MaxValue).ToString();
                increment = 0;
            

            MonitorLog ml = new MonitorLog()
            {
                Date = DateTime.Now.ToString("yyyy/MM/dd"),
                Time = DateTime.Now.ToString("hh:mm:ss"),

                BenzynaE95_T = double.Parse(e95_temp.Text),
                BenzynaE98_T = double.Parse(e98_temp.Text),
                OlejNapeowy_T = double.Parse(on_temp.Text),
                LPG_T = double.Parse(lpg_temp.Text),

                BenzynaE95_P = double.Parse(e95_p.Text),
                BenzynaE98_P = double.Parse(e98_p.Text),
                OlejNapeowy_P = double.Parse(on_p.Text),
                LPG_P = double.Parse(lpg_p.Text)
            };
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<MonitorLog>();
                conn.Insert(ml);
            }

            if (100 > int.Parse(e95_temp.Text))
            {
                e95_temp.Foreground = new SolidColorBrush(Colors.Blue);
                MessageBox.Show("Temperature is too cold.");
            }
            else if (200 < int.Parse(e95_temp.Text))
            {
                e95_temp.Foreground = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Temperature is too hot.");
            }
            else
            {
                e95_temp.Foreground = new SolidColorBrush(Colors.White);
            }

            if (100 > int.Parse(e98_temp.Text))
            {
                e95_temp.Foreground = new SolidColorBrush(Colors.Blue);
                MessageBox.Show("Temperature is too cold.");
            }
            else if (200 < int.Parse(e98_temp.Text))
            {
                e98_temp.Foreground = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Temperature is too hot.");
            }
            else
            {
                e98_temp.Foreground = new SolidColorBrush(Colors.White);
            }

            if (100 > int.Parse(on_temp.Text))
            {
                on_temp.Foreground = new SolidColorBrush(Colors.Blue);
                MessageBox.Show("Temperature is too cold.");
            }
            else if (200 < int.Parse(on_temp.Text))
            {
                on_temp.Foreground = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Temperature is too hot.");
            }
            else
            {
                on_temp.Foreground = new SolidColorBrush(Colors.White);
            }

            if (100 > int.Parse(lpg_temp.Text))
            {
                lpg_temp.Foreground = new SolidColorBrush(Colors.Blue);
                MessageBox.Show("Temperature is too cold.");
            }
            else if (200 < int.Parse(lpg_temp.Text))
            {
                lpg_temp.Foreground = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Temperature is too hot.");
            }
            else
            {
                lpg_temp.Foreground = new SolidColorBrush(Colors.White);
            }

            if (100 > int.Parse(e95_p.Text))
            {
                e95_p.Foreground = new SolidColorBrush(Colors.Blue);
                MessageBox.Show("Pressure is too low.");
            }
            else if (200 < int.Parse(e95_p.Text))
            {
                e95_p.Foreground = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Pressure is too high.");
            }
            else
            {
                e95_p.Foreground = new SolidColorBrush(Colors.White);
            }

            if (100 > int.Parse(e98_p.Text))
            {
                e98_p.Foreground = new SolidColorBrush(Colors.Blue);
                MessageBox.Show("Pressure is too low.");
            }
            else if (200 < int.Parse(e98_p.Text))
            {
                e98_p.Foreground = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Pressure is too high.");
            }
            else
            {
                e98_p.Foreground = new SolidColorBrush(Colors.White);
            }

            if (100 > int.Parse(on_p.Text))
            {
                on_p.Foreground = new SolidColorBrush(Colors.Blue);
                MessageBox.Show("Pressure is too low.");
            }
            else if (200 < int.Parse(e95_temp.Text))
            {
                on_p.Foreground = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Pressure is too high.");
            }
            else
            {
                on_p.Foreground = new SolidColorBrush(Colors.White);
            }

            if (100 > int.Parse(lpg_p.Text))
            {
                lpg_p.Foreground = new SolidColorBrush(Colors.Blue);
                MessageBox.Show("Pressure is too low.");
            }
            else if (200 < int.Parse(lpg_p.Text))
            {
                lpg_p.Foreground = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Pressure is too high.");
            }
            else
            {
                lpg_p.Foreground = new SolidColorBrush(Colors.White);
            }
            }
        }

        private int increment = 1;

        private void FixTemperature(object sender, RoutedEventArgs e)
        {
            if(double.Parse(e95_temp.Text) < 100)
            {
                this.e95_temp.Text = (double.Parse(e95_temp.Text) + 10).ToString();
                e95_temp.Foreground = new SolidColorBrush(Colors.White);
            } else if (double.Parse(e95_temp.Text) > 200)
            {
                this.e95_temp.Text = (double.Parse(e95_temp.Text) - 10).ToString();
                e95_temp.Foreground = new SolidColorBrush(Colors.White);
            }

            if (double.Parse(e98_temp.Text) < 100)
            {
                this.e98_temp.Text = (double.Parse(e98_temp.Text) + 10).ToString();
                e98_temp.Foreground = new SolidColorBrush(Colors.White);
            }
            else if (double.Parse(e98_temp.Text) > 200)
            {
                this.e98_temp.Text = (double.Parse(e98_temp.Text) - 10).ToString();
                e98_temp.Foreground = new SolidColorBrush(Colors.White);
            }

            if (double.Parse(on_temp.Text) < 100)
            {
                this.on_temp.Text = (double.Parse(on_temp.Text) + 10).ToString();
                on_temp.Foreground = new SolidColorBrush(Colors.White);
            }
            else if (double.Parse(on_temp.Text) > 200)
            {
                this.on_temp.Text = (double.Parse(on_temp.Text) - 10).ToString();
                on_temp.Foreground = new SolidColorBrush(Colors.White);
            }

            if (double.Parse(lpg_temp.Text) < 100)
            {
                this.lpg_temp.Text = (double.Parse(lpg_temp.Text) + 10).ToString();
                lpg_temp.Foreground = new SolidColorBrush(Colors.White);
            }
            else if (double.Parse(lpg_temp.Text) > 200)
            {
                this.lpg_temp.Text = (double.Parse(lpg_temp.Text) - 10).ToString();
                lpg_temp.Foreground = new SolidColorBrush(Colors.White);
            }

            MonitorLog ml = new MonitorLog()
            {
                Date = DateTime.Now.ToString("yyyy/MM/dd"),
                Time = DateTime.Now.ToString("hh:mm:ss"),

                BenzynaE95_T = double.Parse(e95_temp.Text),
                BenzynaE98_T = double.Parse(e98_temp.Text),
                OlejNapeowy_T = double.Parse(on_temp.Text),
                LPG_T = double.Parse(lpg_temp.Text),

                BenzynaE95_P = double.Parse(e95_p.Text),
                BenzynaE98_P = double.Parse(e98_p.Text),
                OlejNapeowy_P = double.Parse(on_p.Text),
                LPG_P = double.Parse(lpg_p.Text)
            };
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<MonitorLog>();
                conn.Insert(ml);
            }
        }

        private void FixPressure(object sender, RoutedEventArgs e)
        {
            if (double.Parse(e95_p.Text) < 100)
            {
                this.e95_temp.Text = (double.Parse(e95_p.Text) + 10).ToString();
                e95_p.Foreground = new SolidColorBrush(Colors.White);
            }
            else if (double.Parse(e95_p.Text) > 200)
            {
                this.e95_temp.Text = (double.Parse(e95_p.Text) - 10).ToString();
                e95_p.Foreground = new SolidColorBrush(Colors.White);
            }

            if (double.Parse(e98_p.Text) < 100)
            {
                this.e98_p.Text = (double.Parse(e98_p.Text) + 10).ToString();
                e98_p.Foreground = new SolidColorBrush(Colors.White);
            }
            else if (double.Parse(e98_p.Text) > 200)
            {
                this.e98_p.Text = (double.Parse(e98_p.Text) - 10).ToString();
                e98_p.Foreground = new SolidColorBrush(Colors.White);
            }

            if (double.Parse(on_p.Text) < 100)
            {
                this.on_p.Text = (double.Parse(on_p.Text) + 10).ToString();
                on_p.Foreground = new SolidColorBrush(Colors.White);
            }
            else if (double.Parse(on_p.Text) > 200)
            {
                this.on_p.Text = (double.Parse(on_p.Text) - 10).ToString();
                on_p.Foreground = new SolidColorBrush(Colors.White);
            }

            if (double.Parse(lpg_p.Text) < 100)
            {
                this.lpg_p.Text = (double.Parse(lpg_p.Text) + 10).ToString();
                lpg_p.Foreground = new SolidColorBrush(Colors.White);
            }
            else if (double.Parse(lpg_p.Text) > 200)
            {
                this.lpg_p.Text = (double.Parse(lpg_p.Text) - 10).ToString();
                lpg_p.Foreground = new SolidColorBrush(Colors.White);
            }

            MonitorLog ml = new MonitorLog()
            {
                Date = DateTime.Now.ToString("yyyy/MM/dd"),
                Time = DateTime.Now.ToString("hh:mm:ss"),

                BenzynaE95_T = double.Parse(e95_temp.Text),
                BenzynaE98_T = double.Parse(e98_temp.Text),
                OlejNapeowy_T = double.Parse(on_temp.Text),
                LPG_T = double.Parse(lpg_temp.Text),

                BenzynaE95_P = double.Parse(e95_p.Text),
                BenzynaE98_P = double.Parse(e98_p.Text),
                OlejNapeowy_P = double.Parse(on_p.Text),
                LPG_P = double.Parse(lpg_p.Text)
            };
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<MonitorLog>();
                conn.Insert(ml);
            }
        }

        private List<MonitorLog> Log = new List<MonitorLog>();
        int selectedMonth = 1;
        int selectedYear = DateTime.Now.Year;
        private void CreateReport(object sender, RoutedEventArgs e)
        {
            string dt = DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss") + ".txt";

            StreamWriter File = new StreamWriter(@"..\..\MonitorLog\MonitorLog " + dt, true);
            string filter = $"{selectedYear.ToString()}/0{selectedMonth.ToString()}";
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                Log = connection.Table<MonitorLog>().Where(d => d.Date.Contains(filter)).OrderByDescending(i => i.Id).ToList();
            }

            foreach (MonitorLog ml in Log)
            {
                File.WriteLine("Id: " + ml.Id);
                File.WriteLine("Date: " + ml.Date);
                File.WriteLine("Time: " + ml.Time);

                File.WriteLine("_______________________________");
                File.WriteLine("TEMPERATURE");
                File.WriteLine("Benzyna E95: " + ml.BenzynaE95_T);
                File.WriteLine("Benzyna E98: " + ml.BenzynaE98_T);
                File.WriteLine("Olej Napedowy: "  + ml.OlejNapeowy_T);
                File.WriteLine("LPG: " + ml.LPG_T);
                File.WriteLine("_______________________________");
                File.WriteLine("PRESSURE");
                File.WriteLine("Benzyna E95: " + ml.BenzynaE95_P);
                File.WriteLine("Benzyna E98: " + ml.BenzynaE98_P);
                File.WriteLine("Olej Napedowy: " + ml.OlejNapeowy_P);
                File.WriteLine("LPG: " + ml.LPG_P);
                File.WriteLine("");
                File.WriteLine("");
                File.WriteLine("");
            }

            File.Close();
            MessageBox.Show("Monitor log created.");
        }

        private void MonthList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedMonth = (int)MonthList.SelectedItem;
        }

        private void YearList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedYear = (int)YearList.SelectedItem;
        }
    }
}
