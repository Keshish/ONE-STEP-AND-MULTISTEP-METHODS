using ONE_STEP_AND_MULTISTEP_METHODS.Methods;
using ONE_STEP_AND_MULTISTEP_METHODS.Models;
using ONE_STEP_AND_MULTISTEP_METHODS.Simulations;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Common parameters
        int x0 = 5, y0 = 1, T = 50;

        // Exercise 1a: Euler method simulation
        var eulerParameters = new InputParameters(x0, y0, T, 1000); // Example N for Euler
        var eulerSolver = new Euler(eulerParameters);
        var eulerSimulationManager = new SimulationManager(eulerParameters, eulerSolver);
        Console.WriteLine("Running Euler simulation...");
        eulerSimulationManager.RunSimulation();

        // Exercise 1b: 2-step Adams-Bashford method simulation
        var adamsParameters = new InputParameters(x0, y0, T, 1000); // Example N for Adams-Bashford
        var adamsSolver = new AdamBashford(adamsParameters);
        var adamsSimulationManager = new SimulationManager(adamsParameters, adamsSolver);
        Console.WriteLine("Running 2-step Adams-Bashford simulation...");
        adamsSimulationManager.RunSimulation();

        // Exercise 1c: Convergence testing for the 2-step Adams-Bashford method
        // Exact solution computation
        var exactParameters = new InputParameters(x0, y0, T, 10000000); // Very large N for "exact" solution
        var exactSolver = new AdamBashford(exactParameters);
        var exactSimulationManager = new SimulationManager(exactParameters, exactSolver);
        var exactResults = exactSimulationManager.RunSimulationAndGetResults(); // Assuming this method exists and retrieves x(T) + y(T)

        // Range of N values for convergence testing
        int[] NValues = { 1024, 2048, 4096, 8192, 16384, 32768, 65536, 131072, 262144 };
        Console.WriteLine("Running convergence tests...");
        foreach (int N in NValues)
        {
            var testParameters = new InputParameters(x0, y0, T, N);
            var testSolver = new AdamBashford(testParameters);
            var testSimulationManager = new SimulationManager(testParameters, testSolver);
            var testResults = testSimulationManager.RunSimulationAndGetResults(); // Retrieves x(T) + y(T)

            double error = Math.Abs(testResults - exactResults); // Compute the absolute error
            Console.WriteLine($"N = {N}, Error = {error}");
        }
        Console.ReadLine();

    }
}
