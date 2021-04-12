using NUnit.Framework;
using RockPaperScissors;

namespace RockPaperScissorsTest.Tests
{
    [TestFixture]
    public class DescissionEngineTest
    {
        [Test]
        public void ComputerRock_PlayerPaper_FirstPlayerWins()
        {
            var engine = new DescissionEngine();
            var gameResult = engine.Result(Enums.Move.Paper, Enums.Move.Rock);
            Assert.AreEqual(Enums.GameResult.FirstPlayerWins, gameResult);
        }

        [Test]
        public void ComputerRock_PlayerScissors_SecondPlayerWins()
        {
            var engine = new DescissionEngine();
            var gameResult = engine.Result(Enums.Move.Rock, Enums.Move.Paper);
            Assert.AreEqual(Enums.GameResult.SecondPlayerWins, gameResult);
        }
    }
}
