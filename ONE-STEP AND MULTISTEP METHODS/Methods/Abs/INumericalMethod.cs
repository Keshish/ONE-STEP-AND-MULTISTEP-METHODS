using ONE_STEP_AND_MULTISTEP_METHODS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONE_STEP_AND_MULTISTEP_METHODS.Methods.Abs
{
    public interface INumericalMethod
    {
        (double[] x, double[] y) Solver();

    }
}
