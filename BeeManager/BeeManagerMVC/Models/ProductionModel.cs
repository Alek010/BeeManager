using System;
using System.ComponentModel.DataAnnotations;

namespace BeeManagerMVC.Models
{
    public class ProductionModel
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Product { get; set; }
        public double Quantity { get; set; }
        public string Units { get; set; }
    }
}
