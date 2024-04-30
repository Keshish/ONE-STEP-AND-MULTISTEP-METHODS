using ONE_STEP_AND_MULTISTEP_METHODS.Methods.Abs;
using ONE_STEP_AND_MULTISTEP_METHODS.Models;
using ONE_STEP_AND_MULTISTEP_METHODS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ONE_STEP_AND_MULTISTEP_METHODS.Methods
{
    public class AdamBashford : AbstractNumericalMethod, INumericalMethod
    {
        public AdamBashford(InputParameters inputParameters)
            : base(inputParameters)
        { }

        public (double[] x, double[] y) Solver()
        {
            double[] x = new double[this.N + 1];
            double[] y = new double[this.N + 1];

            x[0] = this.X0;
            y[0] = this.Y0;

            var initialGuess = new double[] { x[0], y[0] };
            var crankResult = CrankNicolson(initialGuess);

            x[1] = crankResult[0];
            y[1] = crankResult[1];

            for (int i = 1; i < this.N; i++)
            {
                double fx1 = FunctionContainer.EulerFx(x[i], y[i]);
                double fy1 = FunctionContainer.EulerFy(x[i], y[i]);
                double fx0 = FunctionContainer.EulerFx(x[i - 1], y[i - 1]);
                double fy0 = FunctionContainer.EulerFy(x[i - 1], y[i - 1]);
                x[i + 1] = x[i] + this.H * (1.5 * fx1 - 0.5 * fx0);
                y[i + 1] = y[i] + this.H * (1.5 * fy1 - 0.5 * fy0);
            }

            return (x, y);
        }

        private double[] CrankNicolson(double[] initialGuess)
        {
            double h = this.H;
            double[] nextValues = new double[2];
            nextValues[0] = initialGuess[0] + 0.5 * h * (FunctionContainer.CrankFx(initialGuess) + FunctionContainer.CrankFx(new double[] { initialGuess[0], initialGuess[1] }));
            nextValues[1] = initialGuess[1] + 0.5 * h * (FunctionContainer.CrankFy(initialGuess) + FunctionContainer.CrankFy(new double[] { initialGuess[0], initialGuess[1] }));
            return nextValues;
        }
    }
}
