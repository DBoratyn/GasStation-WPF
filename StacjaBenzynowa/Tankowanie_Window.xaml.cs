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
using SQLite;
using StacjaBenzynowa.Models;

namespace StacjaBenzynowa
{
    /// <summary>
    /// Logika interakcji dla klasy Tankowanie_Window.xaml
    /// </summary>
    public partial class Tankowanie_Window : Window
    {
        private Konto _loggedInAccount = new Konto();
        Cennik prices;

        Coupon SelectedCoupon = new Coupon();

        double totalPrice = 0;

        private double be95, be98, on, lpg, mycie_stand, mycie_wosk;


        string couponOwner;

        public List<Konto> customerList { get; set; }
        private string selectedEmail;

        private void SaveInvoice(object sender, RoutedEventArgs e)
        {                      
            
            Invoices newInvoice = new Invoices()
            {
                email = selectedEmail,
                CouponUsed = SelectedCoupon.Name,
                Nazwa_firmy = this.FirmaTxtBox.Text,
                Imie = this.ImieTxtBox.Text,
                Nazwisko = this.NazwiskoTxtBox.Text,
                Ulica = this.UlicaTxtBox.Text,
                Numer = this.NumberTxtBox.Text,
                Miasto = this.MiastoTxtBox.Text,
                Kod_pocztowy = this.KodTxtBox.Text,
                BenzynaE95 = double.Parse(this.Be95txtBox.Text),
                BenzynaE98 = double.Parse(this.Be98txtBox.Text),
                OlejNapowy = double.Parse(this.OlejtxtBox.Text),
                LPG = double.Parse(this.LPGTxtBox.Text),
                TotalPrice = totalPrice,
            };

            if (SelectedCoupon != null)
            {
                if (SelectedCoupon.Name == "BE/ON")
                {
                    double e95, e98, on;
                    List<double> numbers = new List<double>();
                    Dictionary<string, double> values = new Dictionary<string, double>();

                    using (SQLiteConnection conn2 = new SQLiteConnection(App.databasePath))
                    {
                        conn2.CreateTable<Cennik>();
                        prices = (conn2.Table<Cennik>().FirstOrDefault());

                        e95 = prices.Benzyna_E95;
                        e98 = prices.Benzyna_E98;
                        on = prices.Olej_napedowy_ON;
                    }

                    if (int.Parse(Be95txtBox.Text) < 1)
                    {
                        e95 = 0;
                    }

                    if (int.Parse(Be98txtBox.Text) < 1)
                    {
                        e98 = 0;
                    }

                    if (int.Parse(OlejtxtBox.Text) < 1)
                    {
                        on = 0;
                    }

                    values.Add("e95", e95);
                    values.Add("e98", e98);
                    values.Add("on", on);

                    values.OrderBy(key => key.Value);
                    var meh = values.ToList();
                    if (meh[0].Key == "e95")
                    {
                        newInvoice.TotalPrice -= be95;
                        if ( newInvoice.TotalPrice < 0)
                        {
                            newInvoice.TotalPrice = 0;
                        }


                        string command = $"delete from Coupon where id in ( select id FROM Coupon where name='BE/ON' AND Owner='{couponOwner}' Limit 1 )";
                        using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
                        {
                            SQLiteCommand cm = new SQLiteCommand(connection);
                            cm.CommandText = command;
                            cm.ExecuteNonQuery();
                        }

                    }
                    else if (meh[0].Key == "e98")
                    {
                        if (newInvoice.TotalPrice < 0)
                        {
                            newInvoice.TotalPrice = 0;
                        }


                        string command = $"delete from Coupon where id in ( select id FROM Coupon where name='BE/ON' AND  Owner='{couponOwner}'  Limit 1 )";
                        using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
                        {
                            SQLiteCommand cm = new SQLiteCommand(connection);
                            cm.CommandText = command;
                            cm.ExecuteNonQuery();
                        }

                    }
                    else if (meh[0].Key == "on")
                    {
                        newInvoice.TotalPrice -= on;
                        if (newInvoice.TotalPrice < 0)
                        {
                            newInvoice.TotalPrice = 0;
                        }

                        string command = $"delete from Coupon where id in ( select id FROM Coupon where name='BE/ON' AND  Owner='{couponOwner}'  Limit 1 )";
                        using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
                        {
                            SQLiteCommand cm = new SQLiteCommand(connection);
                            cm.CommandText = command;
                            cm.ExecuteNonQuery();
                        }

                    }

                }
                else if (SelectedCoupon.Name == "LPG")
                {
                    if (int.Parse(LPGTxtBox.Text) > 0)
                    {
                        newInvoice.TotalPrice -= lpg;
                        if (newInvoice.TotalPrice < 0)
                        {
                            newInvoice.TotalPrice = 0;
                        }

                        string command = $"delete from Coupon where id in ( select id FROM Coupon where name='LPG' AND  Owner='{couponOwner}'  Limit 1 )";
                        using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
                            {
                                SQLiteCommand cm = new SQLiteCommand(connection);
                                cm.CommandText = command;
                                cm.ExecuteNonQuery();
                            }

                    }
                }
            }

            if(newInvoice.TotalPrice != 0)
            {
                newInvoice.TotalPrice = Math.Truncate(newInvoice.TotalPrice * 100) / 100;
            }

            using (SQLiteConnection conn = new SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Invoices>();
                conn.Insert(newInvoice);
            }

            Data ube95, ube98, uon, ulpg;

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                ube95 = conn.Table<Data>().Where(f => f.FuelName == "be95").FirstOrDefault();
                ube98 = conn.Table<Data>().Where(f => f.FuelName == "be98").FirstOrDefault();
                uon = conn.Table<Data>().Where(f => f.FuelName == "ON").FirstOrDefault();
                ulpg = conn.Table<Data>().Where(f => f.FuelName == "LPG").FirstOrDefault();
            }

