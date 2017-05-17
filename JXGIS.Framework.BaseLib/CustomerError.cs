using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXGIS.Framework.BaseLib
{
    public class CustomerException : System.Exception
    {
        public CustomerException() : base() { }

        public CustomerException(string message) : base(message) { }

        public CustomerException(string message, Exception innerException) : base(message, innerException) { }
    }
}
