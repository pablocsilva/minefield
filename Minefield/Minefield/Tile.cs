namespace Minefield
{
    public abstract class Tile : IPosition
    {
        public int X { get; set; }
        public int Y { get; set; }

        protected Tile(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override int GetHashCode()
        {
            return $"{X};{Y}".GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Tile tile))
            {
                return false;
            }
            return X == tile.X && Y == tile.Y;
        }
    }
}
