using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeeManagerMVC.Models
{
    public class ProductionViewModel
    {
        public List<ProductionModel> Production { get; set; }
        public SelectList Years { get; set; }
        public string Year { get; set; }
    }
}
