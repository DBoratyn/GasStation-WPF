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

namespace StacjaBenzynowa
{
    /// <summary>
    /// Interaction logic for Monitor3_Window.xaml
    /// </summary>
    public partial class Monitor3_Window : Window
    {
        public Monitor3_Window()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
