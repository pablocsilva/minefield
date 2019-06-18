namespace Minefield
{
    public class Turtle : Tile
    {
        public TurtleDirection Direction { get; set; }

        public Turtle(int x, int y) : base(x, y) { }
    }
}
