using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCalculator
{
    internal class OrderCalculator
    {
        
        public List<Order> FindOrdersWithDiscount(List<Order> orders)
        {
            var rules = GetDiscountRules();
            var ordersWithDiscount = orders
                .Select(order => order.GetOrderWithDiscount(rules))
                .ToList();
            return ordersWithDiscount;

        }
        #region Predicates
        public static bool IsAQualified(Order order) => order.Amount >= 3000;
        public static bool IsBQualified(Order order) => order.Amount >= 4000;
        public static bool IsCQualified(Order order) => order.Amount >= 5000; 
        #endregion
        #region Calculators
        public static double A(Order order) => order.Amount * 0.1;
        public static double B(Order order) => order.Amount * 0.2;
        public static double C(Order order) => order.Amount * 0.3;
        #endregion
        #region Rules
        public List<(Func<Order, bool> predicate, Func<Order, double> calculator)> GetDiscountRules()
        {
            return new List<(Func<Order, bool> predicate, Func<Order, double>)>
            {
                (IsAQualified, A),
                (IsBQualified, B),
                (IsCQualified, C),
            };
        } 
        #endregion
    }
    public class Order
    {
        public int Id;
        public double Amount;
        public double Discount;
    }
    public static class OrderExtensions
    {
        public static Order GetOrderWithDiscount(this Order order, List<(Func<Order, bool> predicate, Func<Order, double> calculator)> rules)
        {
            var discount = rules
                .Where(rule => rule.predicate(order))
                .Select(rule => rule.calculator(order))
                .OrderBy(x => x)
                .Take(2)
                .Average();

            order.Discount = discount;

            return order;
        }
    }
}
