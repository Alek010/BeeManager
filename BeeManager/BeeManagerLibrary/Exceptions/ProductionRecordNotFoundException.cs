using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BeeManagerLibrary.Exceptions
{
    public class ProductionRecordNotFoundException : Exception
    {
        public ProductionRecordNotFoundException()
        {
        }

        public ProductionRecordNotFoundException(string message) : base(message)
        {
        }

        public ProductionRecordNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
