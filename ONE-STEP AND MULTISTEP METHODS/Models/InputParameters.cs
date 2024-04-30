using System;

namespace ONE_STEP_AND_MULTISTEP_METHODS.Models
{
    public record InputParameters(double x0 = 5, double y0 = 1, double T = 50, int N = default)
    {
        public InputParameters() : this(5, 1, 50, (int)Math.Pow(10, 4)) { }
    }
}
