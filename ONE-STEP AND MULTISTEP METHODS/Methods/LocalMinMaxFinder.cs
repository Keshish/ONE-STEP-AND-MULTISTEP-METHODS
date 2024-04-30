using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONE_STEP_AND_MULTISTEP_METHODS.Methods
{
    public static class LocalMinMaxFinder
    {
        public static (List<double> minima, List<double> maxima) SearchForLocalMinMax(double[] values)
        {
            List<double> minima = new List<double>();
            List<double> maxima = new List<double>();

            int i = 0;
            int state = values[1] > values[0] ? 1 : 2;  // 1 for looking for max, 2 for min

            while (i < values.Length - 1)
            {
                switch (state)
                {
                    case 1: // Looking for maximum
                        while (i < values.Length - 1 && values[i + 1] > values[i])
                        {
                            i++;
                        }
                        if (i < values.Length)
                        {
                            maxima.Add(values[i]);
                            state = 2;  // Switch to looking for minimum
                        }
                        break;
                    case 2: // Looking for minimum
                        while (i < values.Length - 1 && values[i + 1] < values[i])
                        {
                            i++;
                        }
                        if (i < values.Length)
                        {
                            minima.Add(values[i]);
                            state = 1;  // Switch to looking for maximum
                        }
                        break;
                }
                i++;
            }

            return (minima, maxima);
        }
    }
}