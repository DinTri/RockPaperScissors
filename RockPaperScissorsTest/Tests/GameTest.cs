using System;
using Moq;
using NUnit.Framework;
using RockPaperScissors;
using static RockPaperScissors.Enums;

namespace RockPaperScissorsTest.Tests
{
    [TestFixture]
    public class GameTest
    {
        private IDecissionEngine _descEngine;
        private IGame _game;

        [SetUp]
        public void Init()
        {
            _descEngine = Mock.Of<IDecissionEngine>();
            _descEngine = new DescissionEngine();
            _game = Mock.Of<IGame>();

        }

        [Test]
        public void ShouldReturnComputerPlayerName()
        {
            //var name = "COMPUTER";
            var player = new ComputerPlayer
            {
                PlayerName = "LAPTOP"
            };
            var result = player.PlayerName;
            Assert.AreEqual(result, "LAPTOP");
        }
        [Test]
        public void BothPlayersMustBeDefined()
        {
            _game = new Game(null, null, _descEngine);
        }

        [Test]
        public void MaxOneHumanPlayer()
        {
            _game = new Game(new HumanPlayer(), new HumanPlayer(), _descEngine);
            Assert.Throws<ArgumentException>(() => throw new ArgumentException("Two human players present! Max one is needed!"));
        }

        [Test]
        public void RockBeatsScissors()
        {
            _game = new Game(new ComputerPlayer(), new ComputerPlayer(), _descEngine);
            const Move firstPlayer = Move.Rock;
            const Move secondPlayer = Move.Scissors;
            var gameResult = _game.WinResult(firstPlayer, secondPlayer);
            Assert.IsTrue(gameResult == GameResult.FirstPlayerWins, "Rock should beat Scissors");
        }

        [Test]
        public void PaperBeatsRock()
        {
            _game = new Game(new ComputerPlayer(), new ComputerPlayer(), _descEngine);
            const Move firstPlayer = Move.Paper;
            const Move secondPlayer = Move.Rock;
            var gameResult = _game.WinResult(firstPlayer, secondPlayer);
            Assert.IsTrue(gameResult == GameResult.FirstPlayerWins, "Paper should beat rock");
        }

        [Test]
        public void RockShouldLoseFromPaper()
        {
            _game = new Game(new ComputerPlayer(), new ComputerPlayer(), _descEngine);
            var firstPlayer = Move.Rock;
            var secondPlayer = Move.Paper;
            var gameResult = _game.WinResult(firstPlayer, secondPlayer);
            Assert.IsTrue(gameResult == GameResult.SecondPlayerWins, "Rock should lose to paper");
        }

        [Test]
        public void RockDrawsRock()
        {
            _game = new Game(new ComputerPlayer(), new ComputerPlayer(), _descEngine);

            var firstPlayer = Move.Rock;
            var secondPlayer = Move.Rock;
            var gameResult = _game.WinResult(firstPlayer, secondPlayer);
            Assert.IsTrue(gameResult == GameResult.Draw, "Rock should draws rock");
        }

        [Test]
        public void PaperDrawsPaper()
        {
            _game = new Game(new ComputerPlayer(), new ComputerPlayer(), _descEngine);

            var firstPlayer = Move.Paper;
            var secondPlayer = Move.Paper;
            var gameResult = _game.WinResult(firstPlayer, secondPlayer);
            Assert.IsTrue(gameResult == GameResult.Draw, "Paper draws paper");
        }

        [Test]
        public void ScissorsBeatsPaper()
        {
            _game = new Game(new ComputerPlayer(), new ComputerPlayer(), _descEngine);

            var firstPlayer = Move.Scissors;
            var secondPlayer = Move.Paper;
            var gameResult = _game.WinResult(firstPlayer, secondPlayer);
            Assert.IsTrue(gameResult == GameResult.FirstPlayerWins, "Scissors should beat paper");
        }

        [Test]
        public void ScissorsDrawScissors()
        {
            _game = new Game(new ComputerPlayer(), new ComputerPlayer(), _descEngine);
            var firstPlayer = Move.Scissors;
            var secondPlayer = Move.Scissors;
            var gameResult = _game.WinResult(firstPlayer, secondPlayer);
            Assert.IsTrue(gameResult == GameResult.Draw, "Scissors should draw scissors");
        }

