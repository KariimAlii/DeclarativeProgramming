using CompositionExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositionExample.Implementations
{
    public class AvailabilityPath
    {
        public List<Func<Order, Availability>> OrderToAvailability_Fns = new List<Func<Order, Availability>>()
        {
            order => new Availability { WarehouseId = 1, AvailableDate = DateTime.Now },
            order => new Availability { WarehouseId = 2, AvailableDate = DateTime.Now +  TimeSpan.FromDays(1) },
            order => new Availability { WarehouseId = 3, AvailableDate = DateTime.Now +  TimeSpan.FromDays(2) },
        };
        public List<Func<Availability, ShippingDate>> AvailabilityToShippingDate_Fns = new List<Func<Availability, ShippingDate>>()
        {
            availability => new ShippingDate { Value = availability.AvailableDate },
            availability => new ShippingDate { Value = availability.AvailableDate +  TimeSpan.FromDays(1) },
            availability => new ShippingDate { Value = availability.AvailableDate +  TimeSpan.FromDays(2) },
        };
    }
}
