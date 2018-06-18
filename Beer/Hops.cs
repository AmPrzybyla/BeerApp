using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beer
{
    public class Hops
    {

        public string NameOfHop { get; set; }
        public int WeightOfHop { get; set; }
        public double AlphaAcidsOfHop { get; set; }
        public int TimeOfBoiling { get; set; }

        public double Ibu { get; set; }
        public double[] Utilization = new double[76] { 5, 5.11, 5.22, 5.33, 5.44, 5.56, 5.67, 5.78, 5.89, 6, 7.50, 9, 10.50, 12, 13.50, 15, 15.40, 15.80, 16.20, 16.60, 17, 17.40, 17.80, 18.20, 18.60, 19, 19.42, 19.83, 20.25, 20.67, 21.08, 21.50, 21.92, 22.33, 22.75, 23.17, 23.58, 24, 24.20, 24.40, 24.60, 24.80, 25, 25.20, 25.40, 25.60, 25.80, 26, 26.20, 26.40, 26.60, 26.80, 27, 27.38, 27.75, 28.13, 28.50, 28.88, 29.25, 29.63, 30, 30.27, 30.53, 30.80, 31.07, 31.33, 31.60, 31.87, 32.13, 32.40, 32.67, 32.93, 33.20, 33.47, 33.73, 34 };




    }
}
