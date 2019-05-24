using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StacjaBenzynowa.Models
{
    //public enum Roles { Admin, Staff, Security, Customer};
    public class Konto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nazwa_firmy { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Pesel { get; set; }
        public string Regon { get; set; }
        public string Nip { get; set; }
        public string Ulica { get; set; }
        public string Numer { get; set; }
        public string Kod_pocztowy { get; set; }
        public string Miasto { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Haslo { get; set; }
        public string Role { get; set; }
    }
}