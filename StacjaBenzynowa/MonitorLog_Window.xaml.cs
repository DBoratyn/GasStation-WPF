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
    /// Interaction logic for MonitorLog_Window.xaml
    /// </summary>
    public partial class MonitorLog_Window : Window
    {
        private Konto _loggedInAccount = new Konto();
        List<MonitorLog> logList = new List<MonitorLog>();
        int selectedMonth = 1;
        int selectedYear = DateTime.Now.Year;
        List<int> years = new List<int>();
        List<int> Months = new List<int>();

        public MonitorLog_Window(Konto account)
        {
            _loggedInAccount = account;
            InitializeComponent();

            for (int i = 1; i <= 12; i++)
            {
                Months.Add(i);
            }
            this.MonthList.ItemsSource = Months;
            this.MonthList.SelectedItem = Months[DateTime.Now.Month - 1];

            for (int i = DateTime.Now.Year; i >= (DateTime.Now.Year - 3); i--)
            {
                years.Add(i);
            }
            this.YearList.ItemsSource = years;
            this.YearList.SelectedItem = years[0];

            displayLog();
        }

        private void displayLog()
        {
            string filter = $"{selectedYear.ToString()}/0{selectedMonth.ToString()}";
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                logList = connection.Table<MonitorLog>().Where(d => d.Date.Contains(filter)).OrderByDescending(i => i.Id).ToList();
            }
            if (logList != null)
            {
                LogListView.ItemsSource = logList;
            }
        }

        private void MonthList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedMonth = (int)MonthList.SelectedItem;
            displayLog();
        }

        private void YearList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedYear = (int)YearList.SelectedItem;
            displayLog();
        }

        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow(_loggedInAccount);
            this.Close();
            mainwindow.Show();
        }
    }
}
