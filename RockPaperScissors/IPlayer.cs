namespace RockPaperScissors
{
    public interface IPlayer
    {
        public string PlayerName { get; set; }

        public Enums.Move Move { get; set; }
    }
}
