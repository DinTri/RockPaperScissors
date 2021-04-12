using System;

namespace RockPaperScissors
{
    public class ComputerPlayer : Player, IPlayer
    {
        private static readonly Array Values = Enum.GetValues(typeof(Enums.Move));
        private static readonly Random RandomGame = new();

        public ComputerPlayer()
        {
            this.GetMove();
        }

        public Enums.Move GetMove()
        {
            var randomMove = (Enums.Move)Values.GetValue(RandomGame.Next(Values.Length));


            Move = randomMove;
            return randomMove;
        }
    }
}
