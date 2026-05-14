using ChessValidator.Shared.Exceptions;

namespace ChessValidator.Shared.Models
{
    public class Position
    {
        public int X { get; }
        public int Y { get; }

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