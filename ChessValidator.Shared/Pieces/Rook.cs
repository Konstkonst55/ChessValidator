using ChessValidator.Shared.Models;

namespace ChessValidator.Shared.Pieces
{
    public class Rook : Piece
    {
        public Rook(Position position) : base(position) { }

        public override string Symbol => "R";

        public override bool CanAttack(Position target, ChessBoard board)
        {
            if (Position.X == target.X)
                return IsPathClear(target, board, 0, target.Y > Position.Y ? 1 : -1);

            if (Position.Y == target.Y)
                return IsPathClear(target, board, target.X > Position.X ? 1 : -1, 0);

            return false;
        }
    }
}