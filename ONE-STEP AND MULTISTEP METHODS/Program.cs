using ONE_STEP_AND_MULTISTEP_METHODS.Methods;
using ONE_STEP_AND_MULTISTEP_METHODS.Models;
using ONE_STEP_AND_MULTISTEP_METHODS.Simulations;

public class Program
{
    public static void Main(string[] args)
    {
        InputParameters inputParameter = new();

        var eulerSolver = new Euler(inputParameter);
        var simulationManager = new SimulationManager(eulerSolver);
        simulationManager.RunSimulationEuler();


        var AdamBashfordSolver = new AdamBashford(inputParameter);
        simulationManager.SetSolver(AdamBashfordSolver);
        simulationManager.RunSimulationEuler();
    }
}