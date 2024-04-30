using OxyPlot;
using OxyPlot.Series;
using ONE_STEP_AND_MULTISTEP_METHODS.Methods.Abs;
using ONE_STEP_AND_MULTISTEP_METHODS.Models;
using System;
using OxyPlot.WindowsForms;
using System.Windows.Forms;


namespace ONE_STEP_AND_MULTISTEP_METHODS.Simulations
{
    public class SimulationManager
    {
        private InputParameters _inputParameters;
        private INumericalMethod _method;
        private PlotModel _plotModel;

        public SimulationManager(INumericalMethod numericalMethod)
        {
            _inputParameters = new InputParameters();
            _method = numericalMethod;
            _plotModel = new PlotModel { Title = "Population Dynamics" };
        }

        public void SetSolver(INumericalMethod method)
        {
            _method = method;
        }

        public void RunSimulationEuler()
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
    }
}
