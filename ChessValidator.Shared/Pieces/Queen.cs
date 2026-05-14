using ChessValidator.Shared.Models;

namespace ChessValidator.Shared.Pieces
{
    /// <summary>
    /// Представляет фигуру ферзя. Ферзь может ходить по горизонтали, вертикали и диагонали на любое количество клеток.
    /// </summary>
    public class Queen : Piece
    {
        /// <summary>
        /// Инициализирует новый экземпляр ферзя на указанной позиции.
        /// </summary>
        /// <param name="position">Начальная позиция ферзя.</param>
        public Queen(Position position) : base(position) { }

        public override string Symbol => "Q";

        /// <summary>
        /// Ферзь атакует цель, если она находится на одной ортогональной или диагональной линии с ним и путь свободен.
        /// </summary>
        /// <param name="target">Позиция цели.</param>
        /// <param name="board">Текущее состояние доски.</param>
        /// <returns><c>true</c>, если цель может быть атакована; иначе <c>false</c>.</returns>
        public override bool CanAttack(Position target, ChessBoard board)
        {
            return IsOrthogonalAttack(target, board) || IsDiagonalAttack(target, board);
        }
    }
}