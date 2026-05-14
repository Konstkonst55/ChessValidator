using ChessValidator.Shared.Models;

namespace ChessValidator.Shared.Pieces
{
    /// <summary>
    /// Абстрактный базовый класс для всех шахматных фигур.
    /// </summary>
    public abstract class Piece
    {
        /// <summary>
        /// Текущая позиция фигуры на доске.
        /// </summary>
        public Position Position { get; }

        /// <summary>
        /// Инициализирует новый экземпляр фигуры с указанной позицией.
        /// </summary>
        /// <param name="position">Начальная позиция фигуры.</param>
        protected Piece(Position position) => Position = position;

        /// <summary>
        /// Определяет, может ли данная фигура атаковать указанную цель.
        /// </summary>
        /// <param name="target">Позиция цели для атаки.</param>
        /// <param name="board">Текущее состояние шахматной доски.</param>
        /// <returns><c>true</c>, если фигура может атаковать цель; иначе <c>false</c>.</returns>
        public abstract bool CanAttack(Position target, ChessBoard board);

        /// <summary>
        /// Символ фигуры для отображения на доске.
        /// </summary>
        public abstract string Symbol { get; }

        /// <summary>
        /// Проверяет возможность атаки по ортогональной линии (горизонталь/вертикаль) с учётом препятствий.
        /// </summary>
        /// <param name="target">Позиция цели.</param>
        /// <param name="board">Текущее состояние доски.</param>
        /// <returns><c>true</c>, если цель достижима по прямой без препятствий; иначе <c>false</c>.</returns>
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

        /// <summary>
        /// Проверяет возможность атаки по диагональной линии с учётом препятствий.
        /// </summary>
        /// <param name="target">Позиция цели.</param>
        /// <param name="board">Текущее состояние доски.</param>
        /// <returns><c>true</c>, если цель достижима по диагонали без препятствий; иначе <c>false</c>.</returns>
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

        /// <summary>
        /// Проверяет, свободен ли путь от текущей позиции до цели в указанном направлении.
        /// </summary>
        /// <param name="target">Позиция цели.</param>
        /// <param name="board">Текущее состояние доски.</param>
        /// <param name="dx">Направление движения по оси X (-1, 0, 1).</param>
        /// <param name="dy">Направление движения по оси Y (-1, 0, 1).</param>
        /// <returns><c>true</c>, если путь до цели свободен (не включая клетку с целью); иначе <c>false</c>.</returns>
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