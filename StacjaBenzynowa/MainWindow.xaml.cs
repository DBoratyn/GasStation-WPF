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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SQLite;
using StacjaBenzynowa.Models;

namespace StacjaBenzynowa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //properties
        public int openClose = 0;
        public bool dualclick = false;

        private Konto _loggedInAccount = new Konto();
        bool admin = false;

        List<Informacje> informacjeList;
        List<Cennik> cennikList;
        List<ProgramLojalnościowy> programlojalnościowyList;
        List<Invoices> invoiceList = new List<Invoices>();

        public MainWindow()
        {
            InitializeComponent();
            informacjeList = new List<Informacje>();
            cennikList = new List<Cennik>();
            programlojalnościowyList = new List<ProgramLojalnościowy>();
            readInformacjeDatabase();
            this.TwojeSaldoLbl.Visibility = Visibility.Hidden;
            this.saldo.Visibility = Visibility.Hidden;
            this.PunktowLbl.Visibility = Visibility.Hidden;
            this.AktualnieLbl.Visibility = Visibility.Hidden;

            this.TwojeAktualneNagrodyLbl.Visibility = Visibility.Hidden;
        }

        public MainWindow(Konto account)
        {
            InitializeComponent();
            informacjeList = new List<Informacje>();
            readInformacjeDatabase();
            _loggedInAccount = account;

            //towrzenie ról użytkowników
            if (account.Role.ToUpper()=="ADMIN")
            {
                admin = true;
                EnableAdmin();
            }
            else if (account.Role.ToUpper()=="CUSTOMER")
            {
                EnableCustomer();
            }
            else if (account.Role.ToUpper()=="STAFF")
            {
                EnableStaff();
            }
            else if (account.Role.ToUpper()=="SECURITY")
            {
                EnableSecurity();
            }

            //pokazywanie okien użytkowników
            void EnableAdmin()
            {

                using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
                {
                    invoiceList = connection.Table<Invoices>().OrderBy(i => i.Id).ToList();
                }
                if (invoiceList != null)
                {
                    invoiceListView.ItemsSource = invoiceList;
                }

                this.D_button.Visibility = Visibility.Visible;
                this.MD_button.Visibility = Visibility.Visible;
                this.L_button.Visibility = Visibility.Hidden;
                this.LO_button.Visibility = Visibility.Visible;

                this.B_button.Visibility = Visibility.Visible;
                this.E_button.Visibility = Visibility.Visible;
                this.C_button.Visibility = Visibility.Visible;
                this.I_button.Visibility = Visibility.Visible;
                this.M_button.Visibility = Visibility.Visible;
                this.TH_button.Visibility = Visibility.Visible;

                this.button.Visibility = Visibility.Visible;
                this.button_mod_cen.Visibility = Visibility.Visible;
                
                this.Redeem1.Visibility = Visibility.Hidden;
                this.Redeem2.Visibility = Visibility.Hidden;
                this.Redeem3.Visibility = Visibility.Hidden;
                this.Redeem4.Visibility = Visibility.Hidden;

                this.MontorLogBtn.Visibility = Visibility.Visible;

                this.tankuj_button.Visibility = Visibility.Visible;
                this.myj_button.Visibility = Visibility.Visible;


                this.TwojeSaldoLbl.Visibility = Visibility.Hidden;
                this.saldo.Visibility = Visibility.Hidden;
                this.PunktowLbl.Visibility = Visibility.Hidden;
                this.AktualnieLbl.Visibility = Visibility.Hidden;

                this.TwojeAktualneNagrodyLbl.Visibility = Visibility.Hidden;
                this.CouponList.Visibility = Visibility.Hidden;


            }

            void EnableCustomer()
            {
                using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
                {
                    invoiceList = connection.Table<Invoices>().Where(i => i.email == _loggedInAccount.Email).OrderBy(i => i.Id).ToList();
                }
                if (invoiceList != null)
                {
                    invoiceListView.ItemsSource = invoiceList;
                }

                this.L_button.Visibility = Visibility.Hidden;
                this.LO_button.Visibility = Visibility.Visible;

                this.MD_button.Visibility = Visibility.Visible;
                this.B_button.Visibility = Visibility.Visible;
                this.TH_button.Visibility = Visibility.Visible;

                this.Redeem1.Visibility = Visibility.Visible;
                this.Redeem2.Visibility = Visibility.Visible;
                this.Redeem3.Visibility = Visibility.Visible;
                this.Redeem4.Visibility = Visibility.Visible;

                this.CouponList.Visibility = Visibility.Visible;
            }
            void EnableStaff()
            {

                using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
                {
                    invoiceList = connection.Table<Invoices>().OrderBy(i => i.Id).ToList();
                }
                if (invoiceList != null)
                {
                    invoiceListView.ItemsSource = invoiceList;
                }/*

                List<Coupon> coupons2 = new List<Coupon>();
                using (SQLiteConnection conn = new SQLiteConnection(App.databasePath))
                {
                    coupons2 = conn.Table<Coupon>().Where(c => c.Owner == _loggedInAccount.Email).ToList();
                }
                if (coupons2 != null)
                {
                   CouponList2.ItemsSource = coupons2;
                }*/

                


                this.MD_button.Visibility = Visibility.Visible;
                this.L_button.Visibility = Visibility.Hidden;
                this.LO_button.Visibility = Visibility.Visible;

                this.B_button.Visibility = Visibility.Visible;
                this.E_button.Visibility = Visibility.Visible;
                this.C_button.Visibility = Visibility.Visible;
                this.I_button.Visibility = Visibility.Visible;
                this.TH_button.Visibility = Visibility.Visible;

                this.Redeem1.Visibility = Visibility.Hidden;
                this.Redeem2.Visibility = Visibility.Hidden;
                this.Redeem3.Visibility = Visibility.Hidden;
                this.Redeem4.Visibility = Visibility.Hidden;

                this.tankuj_button.Visibility = Visibility.Visible;
                this.myj_button.Visibility = Visibility.Visible;


                this.TwojeSaldoLbl.Visibility = Visibility.Hidden;
                this.saldo.Visibility = Visibility.Hidden;
                this.PunktowLbl.Visibility = Visibility.Hidden;
                this.AktualnieLbl.Visibility = Visibility.Hidden;

                this.TwojeAktualneNagrodyLbl.Visibility = Visibility.Hidden;
                this.CouponList.Visibility = Visibility.Hidden;

            }
            void EnableSecurity()
            {
                this.MD_button.Visibility = Visibility.Visible;
                this.L_button.Visibility = Visibility.Hidden;
                this.LO_button.Visibility = Visibility.Visible;

                this.B_button.Visibility = Visibility.Visible;
                this.E_button.Visibility = Visibility.Visible;
                this.C_button.Visibility = Visibility.Visible;
                this.I_button.Visibility = Visibility.Visible;
                this.M_button.Visibility = Visibility.Visible;
                this.TH_button.Visibility = Visibility.Visible;

                this.tankuj_button.Visibility = Visibility.Visible;
                this.myj_button.Visibility = Visibility.Visible;


                this.TwojeSaldoLbl.Visibility = Visibility.Hidden;
                this.saldo.Visibility = Visibility.Hidden;
                this.PunktowLbl.Visibility = Visibility.Hidden;
                this.AktualnieLbl.Visibility = Visibility.Hidden;

                this.TwojeAktualneNagrodyLbl.Visibility = Visibility.Hidden;
                this.CouponList.Visibility = Visibility.Hidden;

            }
        }
      
        public void readInformacjeDatabase()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Informacje>();
                informacjeList = (conn.Table<Informacje>().ToList()).OrderBy(c => c.Wlasciciel).ToList();
            }
            using (SQLite.SQLiteConnection conn2 = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn2.CreateTable<Cennik>();
                cennikList = (conn2.Table<Cennik>().ToList()).OrderBy(c => c.Benzyna_E95).ToList();
            }
            using (SQLite.SQLiteConnection conn3 = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn3.CreateTable<ProgramLojalnościowy>();
                programlojalnościowyList = (conn3.Table<ProgramLojalnościowy>().ToList()).OrderBy(c => c.benzyna_E95).ToList();
            }
        }

        //otwieranie informacji o cenniku
        private void price_list_button(object sender, RoutedEventArgs e)
        {
            if (dualclick == true)
            {
                openClose++;
                dualclick = false;
            }
            if (openClose % 2 == 0)
            {
                openClose++;
                Cennik_grid.Visibility = Visibility.Hidden;
            }
            else
            {
                openClose = 2;
                Cennik_grid.Visibility = Visibility.Visible;
                showPrices(sender, e);
            }
        }
        //otwieranie historii transakcji
        private void transaction_history_button(object sender, RoutedEventArgs e)
        {
            if (dualclick == true)
            {
                openClose++;
                dualclick = false;
            }
            if (openClose % 2 == 0)
            {
                openClose++;
                Historia_transakcji_grid.Visibility = Visibility.Visible;
            }
            else
            {
                openClose = 2;
                Historia_transakcji_grid.Visibility = Visibility.Hidden;
            }
        }
        //otwieranie informacji o programie lojalnościowym
        private void loyalty_program_button(object sender, RoutedEventArgs e)
        {
            if (dualclick == true)
            {
                openClose++;
                dualclick = false;
            }
            if (openClose % 2 == 0)
            {
                openClose++;
                Program_lojalnosciowy_grid.Visibility = Visibility.Visible;
            }
            else
            {
                openClose = 2;
                Program_lojalnosciowy_grid.Visibility = Visibility.Hidden;
            }
        }
        //otwieranie okna rejestracji i logowania
        private void login_button(object sender, RoutedEventArgs e)
        {
            Login_Window login_window = new Login_Window();
            this.Close();
            login_window.ShowDialog();
        }
        //przycisk wylogowania
        private void logout_button (object sender, RoutedEventArgs e)
        {
            MainWindow main_window = new MainWindow();
            this.Close();
            main_window.ShowDialog();
        }
        //podgląd danych użytkownika
        private void my_data_button(object sender, RoutedEventArgs e)
        {
            if (admin == true)
            {
                My_Data_Window my_data_window = new My_Data_Window(_loggedInAccount, true);
                this.Close();
                my_data_window.ShowDialog();
            }
            else
            {
                My_Data_Window my_data_window = new My_Data_Window(_loggedInAccount);
                this.Close();
                my_data_window.ShowDialog();
            }
        }
        //dostawy
        private void deliveries_button(object sender, RoutedEventArgs e)
        {
            Deliveries_Window deliveries_window = new Deliveries_Window();
            this.Close();
            deliveries_window.ShowDialog();
        }
        //rezerwacja myjni
        private void booking_button (object sender, RoutedEventArgs e)
        {
            Booking_Window booking_window = new Booking_Window();
            this.Close();
            booking_window.ShowDialog();
        }
        //pracownicy
        private void employess_button(object sender, RoutedEventArgs e)
        {
            Employess_Window employess_window = new Employess_Window(_loggedInAccount);
            this.Close();
            employess_window.ShowDialog();
        }
        //klienci
        private void customers_button(object sender, RoutedEventArgs e)
        {
            Customers_Window customers_window = new Customers_Window(_loggedInAccount);
            this.Close();
            customers_window.ShowDialog();
        }
        //faktury
        private void invoices_button(object sender, RoutedEventArgs e)
        {
            Invoices_Window invoices_window = new Invoices_Window();
            this.Close();
            invoices_window.ShowDialog();
        }
        //monitoring
        private void monitoring_button(object sender, RoutedEventArgs e)
        {
            Monitoring_Window monitoring_window = new Monitoring_Window();
            this.Close();
            monitoring_window.ShowDialog();
        }
        //przysik edycji danych kontaktowych
        private void Edit_button_click(object sender, RoutedEventArgs e)
        {
            Contact_Data_Window contact_data_window = new Contact_Data_Window(_loggedInAccount);
            this.Close();
            contact_data_window.ShowDialog();
        }
        //otwiera okno do modyfikacji danych
        private void Mod_price_button(object sender, RoutedEventArgs e)
        {
            Modify_prices modify_prices = new Modify_prices(_loggedInAccount);
            this.Close();
            modify_prices.ShowDialog();
        }
        //otwiera okno do modyfikacji programu loajlnościowego
        private void Mod_loyalty(object sender, RoutedEventArgs e)
        {
            Modify_loyalty_window modify_loyalty_window = new Modify_loyalty_window(_loggedInAccount);
            this.Close();
            modify_loyalty_window.ShowDialog();
        }
        //okno wyświetlania danych kontaktowych
        private void information_small_box(object sender, RoutedEventArgs e)
        {
            readInformacjeDatabase();
        }
        //wyświetlanie danych kontaktowych
        Informacje owner;
        private void showOwner(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Informacje>();
                owner = (conn.Table<Informacje>().FirstOrDefault());

                Owner.Content = owner.Wlasciciel;
                Address.Content = owner.Adres;
                PhoneNumber.Content = owner.Telefon;
                Fax.Content = owner.Fax;
                Cashiers.Content = owner.Kasjerzy;
                Wash_Stuff.Content = owner.Myjnia;
                Monitoring_Stuff.Content = owner.Monitoring;
                LPG_Stuff.Content = owner.ObslugaLPG;
            }
        }
        //cennik
        private void cennik_informacje(object sender, RoutedEventArgs e)
        {
            readInformacjeDatabase();
        }
        Cennik prices;
        private void showPrices(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection conn2 = new SQLiteConnection(App.databasePath))
            {
                conn2.CreateTable<Cennik>();
                prices = (conn2.Table<Cennik>().FirstOrDefault());

                Benzyna_E95_label.Content = prices.Benzyna_E95;
                Benzyna_E98_label.Content = prices.Benzyna_E98;
                Olej_napedowy_ON_label.Content = prices.Olej_napedowy_ON;
                LPG_label.Content = prices.LPG;
                mycie_standardowe_label.Content = prices.Mycie_standardowe;
                mycie_z_woskiem_label.Content = prices.Mycie_z_woskiem;
            }
        }
        //otwiera oknwo rezerwacji myjni
        public void booking_button_click(object sender, RoutedEventArgs e)
        {
            Booking_Window booking_window = new Booking_Window(_loggedInAccount);
            this.Close();
            booking_window.ShowDialog();
        }
        //otwiera okno dostaw
        public void deliveries_button_click(object sender, RoutedEventArgs e)
        {
            Deliveries_Window deliveries_window = new Deliveries_Window(_loggedInAccount);
            this.Close();
            deliveries_window.ShowDialog();
        }
        //otwiera okno monitoringu
        public void monitoring_button_click(object sender, RoutedEventArgs e)
        {
            Monitoring_Window monitoring_window = new Monitoring_Window(_loggedInAccount);
            this.Close();
            monitoring_window.ShowDialog();
        }
        //otwiera okno faktur
        public void invoices_button_click(object sender, RoutedEventArgs e)
        {
            Invoices_Window invoices_window = new Invoices_Window(_loggedInAccount);
            this.Close();
            invoices_window.ShowDialog();
        }
        //otwiera okno tankownia
        public void tankuj_button_click(object sender, RoutedEventArgs e)
        {
            Tankowanie_Window tankowanie_window = new Tankowanie_Window(_loggedInAccount);
            this.Close();
            tankowanie_window.ShowDialog();
        }
        //otwiera okno mycia
        public void myj_button_click(object sender, RoutedEventArgs e)
        {
            Mycie_Window mycie_window = new Mycie_Window(_loggedInAccount);
            this.Close();
            mycie_window.ShowDialog();
        }
        //
        //program lojalnościowy
        private void programlojalnościowy_informacje (object sender, RoutedEventArgs e)
        {
            readInformacjeDatabase();
        }
        ProgramLojalnościowy prog_prices;
        private void showprog_Prices (object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection conn3 = new SQLiteConnection(App.databasePath))
            {
                conn3.CreateTable<ProgramLojalnościowy>();
                prog_prices = (conn3.Table<ProgramLojalnościowy>().FirstOrDefault());

                benzyna_e95label.Content = prog_prices.benzyna_E95;
                benzyna_e98label.Content = prog_prices.benzyna_E98;
                olej_napedowylabel.Content = prog_prices.olej_nepedowy;
                lpglabel.Content = prog_prices.lpg;
                benzyna_on_nagrody_label.Content = prog_prices.benzyna_on_nagrody;
                lpg_nagrody_label.Content = prog_prices.lpg_ngrody;
                mycie_z_woskiemlabel.Content = prog_prices.mycie_z_woskiem;
                mycie_standardowelabel.Content = prog_prices.mycie_standardowe;
                mycie_standardowe_nagrody_label.Content = prog_prices.mycie_standardowe_nagrody;
                mycie_z_woskiem_nagrody_label.Content = prog_prices.mycie_z_woskiem_nagrody;
            }

            if (_loggedInAccount.Email != null)
            {

                Konto AccountToUpdate = new Konto();

                using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
                {
                    AccountToUpdate = connection.Table<Konto>().FirstOrDefault(a => a.Email == _loggedInAccount.Email);
                }
                saldo.Content = AccountToUpdate.Points;

                List<Coupon> coupons = new List<Coupon>();
                using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
                {
                    coupons = connection.Table<Coupon>().Where( n => n.Owner == _loggedInAccount.Email).ToList();
                }



                if (coupons != null && _loggedInAccount.Role == "CUSTOMER")
                {
                    this.CouponList.ItemsSource = coupons;
                    if (coupons.Count > 0)
                    {
                        CouponList.SelectedItem = coupons[0];
                    }
                }
            }
        }

        private void Redeem1_Click(object sender, RoutedEventArgs e)
        {
            if (_loggedInAccount.Points > int.Parse(benzyna_on_nagrody_label.Content.ToString()))
            {
                Coupon newCoupon = new Coupon()
                {
                    Name = "BE/ON",
                    Owner = _loggedInAccount.Email
                };
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
                {
                    conn.CreateTable<Coupon>();
                    conn.Insert(newCoupon);
                }

                _loggedInAccount.Points = _loggedInAccount.Points - int.Parse(benzyna_on_nagrody_label.Content.ToString());

                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
                {
                    conn.CreateTable<Konto>();
                    conn.InsertOrReplace(_loggedInAccount);
                }
                
                using (SQLiteConnection conn3 = new SQLiteConnection(App.databasePath))
                {
                    conn3.CreateTable<ProgramLojalnościowy>();
                    prog_prices = (conn3.Table<ProgramLojalnościowy>().FirstOrDefault());

                    benzyna_e95label.Content = prog_prices.benzyna_E95;
                    benzyna_e98label.Content = prog_prices.benzyna_E98;
                    olej_napedowylabel.Content = prog_prices.olej_nepedowy;
                    lpglabel.Content = prog_prices.lpg;
                    benzyna_on_nagrody_label.Content = prog_prices.benzyna_on_nagrody;
                    lpg_nagrody_label.Content = prog_prices.lpg_ngrody;
                    mycie_z_woskiemlabel.Content = prog_prices.mycie_z_woskiem;
                    mycie_standardowelabel.Content = prog_prices.mycie_standardowe;
                    mycie_standardowe_nagrody_label.Content = prog_prices.mycie_standardowe_nagrody;
                    mycie_z_woskiem_nagrody_label.Content = prog_prices.mycie_z_woskiem_nagrody;
                }

                if (_loggedInAccount.Email != null)
                {

                    Konto AccountToUpdate = new Konto();

                    using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
                    {
                        AccountToUpdate = connection.Table<Konto>().FirstOrDefault(a => a.Email == _loggedInAccount.Email);
                    }
                    saldo.Content = AccountToUpdate.Points;

                    List<Coupon> coupons = new List<Coupon>();

                    using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
                    {
                        coupons = connection.Table<Coupon>().Where(n => n.Owner == _loggedInAccount.Email).ToList();
                    }
                    if (coupons != null)
                    {
                        this.CouponList.ItemsSource = coupons;
                        CouponList.SelectedItem = coupons[0];
                    }
                }
            }            
        }

        private void Redeem2_Click(object sender, RoutedEventArgs e)
        {
            if (_loggedInAccount.Points > int.Parse(lpg_nagrody_label.Content.ToString()))
            {
                Coupon newCoupon = new Coupon()
                {
                    Name = "LPG",
                    Owner = _loggedInAccount.Email
                };
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
                {
                    conn.CreateTable<Coupon>();
                    conn.Insert(newCoupon);
                }

                _loggedInAccount.Points = _loggedInAccount.Points - int.Parse(lpg_nagrody_label.Content.ToString());

                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
                {
                    conn.CreateTable<Konto>();
                    conn.InsertOrReplace(_loggedInAccount);
                }

                using (SQLiteConnection conn3 = new SQLiteConnection(App.databasePath))
                {
                    conn3.CreateTable<ProgramLojalnościowy>();
                    prog_prices = (conn3.Table<ProgramLojalnościowy>().FirstOrDefault());

                    benzyna_e95label.Content = prog_prices.benzyna_E95;
                    benzyna_e98label.Content = prog_prices.benzyna_E98;
                    olej_napedowylabel.Content = prog_prices.olej_nepedowy;
                    lpglabel.Content = prog_prices.lpg;
                    benzyna_on_nagrody_label.Content = prog_prices.benzyna_on_nagrody;
                    lpg_nagrody_label.Content = prog_prices.lpg_ngrody;
                    mycie_z_woskiemlabel.Content = prog_prices.mycie_z_woskiem;
                    mycie_standardowelabel.Content = prog_prices.mycie_standardowe;
                    mycie_standardowe_nagrody_label.Content = prog_prices.mycie_standardowe_nagrody;
                    mycie_z_woskiem_nagrody_label.Content = prog_prices.mycie_z_woskiem_nagrody;
                }

                if (_loggedInAccount.Email != null)
                {

                    Konto AccountToUpdate = new Konto();

                    using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
                    {
                        AccountToUpdate = connection.Table<Konto>().FirstOrDefault(a => a.Email == _loggedInAccount.Email);
                    }
                    saldo.Content = AccountToUpdate.Points;

                    List<Coupon> coupons = new List<Coupon>();

                    using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
                    {
                        coupons = connection.Table<Coupon>().Where(n => n.Owner == _loggedInAccount.Email).ToList();
                    }
                    if (coupons != null)
                    {
                        this.CouponList.ItemsSource = coupons;
                        CouponList.SelectedItem = coupons[0];
                    }
                }
            }
        }

        private void Redeem3_Click(object sender, RoutedEventArgs e)
        {
            if (_loggedInAccount.Points > int.Parse(mycie_standardowe_nagrody_label.Content.ToString()))
            {
                Coupon newCoupon = new Coupon()
                {
                    Name = "Mycie Standardowe",
                    Owner = _loggedInAccount.Email
                };
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
                {
                    conn.CreateTable<Coupon>();
                    conn.Insert(newCoupon);
                }

                _loggedInAccount.Points = _loggedInAccount.Points - int.Parse(mycie_standardowe_nagrody_label.Content.ToString());

                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
                {
                    conn.CreateTable<Konto>();
                    conn.InsertOrReplace(_loggedInAccount);
                }

                using (SQLiteConnection conn3 = new SQLiteConnection(App.databasePath))
                {
                    conn3.CreateTable<ProgramLojalnościowy>();
                    prog_prices = (conn3.Table<ProgramLojalnościowy>().FirstOrDefault());

                    benzyna_e95label.Content = prog_prices.benzyna_E95;
                    benzyna_e98label.Content = prog_prices.benzyna_E98;
                    olej_napedowylabel.Content = prog_prices.olej_nepedowy;
                    lpglabel.Content = prog_prices.lpg;
                    benzyna_on_nagrody_label.Content = prog_prices.benzyna_on_nagrody;
                    lpg_nagrody_label.Content = prog_prices.lpg_ngrody;
                    mycie_z_woskiemlabel.Content = prog_prices.mycie_z_woskiem;
                    mycie_standardowelabel.Content = prog_prices.mycie_standardowe;
                    mycie_standardowe_nagrody_label.Content = prog_prices.mycie_standardowe_nagrody;
                    mycie_z_woskiem_nagrody_label.Content = prog_prices.mycie_z_woskiem_nagrody;
                }

                if (_loggedInAccount.Email != null)
                {

                    Konto AccountToUpdate = new Konto();

                    using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
                    {
                        AccountToUpdate = connection.Table<Konto>().FirstOrDefault(a => a.Email == _loggedInAccount.Email);
                    }
                    saldo.Content = AccountToUpdate.Points;

                    List<Coupon> coupons = new List<Coupon>();

                    using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
                    {
                        coupons = connection.Table<Coupon>().Where(n => n.Owner == _loggedInAccount.Email).ToList();
                    }
                    if (coupons != null)
                    {
                        this.CouponList.ItemsSource = coupons;
                        CouponList.SelectedItem = coupons[0];
                    }
                }
            }
        }

        private void Redeem4_Click(object sender, RoutedEventArgs e)
        {
            if (_loggedInAccount.Points > int.Parse(mycie_z_woskiem_nagrody_label.Content.ToString()))
            {
                Coupon newCoupon = new Coupon()
                {
                    Name = "Mycie Woskiem",
                    Owner = _loggedInAccount.Email
                };
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
                {
                    conn.CreateTable<Coupon>();
                    conn.Insert(newCoupon);
                }

                _loggedInAccount.Points = _loggedInAccount.Points - int.Parse(mycie_z_woskiem_nagrody_label.Content.ToString());

                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
                {
                    conn.CreateTable<Konto>();
                    conn.InsertOrReplace(_loggedInAccount);
                }

                using (SQLiteConnection conn3 = new SQLiteConnection(App.databasePath))
                {
                    conn3.CreateTable<ProgramLojalnościowy>();
                    prog_prices = (conn3.Table<ProgramLojalnościowy>().FirstOrDefault());

                    benzyna_e95label.Content = prog_prices.benzyna_E95;
                    benzyna_e98label.Content = prog_prices.benzyna_E98;
                    olej_napedowylabel.Content = prog_prices.olej_nepedowy;
                    lpglabel.Content = prog_prices.lpg;
                    benzyna_on_nagrody_label.Content = prog_prices.benzyna_on_nagrody;
                    lpg_nagrody_label.Content = prog_prices.lpg_ngrody;
                    mycie_z_woskiemlabel.Content = prog_prices.mycie_z_woskiem;
                    mycie_standardowelabel.Content = prog_prices.mycie_standardowe;
                    mycie_standardowe_nagrody_label.Content = prog_prices.mycie_standardowe_nagrody;
                    mycie_z_woskiem_nagrody_label.Content = prog_prices.mycie_z_woskiem_nagrody;
                }

                if (_loggedInAccount.Email != null)
                {

                    Konto AccountToUpdate = new Konto();

                    using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
                    {
                        AccountToUpdate = connection.Table<Konto>().FirstOrDefault(a => a.Email == _loggedInAccount.Email);
                    }
                    saldo.Content = AccountToUpdate.Points;

                    List<Coupon> coupons = new List<Coupon>();

                    using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
                    {
                        coupons = connection.Table<Coupon>().Where(n => n.Owner == _loggedInAccount.Email).ToList();
                    }
                    if (coupons != null)
                    {
                        this.CouponList.ItemsSource = coupons;
                        CouponList.SelectedItem = coupons[0];
                    }
                }
            }
        }

        private void OpenMonitorLog(object sender, RoutedEventArgs e)
        {
            MonitorLog_Window mlw = new MonitorLog_Window(_loggedInAccount);
            this.Close();
            mlw.ShowDialog();
        }

        private void InvoiceListView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
         
        }

        private void updateLoyaltyPoints()
        {
            using (SQLiteConnection conn3 = new SQLiteConnection(App.databasePath))
            {
                conn3.CreateTable<ProgramLojalnościowy>();
                prog_prices = (conn3.Table<ProgramLojalnościowy>().FirstOrDefault());

                benzyna_e95label.Content = prog_prices.benzyna_E95;
                benzyna_e98label.Content = prog_prices.benzyna_E98;
                olej_napedowylabel.Content = prog_prices.olej_nepedowy;
                lpglabel.Content = prog_prices.lpg;
                benzyna_on_nagrody_label.Content = prog_prices.benzyna_on_nagrody;
                lpg_nagrody_label.Content = prog_prices.lpg_ngrody;
                mycie_z_woskiemlabel.Content = prog_prices.mycie_z_woskiem;
                mycie_standardowelabel.Content = prog_prices.mycie_standardowe;
                mycie_standardowe_nagrody_label.Content = prog_prices.mycie_standardowe_nagrody;
                mycie_z_woskiem_nagrody_label.Content = prog_prices.mycie_z_woskiem_nagrody;
            }
        }

        private void BenzynaOnUpdate_Click(object sender, RoutedEventArgs e)
        {
            string command = $"update ProgramLojalnościowy set benzyna_on_nagrody = {this.BenzynaOnTxtBox.Text} ";
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                SQLiteCommand cm = new SQLiteCommand(connection);
                cm.CommandText = command;
                cm.ExecuteNonQuery();
                updateLoyaltyPoints();
                MessageBox.Show("Updated.");
            }
        }

        private void StandardUpdate_Click(object sender, RoutedEventArgs e)
        {
            string command = $"update ProgramLojalnościowy set benzyna_on_nagrody = {this.StandardTxtBox.Text} ";
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                SQLiteCommand cm = new SQLiteCommand(connection);
                cm.CommandText = command;
                cm.ExecuteNonQuery();
                updateLoyaltyPoints();
                MessageBox.Show("Updated.");
            }

        }

        private void WoskenUpdate_Click(object sender, RoutedEventArgs e)
        {
            string command = $"update ProgramLojalnościowy set benzyna_on_nagrody = {this.WoskiemTxtBox.Text} ";
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                SQLiteCommand cm = new SQLiteCommand(connection);
                cm.CommandText = command;
                cm.ExecuteNonQuery();
                updateLoyaltyPoints();
                MessageBox.Show("Updated.");
            }

        }

        private void LPGUpdate_Click(object sender, RoutedEventArgs e)
        {
            string command = $"update ProgramLojalnościowy set benzyna_on_nagrody = {this.LPGTxtBox.Text} ";
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                SQLiteCommand cm = new SQLiteCommand(connection);
                cm.CommandText = command;
                cm.ExecuteNonQuery();
                updateLoyaltyPoints();
                MessageBox.Show("Updated.");
            }

        }
    }
    //okno rejestracji i logowania
    public partial class Login_Window : Window
    {   }
    //okno podglądu danych użytkownika
    public partial class My_Data_Window : Window
    {   }
    //okno dostaw
    public partial class Deliveries_Window : Window
    {   }
    //okno rezerwacji myjni
    public partial class Booking_Window : Window
    {    }
    //okno zarządzania pracownikami
    public partial class Employess_Window : Window
    {
        public void add_new_employee_button(object sender, RoutedEventArgs e)
        {
            Add_New_Employee_Window add_new_employee_window = new Add_New_Employee_Window();
            add_new_employee_window.Owner = this;
            add_new_employee_window.Show();
        }
    }
    //okno zarządzania klientami
    public partial class Customers_Window : Window
    {
        public void add_new_customer_button(object sender, RoutedEventArgs e)
        {
            Add_New_Customer_Window add_new_customer_window = new Add_New_Customer_Window();           
            add_new_customer_window.Owner = this;
            add_new_customer_window.Show();
        }
    }
    //okno faktur
    public partial class Invoices_Window : Window
    {   }
    //okno monitoringu
    public partial class Monitoring_Window : Window
    {    }
    //okno dodawania nowego klienta
    public partial class Add_New_Customer_Window : Window
    {   }
    //okno dodawania nowego klienta
    public partial class Add_New_Employee_Window : Window
    {    }
    //okno modyfikacji danych
    public partial class Modify_Window : Window
    {    }
    //okno modyfikacji cen
    public partial class Modify_prices : Window
    {    }
    //okno modyfikacji programu lojalnościowego
    public partial class Modify_loyalty_window : Window
    {    }
    //okno tankowania
    public partial class Tankowanie_Window : Window
    {    }
    //okno mycia
    public partial class Mycie_Window : Window
    {    }
}

