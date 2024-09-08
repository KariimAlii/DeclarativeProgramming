using System.Xml.Linq;

namespace FunctionComposition
{
    internal class Program
    {
        private static List<double> MyData = new List<double>() { 3, 5, 7, 8 };

        //private static Func<double, double> MyComposedFunction = ComposeFunction(AddOne, Square, SubtractTen);
        //private static Func<double, double> MyComposedFunction = GetComposedFn();
        private static Func<double, double> MyComposedFunction = ((Func<double, double>)AddOne).Compose(Square).Compose(SubtractTen);


        static void Main(string[] args)
        {
            //Func<double, double> myFunctionTest = Test();
            //Console.WriteLine(myFunctionTest(4));
            MyData
               .Select(AddOne)
               .Select(Square)
               .Select(SubtractTen)
               .ToList()
               .ForEach(x => Console.WriteLine(x));

            Console.WriteLine("====================================================");

            MyData
               .Select(x => SubtractTen(Square(AddOne(x))))
               .ToList()
               .ForEach(x => Console.WriteLine(x));

            Console.WriteLine("====================================================");

            MyData
               .Select(MyComposedFunction)
               .ToList()
               .ForEach(x => Console.WriteLine(x));

            Console.WriteLine("====================================================");

            MyData
               .Select(GetComposedFn())
               .ToList()
               .ForEach(x => Console.WriteLine(x));
        }
        public static Func<double, double> Test() 
        {
            return x => x + 1;
        }
        public static double SubtractTen(double x)
        {
            return x - 10;
        }
        public static double Square(double x)
        {
            return x * x;
        }
        public static double AddOne(double x)
        {
            return x + 1;
        }

        public static Func<double, double> ComposeFunction(Func<double, double> f1, Func<double, double> f2, Func<double, double> f3)
        {
            return x => f3(f2(f1(x)));
        }
        public static Func<double,double> GetComposedFn()
        {
            //return x => SubtractTen(Square(AddOne(x)));


            Func<double, double> f1 = AddOne;
            Func<double, double> f2 = Square;
            Func<double, double> f3 = SubtractTen;
            return f1.Compose(f2).Compose(f3);

            //return ((Func<double, double>)AddOne).Compose(Square).Compose(SubtractTen);
        }
    }
    public static class FunctionExtensions
    {
        public static Func<T1, T3> Compose<T1, T2, T3>(this Func<T1, T2> f1, Func<T2, T3> f2)
        {
            return x => f2(f1(x));
        }
    }
}
