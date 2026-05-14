using ChessValidator.Shared.Models;

namespace ChessValidator.Shared.Services.Logic
{
    public interface IAttackDetector
    {
        public List<string> Detect(ChessBoard board);
    }
}
