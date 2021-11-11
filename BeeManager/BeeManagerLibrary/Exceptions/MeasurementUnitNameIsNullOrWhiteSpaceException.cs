using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BeeManagerLibrary.Exceptions
{
    public class MeasurementUnitNameIsNullOrWhiteSpaceException : Exception
    {
        public MeasurementUnitNameIsNullOrWhiteSpaceException()
        {
        }

        public MeasurementUnitNameIsNullOrWhiteSpaceException(string message) : base(message)
        {
        }

        public MeasurementUnitNameIsNullOrWhiteSpaceException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
