using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace StacjaBenzynowa.Models
{
    class Data
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FuelName { get; set; }
        public int Litres { get; set; }
        public int Temperature { get; set; }
        public int Pressure { get; set; }
    }
}
