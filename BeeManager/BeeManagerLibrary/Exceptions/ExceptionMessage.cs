using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeManagerLibrary.Exceptions
{
    public static class ExceptionMessage
    {
        public static string ProductNotFound(int id)
        {
            return $"Product with ID number: {id} not found.";
        }

        public static string ProductNameIsNullOrWhiteSpace()
        {
            return $"Entered string of productName is null, empty or white space.";
        }

        public static string MeasurementUnitNotFound(int id)
        {
            return $"Measurement unit with ID number: {id} not found.";
        }

        public static string MeasurementUnitNameIsNullOrWhiteSpace()
        {
            return $"Entered string of measurement unit is null, empty or white space.";
        }

        public static string ProductionRecordNotFound(int id)
        {
            return $"Production record with ID number: {id} not found.";
        }
    }
}
