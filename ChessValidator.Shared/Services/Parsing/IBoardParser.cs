using ChessValidator.Shared.Models;

namespace ChessValidator.Shared.Services.Parsing
{
    public interface IBoardParser
    {
        public ChessBoard Parse(IEnumerable<string> lines);
    }
}
