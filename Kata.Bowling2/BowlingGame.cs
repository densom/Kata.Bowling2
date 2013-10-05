using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Bowling2
{
    public class BowlingGame
    {
        private readonly List<FrameBase> _frames = new List<FrameBase>();

        public BowlingGame()
        {
            _frames.Add(new NullFrame());
        }

        public void Roll(int pinsKnockedDown)
        {
            AddNewFrameIfLastFrameComplete();
            _frames.Last().RecordThrow(pinsKnockedDown);
        }

        private void AddNewFrameIfLastFrameComplete()
        {
            var previousFrame = _frames.Last();

            if (previousFrame.IsComplete)
            {
                if (previousFrame.FrameNumber == 9)
                {
                    _frames.Add(new TenthFrame(previousFrame));
                    return;
                }

                _frames.Add(new Frame(previousFrame));
            }
        }

        public int? Score()
        {
            return _frames.Last().Score();
        }


    }
}