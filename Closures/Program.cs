using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace Closures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 🚩🚩 Closure
            // ===================

            // 1. Encapsulation for Functional Programming
            // 2. Function with State
            // 3. Function Factory
            // 4. Object with single method

            // 🚩🚩 What do we get when use Closure
            // ========================================

            // 1. Less possibility of bugs due to inconsistent inputs
            // 2. Reduce Function input parameters


            var Q10 = Test(10); //  🚩🚩 (double a) => a + 20 🚩🚩
            Console.WriteLine(Q10(4));
            Console.WriteLine(Q10(8));

            var Q20 = Test(20); //  🚩🚩 (double a) => a + 30 🚩🚩
            Console.WriteLine(Q20(4));
            Console.WriteLine(Q20(8));


            // 🚩🚩 Generate a function that calculates gross salary for junior developers ( closing over basic salary and tax )

            var juniorDeveloperGrossSalaryCalculator = GrossSalaryCalculatorFactory(15000);

            // 🚩🚩 You can use it many times for different juniors with different bonus
            var juniorDeveloperGrossSalary1 = juniorDeveloperGrossSalaryCalculator(2000);
            var juniorDeveloperGrossSalary2 = juniorDeveloperGrossSalaryCalculator(1500);
            var juniorDeveloperGrossSalary3 = juniorDeveloperGrossSalaryCalculator(2500);

            List<(string Segment, double BasicSalary)> segmentsWithBasicSalary = new List<(string Segment, double BasicSalary)>
            {
                ("Junior",15000),
                ("Mid"   ,20000),
                ("Senior",30000)
            };

            var grossSalaryCalculators = segmentsWithBasicSalary
                .Select(x => (Id: x.Segment, GrossSalaryCalculator: GrossSalaryCalculatorFactory(x.BasicSalary)))
                .ToList();

            var grossSalary1_Junior = grossSalaryCalculators
                .FirstOrDefault(calculator => calculator.Id == "Junior")
                .GrossSalaryCalculator(1500);
            var grossSalary2_Junior = grossSalaryCalculators
                .FirstOrDefault(calculator => calculator.Id == "Junior")
                .GrossSalaryCalculator(2500);


            var grossSalary1_Senior = grossSalaryCalculators
                .FirstOrDefault(calculator => calculator.Id == "Senior")
                .GrossSalaryCalculator(1500);
            var grossSalary2_Senior = grossSalaryCalculators
                .FirstOrDefault(calculator => calculator.Id == "Senior")
                .GrossSalaryCalculator(2500);

        }
        public static Func<double, double> Test(double x)
        {
            Console.WriteLine("I am here " + x);

            var x1 = x + 10;

            return (double a) => a + x1;
        }

        // { basicSalary , tax , bonus }  ------------------------->  GrossSalary 
        // { bonus }                      --{ basicSalary , tax }-->  GrossSalary 
        public static Func<double, double> GrossSalaryCalculatorFactory(double basicSalary)
        {
            var tax = 0.2 * basicSalary;

            return (double bonus) => basicSalary + tax + bonus;
        }
    }


    // 🚩🚩 Object with single method
    public class Test
    {
        public double x1; // State

        // Impure Function ==> depends on State
        public double Calculate(double a)
        {
            return a + x1;
        }
    }


}
