using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTI_Alg
{
    internal class Randomer
    {
        uint state0 = 1;
        uint state1 = 2;
        public uint Generate()
        {
            uint s1 = state0;
            uint s0 = state1;
            state0 = s0;
            s1 ^= s1 << 51;
            s1 ^= s1 >> 71;
            s1 ^= s0;
            s1 ^= s0 >> 92;
            state1 = s1;
            return (state0 + state1) % 11;
        }
    }
}
