using ChessValidator.Shared.Exceptions;
using ChessValidator.Shared.Services.Logic;
using ChessValidator.Shared.Services.Parsing;
using ChessValidator.Shared.Services.Rendering;

namespace ChessValidator
{
    internal class Program
    {
        private const string FolderName = "Examples";
        private const string FileName = "too_many_pieces.txt";

        static void Main(string[] args)
        {
            try
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string inputPath = Path.Combine(baseDirectory, FolderName, FileName);

                if (!File.Exists(inputPath))
                {
                    Console.WriteLine($"Ошибка: Файл не найден по пути: {inputPath}");

                    return;
                }

                var lines = File.ReadAllLines(inputPath);

                var parser = new BoardParser();
                var board = parser.Parse(lines);

                var renderer = new BoardRenderer();
                Console.WriteLine("Состояние доски:");
                Console.WriteLine(renderer.Render(board));

                var detector = new AttackDetector();
                var attacks = detector.Detect(board);

                Console.WriteLine("\nСписок атак:");

                if (attacks.Count == 0)
                {
                    Console.WriteLine("Атак не обнаружено.");
                }
                else
                {
                    foreach (var attack in attacks)
                    {
                        Console.WriteLine(attack);
                    }
                }
            }
            catch (InvalidPositionException ex)
            {
                Console.WriteLine($"Ошибка в координатах: {ex.Message}");
            }
            catch (ChessValidationException ex)
            {
                Console.WriteLine($"Ошибка валидации: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Критическая ошибка: {ex.Message}");
            }
        }
    }
}