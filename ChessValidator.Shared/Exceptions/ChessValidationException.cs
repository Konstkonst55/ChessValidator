namespace ChessValidator.Shared.Exceptions
{
    public class ChessValidationException : Exception
    {
        public ChessValidationException() : base("Ошибка валидации шахматной доски.") { }
        public ChessValidationException(string message) : base(message) { }
        public ChessValidationException(string message, Exception inner) : base(message, inner) { }
    }
}