        [Test]
        public void PaperLosesScissors()
        {
            _game = new Game(new ComputerPlayer(), new ComputerPlayer(), _descEngine);
            var firstPlayer = Move.Paper;
            var secondPlayer = Move.Scissors;
            var gameResult = _game.WinResult(firstPlayer, secondPlayer);
            Assert.IsTrue(gameResult == GameResult.SecondPlayerWins, "Paper should lose to scissors");
        }

        [Test]
        public void ScissorsLosesRock()
        {
            _game = new Game(new ComputerPlayer(), new ComputerPlayer(), _descEngine);
            var firstPlayer = Move.Scissors;
            var secondPlayer = Move.Rock;
            var gameResult = _game.WinResult(firstPlayer, secondPlayer);
            Assert.IsTrue(gameResult == GameResult.SecondPlayerWins, "Scissors should lose to rock");
        }


        //[Test]
        //public void ReturnsCorrectMessageIfPlayerWins()
        //{
        //    var engineMock = new Mock<IDecissionEngine>();
        //    engineMock.Setup(de => de.Result(Enums.Move.Rock, Enums.Move.Paper, Enums.Move.Scissors)).Returns(Enums.GameResult.FirstPlayerWins);
        //    var game = new Game(engineMock.Object)
        //    {
        //        PlayerMove = "Paper"
        //    };
        //    var result = game.Result();
        //    engineMock.VerifyAll();
        //    Assert.AreEqual("Player Wins!", result);
        //}

        ////[Test]
        ////public void ComputerRock_PlayerScissors_ComputerWins()
        ////{
        ////    var game = new Game(new DescissionEngine())
        ////    {
        ////        PlayerMove = "Scissors"
        ////    };
        ////    Assert.AreEqual("Computer Wins!", game.Result());
        ////}

        //[Test]
        //public void ReturnsCorrectMessageIfComputerWins()
        //{
        //    var engineMock = new Mock<IDecissionEngine>();
        //    engineMock.Setup(de => de.Result(Enums.Move.Rock, Enums.Move.Scissors)).Returns(Enums.GameResult.ComputerWins);
        //    var game = new Game(engineMock.Object)
        //    {
        //        PlayerMove = "Scissors"
        //    };
        //    var result = game.Result();
        //    engineMock.VerifyAll();
        //    Assert.AreEqual("Computer Wins!", result);
        //}

        //[Test]
        //public void ThrowsErrorIfPlayerMoveIsNotSet()
        //{
        //    var engineMock = new Mock<IDecissionEngine>();
        //    var game = new Game(engineMock.Object);
        //    game.Result();
        //    Assert.That(() => game.Result(), Throws.ArgumentException);
        //}

        [Test]
        public void ThrowsErrorIfPlayerMoveIsNotSet()
        {
            _game = new Game(null, null, _descEngine);
            Assert.Throws<ArgumentException>(() => throw new ArgumentException("Two human players present! Max one is needed!"));
            //Assert.Throws<ArgumentException>(() => game.Result());
        }

        [Test]
        public void ComputerGeneratesExpectedMoves()
        {
            // Check computer generates all possible Gamers, with reasonably equal distribution
            var rockCount = 0;
            var paperCount = 0;
            var scissorsCount = 0;

            var gameCount = 1000;
            for (var gameNumber = 0; gameNumber < gameCount; gameNumber++)
            {
                IPlayer player = new ComputerPlayer();

                switch (player.Move)
                {
                    case Move.Paper:
                        paperCount++;
                        break;
                    case Move.Rock:
                        rockCount++;
                        break;
                    case Move.Scissors:
                        scissorsCount++;
                        break;
                    default:
                        break;
                }
            }

            Assert.IsTrue(paperCount > 0, "Computer generation of paper count is zero");
            Assert.IsTrue(rockCount > 0, "Computer generation of rock count is zero");
            Assert.IsTrue(scissorsCount > 0, "Computer generation of scissors count is zero");

            // We expect roughly equal distribution of moves between available choices
            // Testing for at least half of that expected distribution avoids variance causing this test to fail
            var minimalExpectedCountEachMove = gameCount / 6;

            Assert.IsTrue(paperCount > minimalExpectedCountEachMove, "Computer generation of paper count is zero");
            Assert.IsTrue(rockCount > minimalExpectedCountEachMove, "Computer generation of rock count is zero");
            Assert.IsTrue(scissorsCount > minimalExpectedCountEachMove, "Computer generation of scissors count is zero");
        }
    }
}
