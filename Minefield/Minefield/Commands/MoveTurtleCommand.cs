namespace Minefield
{
    public class MoveTurtleCommand : ITurtleCommand
    {
        public void Execute(Turtle turtle)
        {
            switch (turtle.Direction)
            {
                case TurtleDirection.North:
                    turtle.Y -= 1;
                    break;
                case TurtleDirection.East:
                    turtle.X += 1;
                    break;
                case TurtleDirection.South:
                    turtle.Y += 1;
                    break;
                case TurtleDirection.West:
                    turtle.X -= 1;
                    break;
            }
        }
    }
}
