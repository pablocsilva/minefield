# Turtle minefield challenge

A turtle must walk through a minefield. 
Write a program that will read the initial game settings from one file and one or more sequences of moves from a different file, then for each move sequence, the program will output if the sequence leads to the success or failure of the little
turtle.

The program should also handle the scenario where the turtle doesn’t reach the exit point or
doesn’t hit a mine.

_Notes_
There are no restrictions or requirements on how to model the game settings and the sequences of moves.

### Prerequisites

.NET Core 2.1


## Running the tests

```
dotnet build Minefield/Minefield.sln
dotnet test Minefield/Minefield.sln
```

## Running the console app

```
dotnet build Minefield/Minefield.sln
dotnet run --project Minefield/Minefield.Console/Minefield.ConsoleApp.csproj Minefield/Minefield.Console/board.json Minefield/Minefield.Console/commands.json
```

## Depedencies

* [NewtonSoft.Json.NET 12.0.2](https://www.newtonsoft.com/json) - Used to deserialize board settings and collections of commands

## Authors

* **Pablo Carvalho** - https://www.linkedin.com/in/pablocsilva/

## Notes

This challenge should not take more than 3 hours to be complete. 
I ended up spending longer than that as completing the challenge on Visual Studio for Mac proved to be very buggy and inneficient.
