using System.Collections.Generic;

namespace Minefield
{
    public interface IBoardEvaluator
    {
        TurtleState Evaluate(ITurtleCommand command);
        TurtleState Evaluate(IEnumerable<ITurtleCommand> commands);
    }
}
