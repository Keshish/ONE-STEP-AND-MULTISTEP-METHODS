using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONE_STEP_AND_MULTISTEP_METHODS.Utilities
{
    public static class FunctionContainer
    {
        public static Func<double, double, double> EulerFx { get; } = (x, y) => x * (1 - y);
        public static Func<double, double, double> EulerFy { get; } = (x, y) => y * (x - 1);
        public static Func<double[], double> CrankFx { get; } = (x) => x[0] * (1 - x[1]);
        public static Func<double[], double> CrankFy { get; } = (x) => x[1] * (x[0] - 1);
    }
}
