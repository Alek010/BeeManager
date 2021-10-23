using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM_ConsoleUI
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TypeId { get; set; }
        public int ObjectId { get; set; }
        public double Quantity { get; set; }
        public int UnitOfMeasurementId { get; set; }
        public double PricePerUnit { get; set; }
        public string Description { get; set; }
    }
}
