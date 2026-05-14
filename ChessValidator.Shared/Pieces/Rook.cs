using ChessValidator.Shared.Models;

namespace ChessValidator.Shared.Pieces
{
    /// <summary>
    /// Представляет фигуру ладьи. Ладья может ходить по горизонтали и вертикали на любое количество клеток.
    /// </summary>
    public class Rook : Piece
    {
        /// <summary>
        /// Инициализирует новый экземпляр ладьи на указанной позиции.
        /// </summary>
        /// <param name="position">Начальная позиция ладьи.</param>
        public Rook(Position position) : base(position) { }

        public override string Symbol => "R";

        /// <summary>
        /// Ладья атакует цель, если она находится на одной горизонтали или вертикали с ней и путь свободен.
        /// </summary>
        /// <param name="target">Позиция цели.</param>
        /// <param name="board">Текущее состояние доски.</param>
        /// <returns><c>true</c>, если цель может быть атакована; иначе <c>false</c>.</returns>
        public override bool CanAttack(Position target, ChessBoard board)
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
    }
}