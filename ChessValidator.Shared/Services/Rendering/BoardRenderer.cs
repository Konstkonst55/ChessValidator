using ChessValidator.Shared.Models;

namespace ChessValidator.Shared.Services.Rendering
{
    /// <summary>
    /// Реализация рендерера, создающего текстовую визуализацию шахматной доски 8x8.
    /// Пустые клетки отображаются точкой (.), занятые — символом фигуры.
    /// </summary>
    public class BoardRenderer : IBoardRenderer
    {
        /// <summary>
        /// Генерирует строковое представление доски, где координата Y увеличивается снизу вверх
        /// (строка с Y=7 сверху, Y=0 снизу).
        /// </summary>
        /// <param name="board">Шахматная доска для отображения.</param>
        /// <returns>Многострочная строка с визуализацией доски.</returns>
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