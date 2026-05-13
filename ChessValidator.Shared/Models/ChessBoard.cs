using ChessValidator.Shared.Pieces;

namespace ChessValidator.Shared.Models
{
    public class ChessBoard
    {
        private readonly List<Piece> _pieces = new();

        public IReadOnlyCollection<Piece> Pieces => _pieces;

        public void AddPiece(Piece piece)
        {
            if (_pieces.Any(p => p.Position.X == piece.Position.X && p.Position.Y == piece.Position.Y))
                throw new Exceptions.DuplicatePositionException();

            _pieces.Add(piece);
        }

        public Piece? GetPieceAt(Position position)
        {
            return _pieces.FirstOrDefault(p => p.Position.X == position.X && p.Position.Y == position.Y);
        }
    }
}