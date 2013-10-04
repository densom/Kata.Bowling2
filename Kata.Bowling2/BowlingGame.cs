using System;
using System.Collections.Generic;

namespace Kata.Bowling2
{
    public class BowlingGame
    {
        private int _score;
        private bool _isFirstBall;
        private Queue<int> _bonusSpareBalls = new Queue<int>();

        public BowlingGame()
        {
            _isFirstBall = true;
        }

        internal int CurrentFrameScore { get; private set; }

        public void Roll(int pinsKnockedDown)
        {
            _isFirstBall = !_isFirstBall;

            CalculateCurrentFrameScore(pinsKnockedDown);

            ScorePendingBonusBalls();

            if (IsSpare(pinsKnockedDown))
            {
                _bonusSpareBalls.Enqueue(pinsKnockedDown);
            }

            _score += pinsKnockedDown;

        }

        private void ScorePendingBonusBalls()
        {
            if (_bonusSpareBalls.Count > 0)
            {
                _score += _bonusSpareBalls.Dequeue();
            }
            
        }

        private void CalculateCurrentFrameScore(int pinsKnockedDown)
        {
            if (_isFirstBall)
            {
                CurrentFrameScore = 0;
            }
            else
            {
                CurrentFrameScore += pinsKnockedDown;
            }
        }

        private bool IsSpare(int pinsKnockedDown)
        {
            return (CurrentFrameScore + pinsKnockedDown) == 10;
        }

        public int? Score()
        {
            if (!_isFirstBall)
            {
                return null;
            }
            return _score;
        }

        internal bool IsFirstBall()
        {
            return _isFirstBall;
        }

    }
}