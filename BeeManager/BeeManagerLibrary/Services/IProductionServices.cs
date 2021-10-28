using BeeManagerLibrary.Models;
using System.Collections.Generic;

namespace BeeManagerLibrary.Services
{
    public interface IProductionServices
    {
        List<Production> GetProductionList();

    }
}