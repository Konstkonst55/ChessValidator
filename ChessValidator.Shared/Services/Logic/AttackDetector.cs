using ChessValidator.Shared.Models;

namespace ChessValidator.Shared.Services.Logic
{
    /// <summary>
    /// Реализация детектора атак, проверяющего попарно все фигуры на доске.
    /// </summary>
    public class AttackDetector : IAttackDetector
    {
        /// <summary>
        /// Попарно проверяет все фигуры на доске и формирует список обнаруженных атак.
        /// Каждая пара (A, B) проверяется: может ли фигура A атаковать позицию фигуры B.
        /// </summary>
        /// <param name="board">Шахматная доска с размещёнными фигурами.</param>
        /// <returns>Список строк с описанием атак в формате "ТипАтакующего (x,y) -> ТипЦели (x,y)".</returns>
        public List<string> Detect(ChessBoard board)
        {
            var result = new List<string>();

            foreach (var attacker in board.Pieces)
            {
                foreach (var target in board.Pieces)
                {
                    if (attacker == target)
                    {
                        continue;
                    }

                    if (attacker.CanAttack(target.Position, board))
                    {
                        result.Add($"{attacker.GetType().Name} ({attacker.Position.X},{attacker.Position.Y}) -> {target.GetType().Name} ({target.Position.X},{target.Position.Y})");
                    }
                }
            }

            return result;
        }
    }
}