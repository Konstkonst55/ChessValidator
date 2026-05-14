using ChessValidator.Shared.Models;

namespace ChessValidator.Shared.Services.Rendering
{
    public class BoardRenderer : IBoardRenderer
    {
        public string Render(ChessBoard board)
        {
            var grid = new string[8, 8];

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    grid[x, y] = ".";
                }
            }

            foreach (var piece in board.Pieces)
            {
                grid[piece.Position.X, piece.Position.Y] = piece.Symbol;
            }

            var lines = new List<string>();

            for (int y = 7; y >= 0; y--)
            {
                var row = "";

                for (int x = 0; x < 8; x++)
                {
                    row += grid[x, y] + " ";
                }
                
                lines.Add(row);
            }

            return string.Join(Environment.NewLine, lines);
        }
    }
}