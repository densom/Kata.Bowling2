using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Bowling2
{
    public class BowlingGame
    {
        private readonly List<IFrame> _frames = new List<IFrame>();

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
            if (_frames.Last().IsComplete)
            {
                _frames.Add(new Frame(_frames.Last()));
            }
        }

        public int? Score()
        {
            return _frames.Last().Score();
        }


    }
}