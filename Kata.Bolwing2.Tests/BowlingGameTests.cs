using NUnit.Framework;

namespace Kata.Bowling2.Tests
{
    [TestFixture]
    public class BowlingGameTests
    {
        private BowlingGame _game;
        private RollHelper _rollHelper;

        [SetUp]
        public virtual void SetUp()
        {
            _game = new BowlingGame();
            _rollHelper = new RollHelper(_game);
        }

        [Test]
        [TestCase(new[] {1}, null)]
        [TestCase(new[] {1,1}, 2)]
        public void Score_OpenFrame_ScoresPinsKnockedDown(int[] rolls, int? expectedScore)
        {
            _rollHelper.RollAll(rolls);
            Assert.That(_game.Score(), Is.EqualTo(expectedScore));
        }

        [Test]
        public void Score_Spare_GetsOneBonusBall()
        {
            _rollHelper.RollAll(new[] {9,1,2,0});
            Assert.That(_game.Score(), Is.EqualTo(14));
        }

        [Test]
        [TestCase(new[] {1}, null)]
        [TestCase(new[] {1,1}, 2)]
//        [TestCase(new[] {1,1}, 2)]
        public void Score_CalculatesAtEndOfFrame_OpenFrame(int[] rolls, int? expectedScore)
        {
            _rollHelper.RollAll(rolls);
            Assert.That(_game.Score(), Is.EqualTo(expectedScore));
        }

    }
}
