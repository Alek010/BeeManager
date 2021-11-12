using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BeeManagerLibrary.Exceptions
{
    public class MeasurementUnitNotFoundException : Exception
    {
        public MeasurementUnitNotFoundException()
        {
        }

        public MeasurementUnitNotFoundException(string message) : base(message)
        {
        }

        public MeasurementUnitNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
