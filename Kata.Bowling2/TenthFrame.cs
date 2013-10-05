using System.Linq;

namespace Kata.Bowling2
{
    public class TenthFrame : Frame
    {
        public TenthFrame(FrameBase previousFrame) : base(previousFrame)
        {
        }

        public override bool IsComplete
        {
            get
            {
                if (Throws.Count == 3)
                {
                    return true;
                }

                if (Throws.Count == 2 && Throws.Sum() < 10)
                {
                    return true;
                }

                return false;
            }
        }

        public override void RecordThrow(int pins)
        {
            if (Throws.Count <= 1)
            {
                base.RecordThrow(pins);
            }
            else
            {
                Throws.Add(pins);
            }
        }
    }
}