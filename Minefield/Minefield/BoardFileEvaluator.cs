using System;
using System.Threading.Tasks;

namespace Minefield
{
    public class BoardFileEvaluator
    {
        private readonly string _pathToBoardFile;
        private readonly string _pathToCommandsCollection;

        public Action<int, TurtleState> OnSequenceEvaluated { get; set; }

        public BoardFileEvaluator(string pathToBoardFile, string pathToCommandsCollection)
        {
            _pathToBoardFile = pathToBoardFile;
            _pathToCommandsCollection = pathToCommandsCollection;
        }

        public async Task Evaluate()
        {
            var loader = new BoardFileLoader();
            var commandsCollection = await loader.LoadCommandsCollectionAsync(_pathToCommandsCollection);
            var sequenceNumber = 1;

            foreach (var commands in commandsCollection)
            {
                var board = await loader.LoadBoardAsync(_pathToBoardFile);
                var boardEvaluator = new BoardEvaluator(board);
                var endState = boardEvaluator.Evaluate(commands);
                OnSequenceEvaluated?.Invoke(sequenceNumber++, endState);
            }
        }
    }
}
