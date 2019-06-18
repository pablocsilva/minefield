using System;
using System.Collections.Generic;

namespace Minefield
{
    public class Board
    {
        public uint Width { get; set; }
        public uint Height { get; set; }
        
        public Turtle Turtle { get; set; }
        public HashSet<Mine> Mines { get; set; } = new HashSet<Mine>();
        public Exit Exit { get; set; }

        public Board(uint width, uint height, Turtle turtle, Exit exit)
        {
            Width = width;
            Height = height;
            Turtle = turtle;
            Exit = exit;
        }

        public TurtleState Evaluate(ITurtleCommand command)
        {
            var currentState = CheckTurtleState();
            if (currentState != TurtleState.InDanger)
            {
                return currentState;
            }

            command.Execute(Turtle);
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
            return Turtle.X < 0
                || Turtle.Y < 0
                || Turtle.X >= Width
                || Turtle.Y >= Height;
        }

        private bool HasFoundExit()
        {
            return Turtle.X == Exit.X
                && Turtle.Y == Exit.Y;
        }

        private bool HasHitMine()
        {
            return Mines.Contains(new Mine(Turtle.X, Turtle.Y));
        }
    }
}
