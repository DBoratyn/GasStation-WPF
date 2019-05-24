using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacjaBenzynowa
{ 
    public class Cennik
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public double Benzyna_E95 { get; set; }
        public double Benzyna_E98 { get; set; }
        public double Olej_napedowy_ON { get; set; }
        public double LPG { get; set; }
        public double Mycie_standardowe { get; set; }
        public double Mycie_z_woskiem { get; set; }

    }
}
