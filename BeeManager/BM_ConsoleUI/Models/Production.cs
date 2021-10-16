using System;
using System.Collections.Generic;
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

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<UnitsOfMeasurement> Units { get; set; }
    }
}
