using CompositionExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositionExample.Implementations
{
    public class InvoicingPath
    {
        public List<Func<Order, Invoice>> OrderToInvoice_Fns = new List<Func<Order, Invoice>>()
        {
            order => new Invoice { Id = order.Id, Amount = order.Items.Sum(item => item.UnitPrice * item.Amount), Date = order.Date },
            order => new Invoice { Id = order.Id, Amount = order.Items.Sum(item => item.UnitPrice * 2 * item.Amount), Date = order.Date },
            order => new Invoice { Id = order.Id, Amount = order.Items.Sum(item => item.UnitPrice * 3 * item.Amount), Date = order.Date },
        };
        public List<Func<Invoice, Shipping>> InvoiceToShipping_Fns = new List<Func<Invoice, Shipping>>()
        {
            invoice => new Shipping { Id = invoice.Id, Amount = invoice.Amount, Duration =  DateTime.Now - invoice.Date },
            invoice => new Shipping { Id = invoice.Id, Amount = invoice.Amount * 2, Duration =  DateTime.Now - invoice.Date + TimeSpan.FromDays(1) },
            invoice => new Shipping { Id = invoice.Id, Amount = invoice.Amount * 3, Duration =  DateTime.Now - invoice.Date + TimeSpan.FromDays(2) },
        };
        public List<Func<Shipping, FreightCost>> ShippingToFreightCost_Fns = new List<Func<Shipping, FreightCost>>()
        {
            shipping => new FreightCost { Value = shipping.Amount },
            shipping => new FreightCost { Value = shipping.Amount * 1 },
            shipping => new FreightCost { Value = shipping.Amount * 2 },
        };
    }
}
