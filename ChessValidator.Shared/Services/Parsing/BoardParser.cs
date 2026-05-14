using ChessValidator.Shared.Exceptions;
using ChessValidator.Shared.Models;
using ChessValidator.Shared.Pieces;

namespace ChessValidator.Shared.Services.Parsing
{
    public class BoardParser : IBoardParser
    {
        public ChessBoard Parse(IEnumerable<string> lines)
        {
            var board = new ChessBoard();
            var list = lines.ToList();

            if (list.Count < 2 || list.Count > 10)
                throw new InvalidPieceCountException(); 

            foreach (var line in list)
            {
                var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length < 3)
                    throw new ChessValidationException("Некорректный формат строки: " + line);

                var type = parts[0].ToLower();

                if (!int.TryParse(parts[1], out int x) || !int.TryParse(parts[2], out int y))
                    throw new ChessValidationException("Координаты должны быть целыми числами: " + line);

                var position = new Position(x, y);

                Piece piece = type switch
                {
                    "king" => new King(position),
                    "queen" => new Queen(position),
                    "rook" => new Rook(position),
                    "bishop" => new Bishop(position),
                    "knight" => new Knight(position),
                    "shadow" => new Shadow(position),
                    _ => throw new ChessValidationException("Неизвестный тип фигуры: " + type)
                };

                board.AddPiece(piece);
            }
            return board;
        }
    }
}