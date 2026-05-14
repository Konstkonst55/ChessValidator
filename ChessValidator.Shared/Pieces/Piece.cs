using ChessValidator.Shared.Models;

namespace ChessValidator.Shared.Pieces
{
    public abstract class Piece
    {
        public Position Position { get; }

        protected Piece(Position position) => Position = position;

        public abstract bool CanAttack(Position target, ChessBoard board);

        public abstract string Symbol { get; }

        protected bool IsOrthogonalAttack(Position target, ChessBoard board)
        {
            if (Position.X == target.X)
            {
                return IsPathClear(target, board, 0, target.Y > Position.Y ? 1 : -1);
            }

            if (Position.Y == target.Y)
            {
                return IsPathClear(target, board, target.X > Position.X ? 1 : -1, 0);
            }

            return false;
        }

        protected bool IsDiagonalAttack(Position target, ChessBoard board)
        {
            if (Math.Abs(Position.X - target.X) == Math.Abs(Position.Y - target.Y))
            {
                int dx = target.X > Position.X ? 1 : -1;
                int dy = target.Y > Position.Y ? 1 : -1;
             
                return IsPathClear(target, board, dx, dy);
            }

            return false;
        }

        protected bool IsPathClear(Position target, ChessBoard board, int dx, int dy)
        {
            int x = Position.X + dx;
            int y = Position.Y + dy;

            while (x != target.X || y != target.Y)
            {
                if (board.IsSquareOccupied(x, y))
                {
                    return false;
                }

                x += dx;
                y += dy;
            }

            return true;
        }
    }
}