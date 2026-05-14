using ChessValidator.Shared.Models;

namespace ChessValidator.Shared.Pieces
{
    /// <summary>
    /// Представляет фигуру коня. Конь ходит буквой "Г" (2+1 или 1+2) и может перепрыгивать через другие фигуры.
    /// </summary>
    public class Knight : Piece
    {
        /// <summary>
        /// Инициализирует новый экземпляр коня на указанной позиции.
        /// </summary>
        /// <param name="position">Начальная позиция коня.</param>
        public Knight(Position position) : base(position) { }

        public override string Symbol => "N";

        /// <summary>
        /// Конь атакует цель буквой "Г": смещение на 2 клетки по одной оси и на 1 по другой.
        /// Препятствия на пути не учитываются.
        /// </summary>
        /// <param name="target">Позиция цели.</param>
        /// <param name="board">Текущее состояние доски.</param>
        /// <returns><c>true</c>, если цель может быть атакована; иначе <c>false</c>.</returns>
        public override bool CanAttack(Position target, ChessBoard board)
        {
            int dx = Math.Abs(Position.X - target.X);
            int dy = Math.Abs(Position.Y - target.Y);

            return (dx == 2 && dy == 1) || (dx == 1 && dy == 2);
        }
    }
}