            ube95.Litres = ube95.Litres - int.Parse(Be95txtBox.Text);
            ube98.Litres = ube98.Litres - int.Parse(Be98txtBox.Text);
            uon.Litres = uon.Litres - int.Parse(OlejtxtBox.Text);
            ulpg.Litres = ulpg.Litres - int.Parse(LPGTxtBox.Text);


            string command5 = $"update  Data set litres= {ube95.Litres} where fuelname='be95'";
            string command6 = $"update  Data set litres= {ube98.Litres} where fuelname='be98'";
            string command7 = $"update  Data set litres= {uon.Litres} where fuelname='ON'";
            string command8 = $"update  Data set litres= {ulpg.Litres} where fuelname='LPG'";

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                SQLiteCommand cm = new SQLiteCommand(conn);
                cm.CommandText = command5;
                cm.ExecuteNonQuery();
            }
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                SQLiteCommand cm = new SQLiteCommand(conn);
                cm.CommandText = command6;
                cm.ExecuteNonQuery();
            }
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                SQLiteCommand cm = new SQLiteCommand(conn);
                cm.CommandText = command7;
                cm.ExecuteNonQuery();
            }
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                SQLiteCommand cm = new SQLiteCommand(conn);
                cm.CommandText = command8;
                cm.ExecuteNonQuery();
            }

            this.FirmaTxtBox.Text = "";
            this.ImieTxtBox.Text = "";
            this.NazwiskoTxtBox.Text = "";
            this.UlicaTxtBox.Text = "";
            this.NumberTxtBox.Text = "";
            this.MiastoTxtBox.Text = "";
            this.KodTxtBox.Text = "";
            this.Be95txtBox.Text = "";
            this.Be98txtBox.Text = "";
            this.OlejtxtBox.Text = "";
            this.LPGTxtBox.Text = "";
            CustomersComboBox.SelectedItem = customerList[0];
            // calculate points
            double be95_point, be98_point, on_point, lpg_point;

            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                be95_point = connection.Table<ProgramLojalnościowy>().Select( s => s.benzyna_E95).FirstOrDefault();
                be98_point = connection.Table<ProgramLojalnościowy>().Select( s => s.benzyna_E98).FirstOrDefault();
                on_point = connection.Table<ProgramLojalnościowy>().Select( s => s.olej_nepedowy).FirstOrDefault();
                lpg_point = connection.Table<ProgramLojalnościowy>().Select( s => s.lpg).FirstOrDefault();
            }


            // update points
            Konto AccountToUpdate = new Konto();

            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                AccountToUpdate = connection.Table<Konto>().FirstOrDefault(a => a.Email == selectedEmail);
            }

            AccountToUpdate.Points += ((int)be95_point) * (int)newInvoice.BenzynaE95 + (((int)be98_point) * (int)newInvoice.BenzynaE98)
                + (((int)on_point) * (int)newInvoice.OlejNapowy) + (((int)lpg_point) * (int)newInvoice.LPG);


            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Konto>();
                conn.InsertOrReplace(AccountToUpdate);
            }


            MessageBox.Show("Invoice added.");
            MainWindow mainwindow = new MainWindow(_loggedInAccount);
            mainwindow.Show();
            this.Close();
            

        }

        private void Coupons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedCoupon = (Coupon)CouponList.SelectedItem;
        }

        private void CreateTextFile(object sender, RoutedEventArgs e)
        {
            if ( string.IsNullOrEmpty(selectedEmail))
            {
                selectedEmail = ("No Email Selected");
            }

            string dt = DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss") + ".txt";

            StreamWriter File = new StreamWriter(@"..\..\Invoices\Faktura " + selectedEmail.ToString() + " " + dt, true);

            File.WriteLine("Klinet: " + selectedEmail);
            if (SelectedCoupon != null)
            {
                File.WriteLine("Kupon: " + SelectedCoupon.Name);
            }

            File.WriteLine("_______________________________");
            File.WriteLine("Firma: " + FirmaTxtBox.Text);
            File.WriteLine("Imie: " + ImieTxtBox.Text);
            File.WriteLine("Nazwisko: " + NazwiskoTxtBox.Text);
            File.WriteLine("Ulica: " + UlicaTxtBox.Text);
            File.WriteLine("Numer: " + NumberTxtBox.Text);
            File.WriteLine("Miasto: " + MiastoTxtBox.Text);
            File.WriteLine("Kod Pocztowy: " + KodTxtBox.Text);

            File.WriteLine("_______________________________");
            File.WriteLine("Benzyna E95: " + this.Be95txtBox.Text);
            File.WriteLine("Benzyna E98: " + this.Be98txtBox.Text);
            File.WriteLine("Olej Napedowy: " + this.OlejtxtBox.Text);
            File.WriteLine("LPG: " + this.LPGTxtBox.Text);
            File.WriteLine("");
            File.WriteLine("Kwota calkowita: " + this.TotalPriceLbl.Content);

            File.Close();
            MessageBox.Show("Invoice file created.");
        }


        // public Konto SelectedCustomer { get; set; }

        private void UpdateInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Konto SelectedCustomer = (Konto)CustomersComboBox.SelectedItem;
            this.FirmaTxtBox.Text = SelectedCustomer.Nazwa_firmy;
            this.ImieTxtBox.Text = SelectedCustomer.Imie;
            this.NazwiskoTxtBox.Text = SelectedCustomer.Nazwisko;
            this.UlicaTxtBox.Text = SelectedCustomer.Ulica;
            this.NumberTxtBox.Text = SelectedCustomer.Numer;
            this.MiastoTxtBox.Text = SelectedCustomer.Miasto;
            this.KodTxtBox.Text = SelectedCustomer.Kod_pocztowy;
            selectedEmail = SelectedCustomer.Email;

            couponOwner = SelectedCustomer.Email;

            List<Coupon> coupons = new List<Coupon>();
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                coupons = connection.Table<Coupon>().Where(n => n.Owner == SelectedCustomer.Email && (n.Name == "BE/ON" || n.Name == "LPG")).ToList();
            }

            if (coupons != null)
            {
                this.CouponList.ItemsSource = coupons;
            }
        }

        public Tankowanie_Window()
        {
            InitializeComponent();
        }
        public Tankowanie_Window(Konto account)
        {
            _loggedInAccount = account;
            InitializeComponent();

            using (SQLiteConnection conn2 = new SQLiteConnection(App.databasePath))
            {
                conn2.CreateTable<Cennik>();
                prices = (conn2.Table<Cennik>().FirstOrDefault());

                be95 = prices.Benzyna_E95;
                be98 = prices.Benzyna_E98;
                on = prices.Olej_napedowy_ON;
                lpg = prices.LPG;
                mycie_stand = prices.Mycie_standardowe;
                mycie_wosk = prices.Mycie_z_woskiem;                
            }

            using (SQLiteConnection conn3 = new SQLiteConnection(App.databasePath))
            {
                customerList = conn3.Table<Konto>().OrderBy(c => c.Email).Where(c => c.Role.ToUpper() == "CUSTOMER").ToList();
            }
            if (customerList != null)
            {
                this.CustomersComboBox.ItemsSource = customerList;
            }

            Be95txtBox.Text = "0";
            Be98txtBox.Text = "0";
            LPGTxtBox.Text = "0";
            OlejtxtBox.Text = "0";


        }

        private void getTotal (object sender, RoutedEventArgs e)
        {
            totalPrice = 0;
            if (string.IsNullOrEmpty(this.Be95txtBox.Text))
            {
                Be95txtBox.Text = "0";
            } else
            {
                totalPrice += (be95 * double.Parse(Be95txtBox.Text));
            }

            if (string.IsNullOrEmpty(this.Be98txtBox.Text))
            {
                Be98txtBox.Text = "0";
            } else
            {
                totalPrice += (be98 * double.Parse(Be98txtBox.Text));
            }

            if (string.IsNullOrEmpty(this.OlejtxtBox.Text))
            {
                OlejtxtBox.Text = "0";
            } else
            {
                totalPrice += (on * double.Parse(OlejtxtBox.Text));
            }

            if (string.IsNullOrEmpty(this.LPGTxtBox.Text))
            {
                LPGTxtBox.Text = "0";
            } else
            {
                totalPrice += (lpg * double.Parse(LPGTxtBox.Text));
            }

            totalPrice = Math.Truncate(totalPrice * 100) / 100;

            this.TotalPriceLbl.Content = totalPrice;
        }

        private void Back_button_Click(object sender, RoutedEventArgs e)
        {


            MainWindow mainwindow = new MainWindow(_loggedInAccount);
            this.Close();
            mainwindow.Show();
        }
    }
}
