using System.Collections;
using System.Collections.Generic;

namespace Minefield.UnitTests
{
    internal class BoardEvaluatorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var r = new RotateTurtleCommand();
            var m = new MoveTurtleCommand();
            
            
            yield return new object[] { MakeBoard(),
                new ITurtleCommand[] { r, r, r, r }, TurtleState.InDanger };
            yield return new object[] { MakeBoard(),
                new ITurtleCommand[] { r, m }, TurtleState.InDanger };

            yield return new object[] { MakeBoard(),
                new ITurtleCommand[] { m }, TurtleState.OutOfBounds };
            yield return new object[] { MakeBoard(),
                new ITurtleCommand[] { r, m, m, m }, TurtleState.OutOfBounds };
            yield return new object[] { MakeBoard(),
                new ITurtleCommand[] { r, r, r, m, m }, TurtleState.OutOfBounds };
            yield return new object[] { MakeBoard(),
                new ITurtleCommand[] { r, r, m, m, m }, TurtleState.OutOfBounds };

            yield return new object[] { MakeBoard(),
                new ITurtleCommand[] { r, m, m, r, m, m, r, r, r, m }, TurtleState.FoundExit };

            var bm = MakeBoard();
            bm.Mines.Add(new Mine(1, 0));
            yield return new object[] { bm,
                new ITurtleCommand[] { r, m }, TurtleState.HitMine };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private Board MakeBoard()
        {
            var exit = new Exit(2, 2);
            var turtle = new Turtle(0, 0) { Direction = TurtleDirection.North };
            return new Board(3, 3, turtle, exit);
        }
    }
}
