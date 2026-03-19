using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dobokocka.Models
{
    public class Roll
    {
        public int[] DiceValues { get; }
        public int Bet { get; }
        public int Multiplier { get; }

        public Roll(int[] diceValues, int bet, int multiplier)
        {
            DiceValues = diceValues;
            Bet = bet;
            Multiplier = multiplier;
        }
    }
}
