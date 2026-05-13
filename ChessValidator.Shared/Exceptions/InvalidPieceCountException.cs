namespace ChessValidator.Shared.Exceptions
{
    public class InvalidPieceCountException : ChessValidationException
    {
        public InvalidPieceCountException() : base("Количество фигур должно быть от 2 до 10.") { }
        public InvalidPieceCountException(string message) : base(message) { }
    }
}