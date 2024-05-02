# Numerical Simulations of Differential Equations

This repository contains a .NET 8 project for the numerical simulation of differential equations using both one-step (Euler) and multi-step (Adams-Bashford) methods. The focus is on modeling and analyzing predator-prey dynamics, commonly described by the Lotka-Volterra equations. It includes functionality for convergence analysis and identifying local maxima and minima in population data.

## Project Structure

- **Methods**: Implements numerical methods like Euler and Adams-Bashford.
- **Models**: Defines input parameters and structures for managing simulation data.
- **Simulations**: Manages the execution of simulations, including result processing and visualization.
- **Utilities**: Provides helper functions, such as finding local maxima and minima in simulation data.

## Setup

### Prerequisites

- .NET 8 SDK
- An IDE with .NET support (Visual Studio 2022, VS Code with C# extension)

### Getting Started

1. **Clone the Repository**
   ```bash
   git clone https://github.com/Keshish/ONE-STEP-AND-MULTISTEP-METHODS.git
   ```
2. **Navigate to the Project Directory**
   ```bash
   cd ONE_STEP_AND_MULTISTEP_METHODS
   ```
3. **Build the Project**
   ```bash
   dotnet build
   ```

## Usage

To run the simulations:

```bash
dotnet run --project ONE_STEP_AND_MULTISTEP_METHODS
```

### Configuration

Modify the `Main` method in `Program.cs` to customize simulations, such as changing initial conditions, total simulation time \(T\), or the step count \(N\).

### Output

Outputs include console logs of simulation results and graphical plots via OxyPlot. It displays the population dynamics and, optionally, the peaks and troughs of the population sizes over time.


## License

Distributed under the MIT License. See `LICENSE` for more information.

