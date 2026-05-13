namespace ChessValidator.Shared.Exceptions
{
    public class InvalidPositionException : ChessValidationException
    {
        public InvalidPositionException() : base("Координаты фигуры выходят за пределы доски 8x8.") { }
        public InvalidPositionException(string message) : base(message) { }
    }
}