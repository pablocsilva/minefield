using System.Collections.Generic;
using System.Threading.Tasks;

namespace Minefield
{
    using ITurtleCommandsCollection = IEnumerable<IEnumerable<ITurtleCommand>>;

    public interface ITurtleCommandsCollectionFactory
    {
        Task<ITurtleCommandsCollection> LoadCommandsCollectionAsync(string jsonFilePath);
    }
}
