using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BeeManagerMVC.Models
{
    public class ProductionSummaryViewModel
    {
        public List<ProductionSummaryModel> ProductionSummary { get; set; }
        public SelectList Products { get; set; }
        public SelectList Years { get; set; }
        public string ProductName { get; set; }
        public string Year { get; set; }
    }
}
