using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInvoiceGeneretor
{
    public class InvoiceSummary
    {
        private int numberofRides;
        private double totalfare;
        private double averagefare;
        public InvoiceSummary(int numberofRides,double totalfare)
        {
            this.numberofRides = numberofRides;
            this.totalfare = totalfare;
            this.averagefare = this.totalfare / this.numberofRides;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is InvoiceSummary)) return false;
            InvoiceSummary inputobj = (InvoiceSummary)obj;
            return this.numberofRides == inputobj.numberofRides && this.totalfare == inputobj.totalfare && this.averagefare == inputobj.averagefare;
        }
        public override int GetHashCode()
        {
            return this.numberofRides.GetHashCode() ^ this.totalfare.GetHashCode() ^ this.averagefare.GetHashCode();
        }
    }
}
