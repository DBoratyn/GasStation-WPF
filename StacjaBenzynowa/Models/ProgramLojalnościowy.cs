using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace StacjaBenzynowa.Models
{
    public class ProgramLojalnościowy
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public double benzyna_E95 { get; set; }
        public double benzyna_E98 { get; set; }
        public double benzyna_on_nagrody { get; set; }
        public double olej_nepedowy { get; set; }
        public double lpg { get; set; }
        public double lpg_ngrody { get; set; }
        public double mycie_standardowe { get; set; }
        public double mycie_standardowe_nagrody { get; set; }
        public double mycie_z_woskiem { get; set; }
        public double mycie_z_woskiem_nagrody { get; set; }

    }
}