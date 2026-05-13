using ChessValidator.Shared.Models;

namespace ChessValidator.Shared.Pieces
{
    public class Queen : Piece
    {
        public Queen(Position position) : base(position) { }
        public override string Symbol => "Q";

        public override bool CanAttack(Position target, ChessBoard board)
        {
            return IsOrthogonalAttack(target, board) || IsDiagonalAttack(target, board);
        }
    }
}