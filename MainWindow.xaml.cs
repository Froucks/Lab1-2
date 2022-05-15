using Lab1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OxyPlot;
using OxyPlot.Series;

namespace Lab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void DefaultValues(object sender, RoutedEventArgs e)
        {
            SplitNumber.Text = 1000.ToString();
            TopLimit.Text = 2.ToString();
            BottomLimit.Text = 1.ToString();
        }
        private void BuildGraphic(object sender, RoutedEventArgs e)
        {
            var pm = new PlotModel()
            {
                Title = " 11x - ln(11x) - 2 "
            };
            var lineSeries = new LineSeries();

            int upLim = Convert.ToInt32(TopLimit.Text);
            int lowLim = Convert.ToInt32(BottomLimit.Text);
            ICalculator calcultGraph = new SimpsonMethod();

            for (int i = 1; i < 1000; i++)
            {
                double time;
                double result = calcultGraph.Calculate(i, lowLim, upLim, x => (11 * x) - Math.Log(11 * x) - 2, out time);
                lineSeries.Points.Add(new DataPoint(i, time));
            }

            pm.Series.Add(lineSeries);
            Graph.Model = pm;
        }
        private ICalculator GetMethod()
        {
            return methods.SelectedIndex switch
            {
                0 => new SimpsonMethod(),
                1 => new TrapezoidalMethod(),
                _ => throw new NotImplementedException(),
            };
        }
        private void StartCalculate(object sender, RoutedEventArgs e)
        {
            stCalculate();
        }
        private void stCalculate()
        {
            int splits = Convert.ToInt32(SplitNumber.Text);
            double upLim = Convert.ToInt32(TopLimit.Text);
            double lowLim = Convert.ToInt32(BottomLimit.Text);
            double time;

            ICalculator calcult = GetMethod();
            double result = calcult.Calculate(splits, lowLim, upLim, x => (11 * x) - Math.Log(11 * x) - 2, out time);
            _ = MessageBox.Show(Convert.ToString(result)+"\n Время "+time.ToString()+"мс", "ResULt", MessageBoxButton.OK, MessageBoxImage.Asterisk);

            Result.Text = result.ToString();
        }
    }
}
