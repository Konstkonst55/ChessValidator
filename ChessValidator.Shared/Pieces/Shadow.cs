using ChessValidator.Shared.Models;

namespace ChessValidator.Shared.Pieces
{
    /// <summary>
    /// Представляет фигуру Теника — мистическое существо, способное перемещаться по прямым линиям.
    /// </summary>
    public class Shadow : Piece
    {
        /// <summary>
        /// Инициализирует новый экземпляр Теника на указанной позиции.
        /// </summary>
        /// <param name="position">Начальная позиция Теника.</param>
        public Shadow(Position position) : base(position) { }

        public override string Symbol => "S";

        /// <summary>
        /// Теник атакует цель, если она находится на одной ортогональной или диагональной линии с ним и путь свободен.
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