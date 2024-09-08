namespace HigherOrderFunctions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 🚩🚩 Delegate is a Strongly Typed Function Pointer
            // 🚩🚩 Delegate ----points to---> Function

            //Func<double, double> DlgtTest1 = Test1;
            //Func<double, double> DlgtTest2 = Test2;

            //// 🚩🚩 Delegate is treated like 🚀Data🚀
            
            //List<Func<double, double>> myDelegates = new List<Func<double, double>>
            //{
            //    DlgtTest1, 
            //    DlgtTest2
            //};

            //// 🚩🚩 Normal Function Call
            //Console.WriteLine(Test2(Test1(5)));
            //Console.WriteLine(Test1(Test2(5)));

            //// 🚩🚩 Invokation through Delegates
            //Console.WriteLine(myDelegates[1](myDelegates[0](5)));
            //Console.WriteLine(myDelegates[0](myDelegates[1](5)));


            //Console.WriteLine(Test3(myDelegates[0], 5));
            //Console.WriteLine(Test3(myDelegates[1], 5));

            var productType = ProductType.RawMaterial;

            var order = new Order { OrderId = 1, ProductIndex = 5, Quantity = 5, UnitPrice = 10 };

            Func<int, (double x1, double x2)> findParameterFunction = FindParameterFunction(productType);

            var discount = CalculateDiscount(findParameterFunction, order);

        }
        public static double Test1(double x)
        {
            return x / 2;
        }
        public static double Test2(double x)
        {
            return x / 4 + 1;
        }

        // 🚩🚩 Test3 is a higher order function 🚀 accepts a function(delegate) as a parameter 🚀
        public static double Test3(Func<double, double> fn, double x)
        {
            return fn(x) + x;
        }

        public static double CalculateDiscount(Func<int, (double x1, double x2)> fn, Order order)
        {
            (double x1, double x2) parameters = fn(order.ProductIndex);

            return parameters.x1 * order.Quantity + parameters.x2 * order.UnitPrice;
        }
        public static Func<int , (double x1, double x2)> FindParameterFunction(ProductType productType)
        {
            return 
                productType is ProductType.Food
                ? ProductParametersFood
                : productType is ProductType.Beverage
                ? ProductParametersBeverage
                : ProductParametersRawMaterial;
        }


        // 🚩🚩 ProductIndex   ---according to 🚀ProductType🚀---->   (double x1, double x2)
        public static (double x1, double x2) ProductParametersFood(int ProductIndex)
        {
            return (x1: ProductIndex / (double)(ProductIndex + 100), x2: ProductIndex / (double)(ProductIndex + 300));
        }
        public static (double x1, double x2) ProductParametersBeverage(int ProductIndex)
        {
            return (x1: ProductIndex / (double)(ProductIndex + 300), x2: ProductIndex / (double)(ProductIndex + 400));
        }
        public static (double x1, double x2) ProductParametersRawMaterial(int ProductIndex)
        {
            return (x1: ProductIndex / (double)(ProductIndex + 400), x2: ProductIndex / (double)(ProductIndex + 700));
        }
    }
    public enum ProductType
    {
        Food,
        Beverage,
        RawMaterial
    }
    public class Order
    {
        public int OrderId { get; set; }
        public int ProductIndex { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
    }
}
