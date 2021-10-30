using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeeManagerMVC.Models
{
    public class ProductionModel
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Product { get; set; }
        public double Quantity { get; set; }
        public string Units { get; set; }
    }
}
