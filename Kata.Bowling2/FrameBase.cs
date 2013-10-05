using System.Collections.Generic;

namespace Kata.Bowling2
{
    public abstract class FrameBase
    {
        private readonly List<int> _throws = new List<int>();
        private readonly List<int> _bonusBalls = new List<int>();

        protected List<int> Throws { get { return _throws; } }
        protected List<int> BonusBalls { get { return _bonusBalls; } } 

        public abstract int? Score();
        public abstract bool IsStrike();
        public abstract bool IsSpare();
        internal abstract void AddBonusBall(int pins);
        public int FrameNumber { get; protected set; }
        public abstract bool IsComplete { get; }
        internal FrameBase PreviousFrame { get;  set; }
        public abstract void RecordThrow(int pins);
    }
}