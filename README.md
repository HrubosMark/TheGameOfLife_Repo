# The Game Of Life

## Table of contents

- [The original Concept](#the-original-concept)
- [Our version](#our-version)
- [Requirements](#requirements)
- [Installation and usage](#installation-and-usage)
- [Contributions](#contributions)
- [License](#license)


## The original Concept

**The Game of Life** is a grid based simulation invented by John Conway in 1970. The simulation displays a grid-based world where cells live and die according to specific rules. The simulation, "life" emerges in the grid, forming various patterns.

## Our version

**Our simulation** models an ecosystem within a rectangular grid where grass, rabbits, and foxes interact. Each species has specific behaviors for growth, movement, and reproduction, with turn-based mechanics governing the system’s evolution over time. 

## Requirements

- .NET SDK: .NET 8.0 or newer version
- Operation system: Windows, Linux or macOS

## Installation and usage

1. Clone the repository:

    ```bash
    git clone https://github.com/HrubosMark/TheGameOfLife_Repo
    cd TheGameOfLife_Repo
    ```

2. Installation: Use the NuGet package manager to install the required packages.

    ```bash
    dotnet add package MSTest.TestFramework
    dotnet add package MSTest.TestAdapter
    ```

4. Use an integrated development environment (e.g., Visual Studio or JetBrains Rider) to run the simulation, or you can start the simulation from the command line as well.
  
    ```bash
   dotnet run --project Program.cs
    ```
    
## Contributions
We welcome contributions! Please follow these steps to submit your proposed changes:

1. Fork the repository.
2. Create a new branch for your changes.
3. Create a pull request to the main branch.

## License

- This project is licensed under the [MIT License](LICENSE).
