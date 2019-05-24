using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacjaBenzynowa
{
    public class Informacje
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Wlasciciel { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Fax { get; set; }
        public string Kasjerzy { get; set; }
        public string Monitoring { get; set; }
        public string Myjnia { get; set; }
        public string ObslugaLPG { get; set; }
    }
}
