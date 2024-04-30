using ONE_STEP_AND_MULTISTEP_METHODS.Methods.Abs;
using ONE_STEP_AND_MULTISTEP_METHODS.Models;
using ONE_STEP_AND_MULTISTEP_METHODS.Utilities;

namespace ONE_STEP_AND_MULTISTEP_METHODS.Methods
{
    public class Euler : AbstractNumericalMethod, INumericalMethod
    {
        public Euler(InputParameters inputParameters) : base(inputParameters)
        {

        }
        public (double[] x, double[] y) Solver()
        {
            var x = X;
            var y = Y;

            for (int i = 0; i < base.N; i++)
            {
                x[i + 1] = x[i] + H * FunctionContainer.EulerFx(x[i], y[i]);
                y[i + 1] = y[i] + H * FunctionContainer.EulerFy(x[i], y[i]);
            }

            return (x, y);
        }
    }
}
