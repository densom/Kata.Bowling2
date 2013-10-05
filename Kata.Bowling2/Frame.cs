using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Bowling2
{
    public class Frame : IFrame
    {
        private readonly List<int> _throws = new List<int>();
        private readonly List<int> _bonusBalls = new List<int>();
        private readonly IFrame _previousFrame;

        public Frame()
        {
            _previousFrame = new NullFrame();
            FrameNumber = 1;
        }

        public Frame(IFrame previousFrame)
        {
            _previousFrame = previousFrame;
            FrameNumber = _previousFrame.FrameNumber + 1;
        }

        public int FrameNumber { get; private set; }
        public bool IsComplete
        {
            get
            {
                if (_throws.Count == 2 || IsStrike())
                {
                    return true;
                }

                return false;
            }
        }

        public IFrame PreviousFrame { get { return _previousFrame; } }

        public void RecordThrow(int pins)
        {
            _throws.Add(pins);

            if (_previousFrame.IsSpare())
            {
                _previousFrame.AddBonusBall(pins);
            }

            if (_previousFrame.IsStrike())
            {
                _previousFrame.AddBonusBall(pins);

                if (_previousFrame.PreviousFrame.IsStrike())
                {
                    _previousFrame.PreviousFrame.AddBonusBall(pins);
                }
            }

        }

        // todo: make it so this is no longer public
        public virtual void AddBonusBall(int pins)
        {
            _bonusBalls.Add(pins);

        }

        public virtual int? Score()
        {
            if (!IsComplete)
            {
                return null;
            }

            return _throws.Sum() + _bonusBalls.Sum() + _previousFrame.Score();
        }

        public bool IsStrike()
        {
            if (_throws.Count == 1 && _throws.Sum() == 10)
            {
                return true;
            }

            return false;
        }

        public bool IsSpare()
        {
            if (_throws.Count == 2 && _throws.Sum() == 10)
            {
                return true;
            }

            return false;
        }
    }
}