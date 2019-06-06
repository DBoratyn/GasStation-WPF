using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace StacjaBenzynowa.Models
{
    class Deliveries
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public double Benzyna_E95 { get; set; }
        public double Benzyna_E98 { get; set; }
        public double Olej_napedowy_ON { get; set; }
        public double LPG { get; set; }
    }
}
