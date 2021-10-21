using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM_ConsoleUI
{
    public class Production
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public int UnitsOfMeasurementId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Products { get; set; }
        [ForeignKey("UnitsOfMeasurementId")]
        public virtual UnitsOfMeasurement Units { get; set; }
    }
}
