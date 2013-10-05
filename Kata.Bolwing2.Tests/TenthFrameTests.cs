using NUnit.Framework;

namespace Kata.Bowling2.Tests
{
    [TestFixture]
    public class TenthFrameTests
    {

        [Test]
        public void TenthFrame_SpareAndBonusBall()
        {
            var tenthFrame = new TenthFrame(new NullFrame());
            tenthFrame.RecordThrow(9);
            tenthFrame.RecordThrow(1);
            tenthFrame.RecordThrow(1);

            Assert.That(tenthFrame.Score(), Is.EqualTo(11));
        }

        [Test]
        public void TenthFrame_Turkey()
        {
            var tenthFrame = new TenthFrame(new NullFrame());

            tenthFrame.RecordThrow(10);
            tenthFrame.RecordThrow(10);
            tenthFrame.RecordThrow(10);

            Assert.That(tenthFrame.Score(), Is.EqualTo(30));
        }

        [Test]
        public void TenthFrame_OpenFrame()
        {
            var tenthFrame = new TenthFrame(new NullFrame());

            tenthFrame.RecordThrow(1);
            tenthFrame.RecordThrow(1);

            Assert.That(tenthFrame.Score(), Is.EqualTo(2));
        }
    }
}