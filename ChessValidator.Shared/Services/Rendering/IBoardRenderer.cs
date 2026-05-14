using ChessValidator.Shared.Models;

namespace ChessValidator.Shared.Services.Rendering
{
    public interface IBoardRenderer
    {
        public string Render(ChessBoard board);
    }
}
