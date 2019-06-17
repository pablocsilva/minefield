using System;
namespace Minefield
{
    public class Turtle : Tile
    {
        public TurtleDirection Direction { get; set; }

        public Turtle(int x, int y, TurtleDirection direction = TurtleDirection.North) : base(x, y)
        {
            Direction = direction;
        }
    }
}
