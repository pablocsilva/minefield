namespace Minefield
{
    public class RotateTurtleCommand : ITurtleCommand
    {
        /// <summary>
        /// Rotates turtle 90 degrees to the right
        /// </summary>
        /// <param name="turtle"></param>
        public void Execute(Turtle turtle)
        {
            switch (turtle.Direction)
            {
                case TurtleDirection.North:
                    turtle.Direction = TurtleDirection.East;
                    break;
                case TurtleDirection.East:
                    turtle.Direction = TurtleDirection.South;
                    break;
                case TurtleDirection.South:
                    turtle.Direction = TurtleDirection.West;
                    break;
                case TurtleDirection.West:
                    turtle.Direction = TurtleDirection.North;
                    break;
            }
        }
    }
}
