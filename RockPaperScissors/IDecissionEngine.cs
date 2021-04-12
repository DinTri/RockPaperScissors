namespace RockPaperScissors
{
    public interface IDecissionEngine
    {
        Enums.GameResult Result(Enums.Move firstPlayer, Enums.Move secondPlayer);
    }
}
