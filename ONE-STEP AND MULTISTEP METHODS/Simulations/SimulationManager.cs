using OxyPlot;
using OxyPlot.Series;
using ONE_STEP_AND_MULTISTEP_METHODS.Methods.Abs;
using ONE_STEP_AND_MULTISTEP_METHODS.Models;
using System;
using OxyPlot.WindowsForms;
using System.Windows.Forms;
using ONE_STEP_AND_MULTISTEP_METHODS.Methods;

namespace ONE_STEP_AND_MULTISTEP_METHODS.Simulations
{
    public class SimulationManager
    {
        private InputParameters _inputParameters;
        private INumericalMethod _method;
        private PlotModel _plotModel;

        public SimulationManager(InputParameters inputParameters, INumericalMethod numericalMethod)
        {
            _inputParameters = inputParameters;
            _method = numericalMethod;
            _plotModel = new PlotModel { Title = "Population Dynamics" };
        }

        public void SetSolver(INumericalMethod method)
        {
            _method = method;
        }

        public void RunSimulation()
        {
            var results = _method.Solver();
            ProcessResults(results);
            PlotResults(results);
            ShowPlot();
        }

        private void ProcessResults((double[] x, double[] y) results)
        {
            Console.WriteLine("Simulation Results:");
            Console.WriteLine("Index\tPopulation X (Rabbits)\tPopulation Y (Foxes)");
            for (int i = 0; i <= _inputParameters.N; i++)
            {
                Console.WriteLine($"{i}\t{results.x[i]}\t{results.y[i]}");
            }
        }

        private void PlotResults((double[] x, double[] y) results)
        {
            var lineSeries = new LineSeries { Title = "Rabbits" };
            var lineSeries2 = new LineSeries { Title = "Foxes", Color = OxyColors.Red };

            for (int i = 0; i <= _inputParameters.N; i++)
            {
                lineSeries.Points.Add(new DataPoint(i, results.x[i]));
                lineSeries2.Points.Add(new DataPoint(i, results.y[i]));
            }

            _plotModel.Series.Add(lineSeries);
            _plotModel.Series.Add(lineSeries2);
        }

        public void RunSimulationAndFindPeaks()
        {
            var results = _method.Solver();
            ProcessResults(results);
            PlotResults(results);
            ShowPlot();

            // Assuming results are stored in arrays results.x and results.y and we need to sum these arrays element-wise
            double[] totalPopulation = new double[results.x.Length];
            for (int i = 0; i < results.x.Length; i++)
            {
                totalPopulation[i] = results.x[i] + results.y[i];
            }

            var (minima, maxima) = LocalMinMaxFinder.SearchForLocalMinMax(totalPopulation);
            Console.WriteLine("Minima:");
            foreach (var min in minima)
            {
                Console.WriteLine(min);
            }
            Console.WriteLine("Maxima:");
            foreach (var max in maxima)
            {
                Console.WriteLine(max);
            }
        }

        private void ShowPlot()
        {
            var plotView = new OxyPlot.WindowsForms.PlotView
            {
                Model = _plotModel,
                Dock = DockStyle.Fill
            };

            Form plotForm = new Form
            {
                Width = 800,
                Height = 600
            };
            plotForm.Controls.Add(plotView);
            plotForm.ShowDialog();
        }

        public double RunSimulationAndGetResults()
        {
            var results = _method.Solver();
            ProcessResults(results);
            PlotResults(results);
            return results.x[_inputParameters.N] + results.y[_inputParameters.N];  
        }

    }
}
