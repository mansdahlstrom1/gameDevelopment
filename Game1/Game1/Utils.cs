using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Utils
    {

        public int[] centerText(int textHeight, int textWidth)
        {
            int[] postition = new int[2];
            // TOP
            postition[0] = (textHeight - 40) / 2;

            postition[1] = (textWidth - 100) / 2;

            return postition;
        }
    }
}
