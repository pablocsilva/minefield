using System;
using System.Collections.Generic;

namespace Minefield
{
    public class Board
    {
        public int Width { get; set; }
        public int Height { get; set; }
        
        public Turtle Turtle { get; set; }
        public HashSet<Mine> Mines { get; set; } = new HashSet<Mine>();
        public Tile Exit { get; set; }

        public TurtleState Evaluate(IEnumerable<ITurtleCommand> commands)
        {
            throw new NotImplementedException();
        }
    }
}
