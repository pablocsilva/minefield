using Xunit;

namespace Minefield.UnitTests
{
    public class BoardTests
    {
        [Fact]
        public void GivenTurtleIsInDanger_WhenEvaluateMoving_ThenReturnsInDanger()
        {
            var turtle = MakeTurtle(TurtleDirection.East);
            var board = MakeBoard(turtle);
            var sut = MakeBoardEvaluator(board);

            var actual = sut.Evaluate(new MoveTurtleCommand());

            Assert.Equal(TurtleState.InDanger, actual);
        }

        [Fact]
        public void GivenTurtleIsInDanger_WhenEvaluateRotating_ThenReturnsInDanger()
        {
            var board = MakeBoard();
            var sut = MakeBoardEvaluator(board);

            var actual = sut.Evaluate(new RotateTurtleCommand());

            Assert.Equal(TurtleState.InDanger, actual);
        }

        [Fact]
        public void GivenTurtleYIsZero_WhenEvaluateMovingNorth_ThenReturnsOutOfBounds()
        {
            var board = MakeBoard();
            var sut = MakeBoardEvaluator(board);

            var actual = sut.Evaluate(new MoveTurtleCommand());

            Assert.Equal(TurtleState.OutOfBounds, actual);
        }

        [Fact]
        public void GivenTurtleXIsZero_WhenEvaluateMovingWest_ThenReturnsOutOfBounds()
        {
            var turtle = MakeTurtle(TurtleDirection.West);
            var board = MakeBoard(turtle);
            var sut = MakeBoardEvaluator(board);

            var actual = sut.Evaluate(new MoveTurtleCommand());

            Assert.Equal(TurtleState.OutOfBounds, actual);
        }

        [Fact]
        public void GivenTurtleIsInLastXPosition_WhenEvaluateMovingEast_ThenReturnsOutOfBounds()
        {
            var turtle = MakeTurtle(TurtleDirection.East);       
            var board = MakeBoard(turtle);
            turtle.X = (int)board.Width - 1;
            var sut = MakeBoardEvaluator(board);

            var actual = sut.Evaluate(new MoveTurtleCommand());

            Assert.Equal(TurtleState.OutOfBounds, actual);
        }

        [Fact]
        public void GivenTurtleIsInLastYPosition_WhenEvaluateMovingSouth_ThenReturnsOutOfBounds()
        {
            var turtle = MakeTurtle(TurtleDirection.South);
            var board = MakeBoard(turtle);
            turtle.Y = (int)board.Height - 1;
            var sut = MakeBoardEvaluator(board);

            var actual = sut.Evaluate(new MoveTurtleCommand());

            Assert.Equal(TurtleState.OutOfBounds, actual);
        }

        [Fact]
        public void GivenTurtleIsInDanger_WhenMovingTowardsMine_ThenEvaluateReturnsHitMine()
        {
            var turtle = MakeTurtle(TurtleDirection.East);
            var board = MakeBoard(turtle);
            board.Mines.Add(new Mine(turtle.X + 1, turtle.Y));
            var sut = MakeBoardEvaluator(board);

            var actual = sut.Evaluate(new MoveTurtleCommand());

            Assert.Equal(TurtleState.HitMine, actual);
        }

        [Fact]
        public void GivenTurtleIsInDanger_WhenMovingTowardsExit_ThenEvaluateReturnsHasFoundExit()
        {
            var turtle = MakeTurtle(TurtleDirection.East);
            turtle.X = 2;
            turtle.Y = 2;
            var exit = new Exit(3, 2);
            var board = MakeBoard(turtle, exit);
            var sut = MakeBoardEvaluator(board);

            var actual = sut.Evaluate(new MoveTurtleCommand());

            Assert.Equal(TurtleState.FoundExit, actual);
        }

        private Board MakeBoard(Turtle turtle = null, Exit exit = null)
        {
            return new Board(4, 4, turtle ?? MakeTurtle(), exit ?? MakeExit());
        }

        private Turtle MakeTurtle(TurtleDirection direction = TurtleDirection.North)
        {
            return new Turtle(0, 0) { Direction = direction };
        }

        private Exit MakeExit()
        {
            return new Exit(3, 2);
        }

        private BoardEvaluator MakeBoardEvaluator(Board board = null)
        {
            return new BoardEvaluator(board ?? MakeBoard());
        }
    }
}
