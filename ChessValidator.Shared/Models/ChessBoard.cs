using ChessValidator.Shared.Pieces;

namespace ChessValidator.Shared.Models
{
    public class ChessBoard
    {
        private readonly List<Piece> _pieces = new();
        private readonly Piece?[,] _grid = new Piece?[8, 8];

        public IReadOnlyCollection<Piece> Pieces => _pieces;

        public void AddPiece(Piece piece)
        {
            if (_grid[piece.Position.X, piece.Position.Y] != null)
            {
                throw new Exceptions.DuplicatePositionException();
            }

            _pieces.Add(piece);
            _grid[piece.Position.X, piece.Position.Y] = piece;
        }

        public Piece? GetPieceAt(Position position) => _grid[position.X, position.Y];

        public bool IsSquareOccupied(int x, int y) => _grid[x, y] != null;
    }
}