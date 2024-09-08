using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarativeProgramming
{
    public class Calculator
    {
        private double x; 
        
        private double y;

        public Calculator(double x1, double y1)
        {
            x = x1;
            y = y1;
        }


        // 🚩 Reads x,y from state
        //=============================
        public double GetZ(double v)
        {
            double z;

            if (x > 10)
                z = (x + y) / 2 + v;
            else
                z = (x - y) / 2 - v;

            return z;
        }

        // 🚩 Writes to state
        //=========================

        // 🚩 Reads y , Writes to x
        public void UpdateX(double v)
        {
            x = y + 2 * v;
        }

        // 🚩 Reads x , Writes to y
        public void UpdateY(double v)
        {
            y = x - 2 * v;
        }
    }
}
