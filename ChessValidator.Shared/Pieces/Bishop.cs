using ChessValidator.Shared.Models;

namespace ChessValidator.Shared.Pieces
{
    /// <summary>
    /// Представляет фигуру слона. Слон может ходить по диагонали на любое количество клеток.
    /// </summary>
    public class Bishop : Piece
    {
        /// <summary>
        /// Инициализирует новый экземпляр слона на указанной позиции.
        /// </summary>
        /// <param name="position">Начальная позиция слона.</param>
        public Bishop(Position position) : base(position) { }

        public override string Symbol => "B";

        /// <summary>
        /// Слон атакует цель, если она находится на одной диагонали с ним и путь свободен.
        /// </summary>
        /// <param name="target">Позиция цели.</param>
        /// <param name="board">Текущее состояние доски.</param>
        /// <returns><c>true</c>, если цель может быть атакована; иначе <c>false</c>.</returns>
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