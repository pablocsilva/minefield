using System.Threading.Tasks;

namespace Minefield
{
    public interface IBoardFactory
    {
        Task<Board> LoadBoardAsync(string jsonFilePath);
    }
}
