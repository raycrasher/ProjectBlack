using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlack
{
    public static class Util
    {
        public static void Swap<T>(ref T a, ref T b) {
            T c = a;
            a = b;
            b = c;
        }
    }
}
