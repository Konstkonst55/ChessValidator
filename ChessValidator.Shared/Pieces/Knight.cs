using ChessValidator.Shared.Models;

namespace ChessValidator.Shared.Pieces
{
    public class Knight : Piece
    {
        public Knight(Position position) : base(position) { }

        public override string Symbol => "N";

        public override bool CanAttack(Position target, ChessBoard board)
        {
            int dx = Math.Abs(Position.X - target.X);
            int dy = Math.Abs(Position.Y - target.Y);

            return (dx == 2 && dy == 1) || (dx == 1 && dy == 2);
        }
    }
}