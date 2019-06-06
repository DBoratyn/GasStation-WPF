using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace StacjaBenzynowa.Models
{
    class MonitorLog
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        public double BenzynaE95_T { get; set; }
        public double BenzynaE98_T { get; set; }
        public double OlejNapeowy_T { get; set; }
        public double LPG_T { get; set; }

        public double BenzynaE95_P { get; set; }
        public double BenzynaE98_P { get; set; }
        public double OlejNapeowy_P { get; set; }
        public double LPG_P { get; set; }
    }
}
