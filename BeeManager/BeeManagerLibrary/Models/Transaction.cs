using System;

namespace BeeManagerLibrary.Models
{
    public class Transaction : BaseEntity
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
