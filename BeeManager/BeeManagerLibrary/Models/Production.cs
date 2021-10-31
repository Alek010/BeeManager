using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeeManagerLibrary.Models
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
