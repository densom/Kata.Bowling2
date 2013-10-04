using System.Collections.Generic;

namespace Kata.Bowling2.Tests
{
    public class RollHelper
    {
        public BowlingGame Game { get; private set; }

        public RollHelper(BowlingGame game)
        {
            Game = game;
        }

        public void RollAll(IEnumerable<int> rolls)
        {
            foreach (var roll in rolls)
            {
                Game.Roll(roll);
            }
        }
    }
}