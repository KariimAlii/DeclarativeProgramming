using CompositionExample.Implementations;
using CompositionExample.Models;
using System;

namespace CompositionExample
{
    internal class Program
    {
        public static Func<Order, ShippingDate> AvailabilityPathFunc(AvailabilityPath availabilityPath, SystemConfiguration config) =>
            availabilityPath.OrderToAvailability_Fns[config.OrderToAvailability_Fn]
                .Compose(availabilityPath.AvailabilityToShippingDate_Fns[config.AvailabilityToShippingDate_Fn]);


        public static Func<Order, FreightCost> InvoicingPathFunc(InvoicingPath invoicingPath, SystemConfiguration config) =>
            invoicingPath.OrderToInvoice_Fns[config.OrderToInvoice_Fn]
                .Compose(invoicingPath.InvoiceToShipping_Fns[config.InvoiceToShipping_Fn])
                .Compose(invoicingPath.ShippingToFreightCost_Fns[config.ShippingToFreightCost_Fn]);

        public static double AdjustCost(Order order, Func<Order, FreightCost> orderToFreightCost_Fn, Func<Order, ShippingDate> orderToShippingDate_Fn)
        {
            return orderToFreightCost_Fn(order).Value + 0.2 * (DateTime.Now - orderToShippingDate_Fn(order).Value).TotalHours;
        }
        public static Func<Order, double> CalcAdjustedCostForOrder(AvailabilityPath availabilityPath, InvoicingPath invoicingPath, SystemConfiguration config)
        {
            return order => AdjustCost(order, InvoicingPathFunc(invoicingPath, config), AvailabilityPathFunc(availabilityPath, config));
        }
        static void Main(string[] args)
        {
            InvoicingPath invoicingPath = new InvoicingPath();
            AvailabilityPath availabilityPath = new AvailabilityPath();
            SystemConfiguration configuration = new SystemConfiguration();
            Order order = new Order 
            { 
                Id = 1,
                Date = DateTime.Now,
                Items = new List<Item>
                {
                    new Item { Id = 1, Amount = 5, UnitPrice = 50_000},
                    new Item { Id = 2, Amount = 6, UnitPrice = 100_000},
                }
            };

            Func<Order, Double> costOfOrder = CalcAdjustedCostForOrder(availabilityPath, invoicingPath, configuration);

            var cost = costOfOrder(order);
        }
    }
    public static class FunctionExtension
    {
        public static Func<T1, T3> Compose<T1, T2, T3>(this Func<T1, T2> f1, Func<T2, T3> f2)
        {
            return x => f2(f1(x));
        }
    }
}
