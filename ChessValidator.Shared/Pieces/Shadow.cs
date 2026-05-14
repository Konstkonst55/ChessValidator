using ChessValidator.Shared.Models;

namespace ChessValidator.Shared.Pieces
{
    public class Shadow : Piece
    {
        public Shadow(Position position) : base(position) { }
        public override string Symbol => "S";

        public override bool CanAttack(Position target, ChessBoard board)
        {
            return IsOrthogonalAttack(target, board) || IsDiagonalAttack(target, board);
        }
    }
}
