using System.Collections.Generic;

namespace Minefield
{
    public class Board
    {
        public uint Width { get; set; }
        public uint Height { get; set; }
        
        public Turtle Turtle { get; set; }
        public Exit Exit { get; set; }
        public HashSet<Mine> Mines { get; set; } = new HashSet<Mine>();
        
        public Board(uint width, uint height, Turtle turtle, Exit exit)
        {
            Width = width;
            Height = height;
            Turtle = turtle;
            Exit = exit;
        }
    }
}
