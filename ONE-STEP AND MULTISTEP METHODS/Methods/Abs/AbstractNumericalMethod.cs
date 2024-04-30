using ONE_STEP_AND_MULTISTEP_METHODS.Models;
using System;

namespace ONE_STEP_AND_MULTISTEP_METHODS.Methods.Abs
{
    public abstract class AbstractNumericalMethod
    {
        public int N { get; private set; }
        public double H { get; private set; }
        public double[] X { get; private set; }
        public double[] Y { get; private set; }

        protected AbstractNumericalMethod(InputParameters inputParameters) => Initialize(inputParameters);

        protected virtual void Initialize(InputParameters inputParameters)
        {
            N = inputParameters.N;
            H = (double)inputParameters.T / inputParameters.N;

            X = new double[N + 1];
            Y = new double[N + 1];

            X[0] = inputParameters.x0;
            Y[0] = inputParameters.y0;
        }

        public double X0 => X[0];
        public double Y0 => Y[0];
    }
}
