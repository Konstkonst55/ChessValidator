namespace ChessValidator.Shared.Exceptions
{
    public class DuplicatePositionException : ChessValidationException
    {
        public DuplicatePositionException() : base("На одной клетке не может быть две фигуры.") { }
        public DuplicatePositionException(string message) : base(message) { }
    }
}