using System;
using NUnit.Framework;

namespace Kata.Bowling2.Tests
{
    [TestFixture]
    public class FrameTests
    {
        [Test]
        [TestCase(9, false)]
        [TestCase(10, true)]
        public void IsStrike_DetectsStrikes(int pins, bool isStrikeExpected)
        {
            var frame = new Frame();
            frame.RecordThrow(pins);

            Assert.That(frame.IsStrike(), Is.EqualTo(isStrikeExpected));
        }

        [Test]
        [TestCase(1, 1, false)]
        [TestCase(9, 1, true)]
        public void IsStrike_DetectsSpares(int throw1, int throw2, bool isSpareExpected)
        {
            var frame = new Frame();
            frame.RecordThrow(throw1);
            frame.RecordThrow(throw2);

            Assert.That(frame.IsSpare(), Is.EqualTo(isSpareExpected));
        }

        [Test]
        public void Score_SpareRecordsBonusThrow()
        {
            var frame1 = new Frame();
            frame1.RecordThrow(9);
            frame1.RecordThrow(1);

            var frame2 = new Frame(frame1);
            frame2.RecordThrow(1);

            Assert.That(frame1.Score(), Is.EqualTo(11));

        }

        [Test]
        public void Score_StrikeFollowedByTwoNormalThrows_StrikeRecordsTwoBonusThrows()
        {
            var frame1 = new Frame();
            frame1.RecordThrow(10); //strike
            
            var frame2 = new Frame(frame1);
            frame2.RecordThrow(1);
            frame2.RecordThrow(1);

            Assert.That(frame1.Score(), Is.EqualTo(12));
            Assert.That(frame2.Score(), Is.EqualTo(14));

        }

        [Test]
        [Ignore]
        public void Score_TwoStrikesInARow_StrikeRecordsTwoBonusThrows()
        {
            throw new NotImplementedException();
        }

       /* [Test]
        public void PendingBonusThrows_OpenFrame_EqualsZero()
        {
            var frame1 = new Frame();
            frame1.RecordThrow(10);

            Assert.That(frame1.PendingBonusThrows, Is.EqualTo(2));
        }*/


        [Test]
        public void FrameNumber_IncrementsByOneOnNewFrame()
        {
            var frame1 = new Frame();
            Assert.That(frame1.FrameNumber, Is.EqualTo(1));

            var frame2 = new Frame(frame1);
            Assert.That(frame2.FrameNumber, Is.EqualTo(2));
        }

        [Test]
        public void IsComplete_OneNormalThrow_False()
        {
            var frame = new Frame();
            frame.RecordThrow(1);
            Assert.That(frame.IsComplete, Is.False);
        }

        [Test]
        public void IsComplete_TwoNormalThrows_True()
        {
            var frame = new Frame();
            frame.RecordThrow(1);
            frame.RecordThrow(1);
            Assert.That(frame.IsComplete, Is.True);
        }

        [Test]
        public void IsComplete_Spare_True()
        {
            var frame = new Frame();
            frame.RecordThrow(9);
            frame.RecordThrow(1);
            Assert.That(frame.IsComplete, Is.True);
        }

        [Test]
        public void IsComplete_Strike_True()
        {
            var frame = new Frame();
            frame.RecordThrow(10);
            Assert.That(frame.IsComplete, Is.True);
        }

        [Test]
        public void IsComplete_ScoreReturnsNullWhenFalse()
        {
            var frame = new Frame();
            frame.RecordThrow(5);
            Assert.That(frame.Score(), Is.Null);
        }




    }
}