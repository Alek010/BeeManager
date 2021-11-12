using System;
using System.ComponentModel.DataAnnotations;

namespace BeeManagerMVC.Models
{
    public class ProductionModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        public string Product { get; set; }
        [Required]
        [Range(1, 9999999999999999.99, ErrorMessage = "The value should larger than 0 and Max 18 digits")]
        public double Quantity { get; set; }
        [Required]
        public string Units { get; set; }
    }
}
