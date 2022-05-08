using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlSystem
{
    public class Filter
    {
        public double yk;
        public double Ts;
        public double Tf;
        public double LowPassFilter(double yFromDaq)
        {
            double a;
            double yFiltered;
            a = Ts / (Ts + Tf);
            yFiltered = (1 - a) * yk + a * yFromDaq;
            yk = yFiltered;
            return yFiltered;
        }
    }
}
