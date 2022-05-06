using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Lab1.Classes
{// 11x - ln(11x) - 2 
    public class TrapezoidalMethod : ICalculator
    {
        double ICalculator.Calculate(int SplitNumbers, double LowLim, double UpLim, Func<double, double> integral, out double time)
        {
            Stopwatch tn = new Stopwatch();
            tn.Start();
            if (SplitNumbers < 1)
            {
                throw new ArgumentException("Неправильное количество разбиений");
            }
            bool j = false;
            if (LowLim > UpLim)
            {
                double ttt = LowLim;
                LowLim = UpLim;
                UpLim = ttt;
                j = true;
            }
            double h = (UpLim - LowLim) / SplitNumbers;
            double sum = 0.0;

            for (int i = 0; i < SplitNumbers; i++)
            {
                sum += integral(LowLim + h * i);
            }
            tn.Stop();
            TimeSpan tk = tn.Elapsed;
            time = tk.TotalMilliseconds;
            if (j)
            {
                return -(h * ((integral(LowLim) + integral(UpLim)) / 2 + sum)); ;
            }
            return h * ((integral(LowLim) + integral(UpLim)) / 2 + sum);
        }
    }
}
