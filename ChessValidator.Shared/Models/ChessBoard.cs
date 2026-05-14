using ChessValidator.Shared.Pieces;

namespace ChessValidator.Shared.Models
{
    /// <summary>
    /// Представляет шахматную доску 8x8 с размещёнными на ней фигурами.
    /// </summary>
    public class ChessBoard
    {
        private readonly List<Piece> _pieces = new();
        private readonly Piece?[,] _grid = new Piece?[8, 8];

        /// <summary>
        /// Коллекция всех фигур, размещённых на доске.
        /// </summary>
        public IReadOnlyCollection<Piece> Pieces => _pieces;

        /// <summary>
        /// Добавляет фигуру на доску.
        /// </summary>
        /// <param name="piece">Добавляемая фигура.</param>
        /// <exception cref="Exceptions.DuplicatePositionException">Выбрасывается, если на указанной позиции уже находится другая фигура.</exception>
        public void AddPiece(Piece piece)
        {
            if (_grid[piece.Position.X, piece.Position.Y] != null)
            {
                throw new Exceptions.DuplicatePositionException();
            }

            _pieces.Add(piece);
            _grid[piece.Position.X, piece.Position.Y] = piece;
        }

        /// <summary>
        /// Возвращает фигуру, находящуюся на указанной позиции, или <c>null</c>, если клетка пуста.
        /// </summary>
        /// <param name="position">Позиция для проверки.</param>
        /// <returns>Фигура на указанной позиции или <c>null</c>.</returns>
        public Piece? GetPieceAt(Position position) => _grid[position.X, position.Y];

        /// <summary>
        /// Проверяет, занята ли указанная клетка какой-либо фигурой.
        /// </summary>
        /// <returns><c>true</c>, если клетка занята; иначе <c>false</c>.</returns>
        public bool IsSquareOccupied(int x, int y) => _grid[x, y] != null;
    }
}