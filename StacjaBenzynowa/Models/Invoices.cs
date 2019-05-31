using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace StacjaBenzynowa.Models
{
    class Invoices
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string email { get; set; }
        public string CouponUsed { get; set; }
        public string Nazwa_firmy { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Miasto { get; set; }
        public string Ulica { get; set; }
        public string Kod_pocztowy { get; set; }
        public string Numer { get; set; }
        public double BenzynaE95 { get; set; }
        public double BenzynaE98 { get; set; }
        public double OlejNapowy { get; set; }
        public double LPG { get; set; }
        public double Standardowe { get; set; }
        public double Zwoskiem { get; set; }
        public double TotalPrice { get; set; }
    }
}
