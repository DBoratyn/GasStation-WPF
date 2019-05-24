﻿using System;
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
    /// Logika interakcji dla klasy Contact_Data_Window.xaml
    /// </summary>
    public partial class Contact_Data_Window : Window
    {
        private Konto _loggedInAccount = new Konto();
        public Contact_Data_Window()
        {
            InitializeComponent();
        }
        public Contact_Data_Window(Konto account)
        {
            _loggedInAccount = account;
            InitializeComponent();
        }
        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(_loggedInAccount);
            this.Close();
            mainWindow.Show();
        }
    }
}