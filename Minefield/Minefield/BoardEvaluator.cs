using System;
using System.Collections.Generic;

namespace Minefield
{
    public class BoardEvaluator : IBoardEvaluator
    {
        private Board _board;

        public BoardEvaluator(Board board)
        {
            _board = board ?? throw new ArgumentNullException(nameof(board));
        }

        public TurtleState Evaluate(ITurtleCommand command)
        {
            var currentState = CheckTurtleState();
            if (currentState != TurtleState.InDanger)
            {
                return currentState;
            }

            command.Execute(_board.Turtle);
            return CheckTurtleState();
        }

        public TurtleState Evaluate(IEnumerable<ITurtleCommand> commands)
        {
            var newState = TurtleState.InDanger;

            foreach (var command in commands)
            {
                newState = Evaluate(command);
                if (newState != TurtleState.InDanger)
                {
                    return newState;
                }
            }

            return newState;
        }

        private TurtleState CheckTurtleState()
        {
            if (IsOutOfBounds())
            {
                return TurtleState.OutOfBounds;
            }

            if (HasFoundExit())
            {
                return TurtleState.FoundExit;
            }

            if (HasHitMine())
            {
                return TurtleState.HitMine;
            }

            return TurtleState.InDanger;
        }

        private bool IsOutOfBounds()
        {
            return _board.Turtle.X < 0
                || _board.Turtle.Y < 0
                || _board.Turtle.X >= _board.Width
                || _board.Turtle.Y >= _board.Height;
        }

        private bool HasFoundExit()
        {
            return _board.Turtle.X == _board.Exit.X
                && _board.Turtle.Y == _board.Exit.Y;
        }

        private bool HasHitMine()
        {
            return _board.Mines.Contains(new Mine(_board.Turtle.X, _board.Turtle.Y));
        }
    }
}
