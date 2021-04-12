using static RockPaperScissors.Enums;

namespace RockPaperScissors
{
    public class DescissionEngine : IDecissionEngine
    {
        public Enums.GameResult Result(Enums.Move firstPlayer, Enums.Move secondPlayer)
        {

            var result = GameResult.ComputerWins;

            if ((firstPlayer == Move.Paper && secondPlayer == Move.Rock) ||
                (firstPlayer == Move.Rock && secondPlayer == Move.Scissors) ||
                (firstPlayer == Move.Scissors && secondPlayer == Move.Paper))
            {
                result = GameResult.FirstPlayerWins;
            }

            if ((firstPlayer == Move.Rock && secondPlayer == Move.Paper) ||
                (firstPlayer == Move.Scissors && secondPlayer == Move.Rock) ||
                (firstPlayer == Move.Paper && secondPlayer == Move.Scissors))
            {
                result = GameResult.SecondPlayerWins;
            }
            else if ((firstPlayer == Move.Rock && secondPlayer == Move.Rock) ||
                     (firstPlayer == Move.Scissors && secondPlayer == Move.Scissors) ||
                     (firstPlayer == Move.Paper && secondPlayer == Move.Paper))
            {
                result = GameResult.Draw;
            }

            return result;
        }
    }
}
