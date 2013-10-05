using System.Linq;

namespace Kata.Bowling2
{
    public class Frame : FrameBase
    {
        public Frame()
        {
            PreviousFrame = new NullFrame();
            FrameNumber = 1;
        }

        public Frame(FrameBase previousFrame)
        {
            PreviousFrame = previousFrame;
            FrameNumber = PreviousFrame.FrameNumber + 1;
        }

        public override bool IsComplete
        {
            get
            {
                if (Throws.Count == 2 || IsStrike())
                {
                    return true;
                }

                return false;
            }
        }

        public override void RecordThrow(int pins)
        {
            Throws.Add(pins);
            AddBonusPointsToPreviousFrames(pins);
        }

        private void AddBonusPointsToPreviousFrames(int pins)
        {
            if (PreviousFrame.IsSpare() && IsFirstThrow())
            {
                PreviousFrame.AddBonusBall(pins);
            }

            if (PreviousFrame.IsStrike())
            {
                PreviousFrame.AddBonusBall(pins);

                if (PreviousFrame.PreviousFrame.IsStrike() && IsFirstThrow())
                {
                    PreviousFrame.PreviousFrame.AddBonusBall(pins);
                }
            }
        }

        private bool IsFirstThrow()
        {
            return Throws.Count == 1;
        }

        internal override void AddBonusBall(int pins)
        {
            BonusBalls.Add(pins);
        }

        public override int? Score()
        {
            //todo: frame 10 is not showing complete after 3 throws
            if (!IsComplete)
            {
                return null;
            }

            return Throws.Sum() + BonusBalls.Sum() + PreviousFrame.Score();
        }

        public override bool IsStrike()
        {
            if (Throws.Count == 1 && Throws.Sum() == 10)
            {
                return true;
            }

            return false;
        }

        public override bool IsSpare()
        {
            if (Throws.Count == 2 && Throws.Sum() == 10)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return string.Format("Frame {0}: Score {1}", FrameNumber, Score());
        }
    }
}