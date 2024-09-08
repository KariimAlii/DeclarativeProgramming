using CompositionExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositionExample
{
    public class SystemConfiguration
    {
        public int OrderToInvoice_Fn { get; set; }
        public int InvoiceToShipping_Fn { get; set; }
        public int ShippingToFreightCost_Fn { get; set; }
        public int OrderToAvailability_Fn { get; set; }
        public int AvailabilityToShippingDate_Fn { get; set; }
    }
}
