using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInvoiceGeneretor
{
    public class CabInvoiceException : Exception
    {
        public enum  ExceptionType
        {
            INVALIDE_RIDE_TYPE,
            INAVALIDE_DISTANCE,
            INVALIDE_TIEME,
            NULL_RIDE,
            INVALIDE_USERID
        }
        ExceptionType type;
        //constructor for thorwing exception type and thorwing exceptio
        public CabInvoiceException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}

