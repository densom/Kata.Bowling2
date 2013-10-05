using System.Collections.Generic;

namespace Kata.Bowling2.Tests
{
    public class RollHelper
    {
        public RollHelper(BowlingGame game)
        {
            Game = game;
        }

        public BowlingGame Game { get; private set; }

        public void RollAll(IEnumerable<int> rolls)
        {
            foreach (int roll in rolls)
            {
                Game.Roll(roll);
            }
        }
    }
}