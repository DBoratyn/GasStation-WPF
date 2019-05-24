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
    /// Interaction logic for Employess_Window.xaml
    /// </summary>
    public partial class Employess_Window : Window
    {
        List<Konto> employeList;
        public Employess_Window()
        {
            InitializeComponent();
        }
        private Konto _loggedInAccount = new Konto();
        public Employess_Window(Konto account)
        {
            _loggedInAccount = account;
            InitializeComponent();
        }
        private void displayEmployess(object sender, RoutedEventArgs e)
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                employeList = connection.Table<Konto>().OrderBy(t => t.Email).Where(t=>t.Role.ToUpper()!="CUSTOMER").ToList();
            }
            if (employeList != null)
            {
                employeListView.ItemsSource = employeList;
            }
        }
        private void ANE_button_Click(object sender, RoutedEventArgs e)
        {
            Add_New_Employee_Window addEmploye = new Add_New_Employee_Window(_loggedInAccount);
            this.Close();
            addEmploye.ShowDialog();
        }

        private void EmployeListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Konto selectedAccount = (Konto)employeListView.SelectedItem;
            Modify_Window modify_window = new Modify_Window(_loggedInAccount, selectedAccount, "EMPLOYEE");
            this.Close();
            modify_window.ShowDialog();
        }

        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(_loggedInAccount);
            this.Close();
            mainWindow.Show();
        }
    }
}
