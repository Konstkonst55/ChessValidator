using ChessValidator.Shared.Models;

namespace ChessValidator.Shared.Pieces
{
    /// <summary>
    /// Представляет фигуру короля. Король может перемещаться на одну клетку в любом направлении.
    /// </summary>
    public class King : Piece
    {
        /// <summary>
        /// Инициализирует новый экземпляр короля на указанной позиции.
        /// </summary>
        /// <param name="position">Начальная позиция короля.</param>
        public King(Position position) : base(position) { }

        public override string Symbol => "K";

        /// <summary>
        /// Король атакует любую клетку на расстоянии 1 по вертикали, горизонтали или диагонали.
        /// </summary>
        /// <param name="target">Позиция цели.</param>
        /// <param name="board">Текущее состояние доски.</param>
        /// <returns><c>true</c>, если цель находится на расстоянии 1 клетки от короля; иначе <c>false</c>.</returns>
        public override bool CanAttack(Position target, ChessBoard board)
        {
            return Math.Abs(Position.X - target.X) <= 1 && Math.Abs(Position.Y - target.Y) <= 1;
        }
    }
}