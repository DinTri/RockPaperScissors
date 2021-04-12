namespace RockPaperScissors
{
    public interface IGame //: IDecissionEngine
    {
        IPlayer FirstPlayer { get; }
        IPlayer SecondPlayer { get; }
        Enums.GameResult WinResult();
        public Enums.GameResult WinResult(Enums.Move firstPlayer, Enums.Move secondPlayer);
    }
}
