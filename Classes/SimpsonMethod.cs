using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace Lab1.Classes
{  // 2x - ln(11x) - 1 
    public class SimpsonMethod : ICalculator
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
                sum += integral(LowLim + h * i) + 2 * integral(LowLim + i * h + h / 2);
            }
            tn.Stop();
            TimeSpan tk = tn.Elapsed;
            time = tk.TotalMilliseconds;
            if (j)
            {
                return -(h / 3 * ((integral(UpLim) - integral(LowLim)) / 2 + sum));
            }
            return h / 3 * ((integral(UpLim) - integral(LowLim)) / 2 + sum);
        }
    }
}
