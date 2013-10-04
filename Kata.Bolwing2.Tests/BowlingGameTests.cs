using NUnit.Framework;

namespace Kata.Bowling2.Tests
{
    [TestFixture]
    public class BowlingGameTests
    {
        [Test]
        [TestCase(new[] {1,1}, 2)]
        public void Score_OpenFrame_ScoresPinsKnockedDown(int[] rolls, int expectedScore)
        {
            var game = new BowlingGame();
            var rollHelper = new RollHelper(game);
            rollHelper.RollAll(rolls);
            
            Assert.That(game.Score(), Is.EqualTo(expectedScore));
        }


    }
}
