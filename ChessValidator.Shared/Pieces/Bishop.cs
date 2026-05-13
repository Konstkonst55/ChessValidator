using ChessValidator.Shared.Models;

namespace ChessValidator.Shared.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Position position) : base(position) { }

        public override string Symbol => "B";

        public override bool CanAttack(Position target, ChessBoard board)
        {
            if (Math.Abs(Position.X - target.X) == Math.Abs(Position.Y - target.Y))
            {
                int dx = target.X > Position.X ? 1 : -1;
                int dy = target.Y > Position.Y ? 1 : -1;

                return IsPathClear(target, board, dx, dy);
            }

            return false;
        }
    }
}