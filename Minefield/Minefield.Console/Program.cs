using System;
using System.Threading.Tasks;

namespace Minefield.ConsoleApp
{
    class Program
    {
        /// <summary>
        /// Expects 2 arguments
        /// 0: the path to board configuration JSON file.
        /// 1: the path to the file with a collection of collections of turtle commands.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
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
            var commandsCollection = await loader.LoadCommandsCollectionAsync(sequenciesFilePath);
            var sequenceNumber = 1;

            foreach (var commands in commandsCollection)
            {
                var board = await loader.LoadBoardAsync(boardConfigFilePath);
                var boardEvaluator = new BoardEvaluator(board);
                var endState = boardEvaluator.Evaluate(commands);
                PrintState(sequenceNumber++, endState);
            }
        }

        private static void PrintInstructions()
        {
            Console.WriteLine("Invalid Arguments.");
            Console.WriteLine($"Usage:");
            var appName = AppDomain.CurrentDomain.FriendlyName;
            var arguments = "<pathToBoardJson> <pathToCommandsJson>";
            Console.WriteLine($"\t Windows: {appName} {arguments}");
            Console.WriteLine($"\t Mac: dotnet {appName}.dll {arguments}");
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
