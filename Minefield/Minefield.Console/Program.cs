using System;
using System.Threading.Tasks;

namespace Minefield.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length != 2)
            {
                PrintInstructions();
                return;
            }

            var boardConfigFilePath = args[0];
            var sequenciesFilePath = args[1];

            var loader = new BoardFileLoader();
            var sequencies = await loader.LoadCommandsAsync(sequenciesFilePath);
            var sequenceNumber = 1;

            foreach (var commands in sequencies)
            {
                var board = await loader.LoadBoardAsync(boardConfigFilePath);
                var endState = board.Evaluate(commands);
                PrintState(sequenceNumber++, endState);
            }
        }

        private static void PrintInstructions()
        {
            Console.WriteLine("Invalid Arguments.");
            Console.WriteLine($"Usage:");
            Console.WriteLine($"\t Windows: {AppDomain.CurrentDomain.FriendlyName} <pathToBoardJson> <pathToCommandsJson>");
            Console.WriteLine($"\t Mac: dotnet {AppDomain.CurrentDomain.FriendlyName}.dll <pathToBoardJson> <pathToCommandsJson>");
        }

        private static void PrintState(int sequenceNumber, TurtleState state)
        {
            Console.WriteLine($"Sequence {sequenceNumber}: {DescriptionForState(state)}");
        }

        private static string DescriptionForState(TurtleState state)
        {
            switch (state)
            {
                case TurtleState.InDanger:
                    return "Still in danger!";
                    
                case TurtleState.HitMine:
                    return "Mine hit!";
                    
                case TurtleState.FoundExit:
                    return "Success!";
                    
                case TurtleState.OutOfBounds:
                    return "Out of bounds!";
            }

            return "";
        }
    }
}
