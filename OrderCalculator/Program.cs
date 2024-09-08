namespace OrderCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var orders = new List<Order>
            {
                new Order { Id = 1, Amount = 20000, Discount = 0},
                new Order { Id = 2, Amount = 30000, Discount = 0},
                new Order { Id = 3, Amount = 40000, Discount = 0},
                new Order { Id = 4, Amount = 50000, Discount = 0},
                new Order { Id = 5, Amount = 60000, Discount = 0},
                new Order { Id = 6, Amount = 70000, Discount = 0},
            };

            var orderCalculator = new OrderCalculator();

            var ordersWithDiscounts = orderCalculator.FindOrdersWithDiscount(orders);
        }
    }

}
