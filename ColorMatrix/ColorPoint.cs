using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorMatrix
{
    class ColorPoint
    {
        public int R,G,B,X,Y;
        public int Width;

        public ColorPoint(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }

        public ColorPoint(int r)
            :this(r,0,0)
        {
            
        }

        public ColorPoint(int r, int g)
        :this(r,g,0)
        {
            
        }

        public ColorPoint()
            : this(0, 0, 0)
        {

        }
        

    }
}
