using Xunit;
using System.Collections.Generic;
using System.Collections;

namespace Minefield.UnitTests
{
    public class BoardEvaluatorTests
    {
        [Fact]
        public void TurtleIsInDanger_EvaluateMoving_ReturnsInDanger()
        {
            var turtle = MakeTurtle(TurtleDirection.East);
            var board = MakeBoard(turtle);
            var sut = MakeBoardEvaluator(board);

            var actual = sut.Evaluate(new MoveTurtleCommand());

            Assert.Equal(TurtleState.InDanger, actual);
        }

        [Fact]
        public void TurtleIsInDanger_EvaluateRotating_ReturnsInDanger()
        {
            var board = MakeBoard();
            var sut = MakeBoardEvaluator(board);

            var actual = sut.Evaluate(new RotateTurtleCommand());

            Assert.Equal(TurtleState.InDanger, actual);
        }

        [Fact]
        public void TurtleYIsZero_EvaluateMovingNorth_ReturnsOutOfBounds()
        {
            var board = MakeBoard();
            var sut = MakeBoardEvaluator(board);

            var actual = sut.Evaluate(new MoveTurtleCommand());

            Assert.Equal(TurtleState.OutOfBounds, actual);
        }

        [Fact]
        public void TurtleXIsZero_EvaluateMovingWest_ReturnsOutOfBounds()
        {
            var turtle = MakeTurtle(TurtleDirection.West);
            var board = MakeBoard(turtle);
            var sut = MakeBoardEvaluator(board);

            var actual = sut.Evaluate(new MoveTurtleCommand());

            Assert.Equal(TurtleState.OutOfBounds, actual);
        }

        [Fact]
        public void TurtleIsInLastXPosition_EvaluateMovingEast_ReturnsOutOfBounds()
        {
            var turtle = MakeTurtle(TurtleDirection.East);       
            var board = MakeBoard(turtle);
            turtle.X = (int)board.Width - 1;
            var sut = MakeBoardEvaluator(board);

            var actual = sut.Evaluate(new MoveTurtleCommand());

            Assert.Equal(TurtleState.OutOfBounds, actual);
        }

        [Fact]
        public void TurtleIsInLastYPosition_EvaluateMovingSouth_ReturnsOutOfBounds()
        {
            var turtle = MakeTurtle(TurtleDirection.South);
            var board = MakeBoard(turtle);
            turtle.Y = (int)board.Height - 1;
            var sut = MakeBoardEvaluator(board);

            var actual = sut.Evaluate(new MoveTurtleCommand());

            Assert.Equal(TurtleState.OutOfBounds, actual);
        }

        [Fact]
        public void TurtleIsInDanger_MovingTowardsMine_EvaluateReturnsHitMine()
        {
            var turtle = MakeTurtle(TurtleDirection.East);
            var board = MakeBoard(turtle);
            board.Mines.Add(new Mine(turtle.X + 1, turtle.Y));
            var sut = MakeBoardEvaluator(board);

            var actual = sut.Evaluate(new MoveTurtleCommand());

            Assert.Equal(TurtleState.HitMine, actual);
        }

        [Fact]
        public void TurtleIsInDanger_MovingTowardsExit_EvaluateReturnsHasFoundExit()
        {
            var turtle = MakeTurtle(TurtleDirection.East);
            turtle.X = 1;
            turtle.Y = 2;
            var exit = new Exit(1, 2);
            var board = MakeBoard(turtle);
            var sut = MakeBoardEvaluator(board);

            var actual = sut.Evaluate(new MoveTurtleCommand());

            Assert.Equal(TurtleState.FoundExit, actual);
        }

        [Theory]
        [ClassData(typeof(BoardEvaluatorTestData))]
        public void TurtleIsInDanger_EvaluateMultipleCommands_ReturnsCorrectState(
            Board board,
            IEnumerable<ITurtleCommand> commands,
            TurtleState expectedState) {

            var sut = MakeBoardEvaluator(board);

            var actual = sut.Evaluate(commands);

            Assert.Equal(expectedState, actual);
        }

        private Board MakeBoard(Turtle turtle = null, Exit exit = null)
        {
            return new Board(2, 3, turtle ?? MakeTurtle(), exit ?? MakeExit());
        }

        private Turtle MakeTurtle(TurtleDirection direction = TurtleDirection.North)
        {
            return new Turtle(0, 0) { Direction = direction };
        }

        private Exit MakeExit()
        {
            return new Exit(1, 2);
        }

        private BoardEvaluator MakeBoardEvaluator(Board board = null)
        {
            return new BoardEvaluator(board ?? MakeBoard());
        }
    }
}
