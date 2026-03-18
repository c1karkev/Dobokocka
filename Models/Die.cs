using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dobokocka.Models
{
    public class Die
    {
        private static Random r = new Random();

        public int Value { get; set; } = 1;
        public int Roll()
        {
            Value = r.Next(1, 7);
            return Value;
        }
    }
}
