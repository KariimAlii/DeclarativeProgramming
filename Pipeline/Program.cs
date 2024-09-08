using System.Threading.Channels;

namespace Pipeline
{
    internal class Program
    {
        private static List<double> MyData = new List<double>() { 7, 4, 5, 6, 3, 8, 10};
        static void Main(string[] args)
        {
            #region Imperativ
            Console.WriteLine("Imperative way of doing things");

            //// x   --- Add One() --- Square() --- Subtract Ten() --->
            //foreach (var x in MyData)
            //{
            //    Console.WriteLine(SubtractTen(Square(AddOne(x))));
            //}


            // 1- Add One and Square
            // 2- Filter by Numbers < 70 after 
            // 3- Subtract Ten

            //List<double> data = new List<double>();
            //foreach (var x in MyData)
            //{
            //    var z = Square(AddOne(x));
            //    if (z < 20)
            //    {
            //        z = SubtractTen(z);
            //        data.Add(z);
            //    }
            //}

            //foreach (var z in data)
            //{
            //    Console.WriteLine(z);
            //}
            #endregion

            #region Declarative
            Console.WriteLine("Declarative way of doing things");

            // x   --- Add One() --- Square() --- Subtract Ten() --->
            //MyData
            //    .Select(AddOne)
            //    .Select(Square)
            //    .Select(SubtractTen)
            //    .ToList()
            //    .ForEach(x => Console.WriteLine(x));


            // 1- Add One and Square
            // 2- Filter by Numbers < 70 after 
            // 3- Subtract Ten

            MyData
               .Select(AddOne)
               .Select(Square)
               .Where(x => x < 20)
               .Select(SubtractTen)
               .ToList()
               .ForEach(x => Console.WriteLine(x));

            // 1- Add One and Square
            // 2- Filter by Numbers < 70 after 
            // 3- Only pass the the smallest 2 numbers
            // 4- Subtract Ten

            MyData
               .Select(AddOne)
               .Select(Square)
               .Where(x => x < 70)
               .OrderBy(x => x)
               .Take(2)
               .Select(SubtractTen)
               .ToList()
               .ForEach(x => Console.WriteLine(x));
            #endregion
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
    }

}
