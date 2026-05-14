using ChessValidator.Shared.Exceptions;

namespace ChessValidator.Shared.Models
{
    /// <summary>
    /// Представляет координаты клетки на шахматной доске.
    /// </summary>
    public class Position
    {
        /// <summary>
        /// Координата X (горизонталь, 0-7 слева направо).
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Координата Y (вертикаль, 0-7 снизу вверх).
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Position"/> с указанными координатами.
        /// </summary>
        /// <exception cref="InvalidPositionException">Выбрасывается, если координаты выходят за пределы доски 8x8.</exception>
        public Position(int x, int y)
        {
            if (x < 0 || x > 7 || y < 0 || y > 7)
            {
                throw new InvalidPositionException();
            }

            X = x;
            Y = y;
        }
    }
}