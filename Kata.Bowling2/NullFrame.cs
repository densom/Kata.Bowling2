namespace Kata.Bowling2
{
    public class NullFrame : FrameBase
    {
        public override int? Score()
        {
            return 0;
        }

        public override bool IsStrike()
        {
            return false;
        }

        public override bool IsSpare()
        {
            return false;
        }

        internal override void AddBonusBall(int pins)
        {
            return;
        }

        public override bool IsComplete
        {
            get { return true; }
        }


        public override void RecordThrow(int pins)
        {
            
        }
    }
}