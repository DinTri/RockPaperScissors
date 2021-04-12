using System;

namespace RockPaperScissors
{
    public class Game : IGame
    {
        private readonly IDecissionEngine _descEngine;
        public IPlayer FirstPlayer { get; }
        public IPlayer SecondPlayer { get; }
        public Game(IPlayer player1, IPlayer player2, IDecissionEngine descEngine)
        {
            _descEngine = descEngine;
            FirstPlayer = player1;
            SecondPlayer = player2;
            if (player1 is HumanPlayer && player2 is HumanPlayer) return;
            if (FirstPlayer != null && string.IsNullOrEmpty(FirstPlayer.PlayerName))
            {
                FirstPlayer.PlayerName = "Player1";
            }

            if (SecondPlayer == null || !string.IsNullOrEmpty(SecondPlayer.PlayerName)) return;
            if (FirstPlayer != null) FirstPlayer.PlayerName = "Player2";
        }

        public Enums.GameResult WinResult()
        {
            return WinResult(FirstPlayer.Move, SecondPlayer.Move);
        }
        public Enums.GameResult WinResult(Enums.Move firstPlayer, Enums.Move secondPlayer)
        {
            var gameResult = Enums.GameResult.Draw;
            var k = _descEngine.Result(firstPlayer, secondPlayer);
            if (k == Enums.GameResult.FirstPlayerWins)
            {
                gameResult = Enums.GameResult.FirstPlayerWins;
                return gameResult;
            }
            if (k == Enums.GameResult.SecondPlayerWins)
            {
                gameResult = Enums.GameResult.SecondPlayerWins;
                return gameResult;
            }

            if (k != Enums.GameResult.ComputerWins) return gameResult;
            gameResult = Enums.GameResult.ComputerWins;
            return gameResult;
        }

    }
}
