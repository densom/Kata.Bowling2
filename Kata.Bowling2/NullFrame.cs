namespace Kata.Bowling2
{
    public class NullFrame : IFrame
    {
        public int? Score()
        {
            return 0;
        }

        public bool IsStrike()
        {
            return false;
        }

        public bool IsSpare()
        {
            return false;
        }

        public void AddBonusBall(int pins)
        {
            return;
        }

        public int FrameNumber
        {
            get { return 0; }
        }

        public bool IsComplete
        {
            get { return true; }
        }

        public void RecordThrow(int pins)
        {
            
        }
    }
}