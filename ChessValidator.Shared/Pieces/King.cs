using ChessValidator.Shared.Models;

namespace ChessValidator.Shared.Pieces
{
    public class King : Piece
    {
        public King(Position position) : base(position) { }

        public override string Symbol => "K";

        public override bool CanAttack(Position target, ChessBoard board)
        {
            return Math.Abs(Position.X - target.X) <= 1 && Math.Abs(Position.Y - target.Y) <= 1;
        }
    }
}