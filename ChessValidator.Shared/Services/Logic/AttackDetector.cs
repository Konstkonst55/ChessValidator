using ChessValidator.Shared.Models;

namespace ChessValidator.Shared.Services.Logic
{
    public class AttackDetector : IAttackDetector
    {
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