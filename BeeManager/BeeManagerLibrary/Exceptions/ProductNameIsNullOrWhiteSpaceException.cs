using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BeeManagerLibrary.Exceptions
{
    public class ProductNameIsNullOrWhiteSpaceException : Exception
    {
        public ProductNameIsNullOrWhiteSpaceException()
        {
        }

        public ProductNameIsNullOrWhiteSpaceException(string message) : base(message)
        {
        }

        public ProductNameIsNullOrWhiteSpaceException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
