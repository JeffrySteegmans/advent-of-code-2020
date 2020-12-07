using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventOfCode.Domain
{
    public class Slope
    {
        public int Right { get; private set; }
        public int Down { get; private set; }

        public Slope(int right, int down)
        {
            Right = right;
            Down = down;
        }
    }
}
