using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Booking_Window.xaml
    /// </summary>
    public partial class Booking_Window : Window
    {
        private Konto _loggedInAccount = new Konto();
        ObservableCollection<int> hours = new ObservableCollection<int>();
        ObservableCollection<int> minutes = new ObservableCollection<int>();

        public Booking_Window()
        {
            InitializeComponent();
        }
        List<Bookings> personalBookings;
        public Booking_Window(Konto account)
        {
            _loggedInAccount = account;
            InitializeComponent();

            for (int i = 9; i < 19; i++)
            {
                hours.Add(i);
            }
            this.Hour.ItemsSource = hours;

            for (int i = 1; i < 60; i++)
            {
                minutes.Add(i);
            }
            this.Minute.ItemsSource = minutes;

            displayBooking();
        }

        private void displayBooking()
        {

            using (SQLiteConnection conn = new SQLiteConnection(App.databasePath))
            {
                personalBookings = conn.Table<Bookings>().OrderBy(i => i.Id).Where(e => e.Email == _loggedInAccount.Email).ToList();
            }
            if (personalBookings != null)
            {
                BookingListView.ItemsSource = personalBookings;
            }
        }

        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow(_loggedInAccount);
            this.Close();
            mainwindow.Show();
        }

        private void Reserve_Click(object sender, RoutedEventArgs e)
        {

            Bookings isFree = new Bookings();
            using (SQLiteConnection conn = new SQLiteConnection(App.databasePath))
            {
                isFree = conn.Table<Bookings>()
                    .Where(d => d.Date == this.DateReservation.Text && d.Hour == this.Hour.Text && d.Minute == this.Minute.Text)
                    .FirstOrDefault();
            }

            if (isFree == null)
            {
                Bookings newBooking = new Bookings()
                {
                    Date = this.DateReservation.Text,
                    Hour = this.Hour.Text,
                    Minute = this.Minute.Text,
                    Email = this._loggedInAccount.Email
                };

                using (SQLiteConnection conn = new SQLiteConnection(App.databasePath))
                {
                    conn.CreateTable<Bookings>();
                    conn.Insert(newBooking);
                }
                MessageBox.Show("Reservation complete.");
                displayBooking();
            }

            else
            {
                MessageBox.Show("Reservation Date and Time Taken.");
            }
                
        }
    }
}
