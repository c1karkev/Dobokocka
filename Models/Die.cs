using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Dobokocka.Models
{
    public class Die
    {
        private Brush[] _colors = new Brush[] { Brushes.NavajoWhite, Brushes.LightGreen, Brushes.PaleVioletRed, Brushes.WhiteSmoke, Brushes.Wheat, Brushes.LightBlue };

        private static Random r = new Random();

        public int Value { get; set; }
        public Brush Color { get; set; }

        public Die() {
            Roll();
            Color = _colors[r.Next(0, _colors.Length)];
        }

        public int Roll()
        {
            Value = r.Next(1, 7);
            return Value;
        }
    }
}
