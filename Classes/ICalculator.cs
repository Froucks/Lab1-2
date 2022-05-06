using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Classes
{
    public interface ICalculator
    {
        public double Calculate(int SplitNumbers, double LowLim, double UpLim, Func<double, double> integral, out double time);
    }
}
