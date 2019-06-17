using System;
namespace Minefield
{
    public abstract class Tile
    {
        public Position Position { get; set; }

        protected Tile(int x, int y)
        {
            Position = new Position(x, y);
        }
    }
}
