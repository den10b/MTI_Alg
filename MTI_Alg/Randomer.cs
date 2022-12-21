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
        public uint GenLil(int limit)
        {
            uint s1 = 1;
            uint s = 0;
            while ((s >= limit)|(s<=2))
                {
                s = Generate(s)%100;
            }
            return s;
        }
        public uint GenNew(int times)
        {
            uint s1 = 15;
            uint s = 11;
            for (int i = 0; i < times; i++)
            {   
                s1 = Generate(s, s1);
                s = Generate(s, s1);
            }
            return s;
        }
        public uint Generate(uint sstt1)
        {
            uint s1 = state0;
            uint s0 = state1;
            state0 = s0;
            s1 ^= s1 << 51;
            s1 ^= s1 >> 71;
            s1 ^= s0;
            s1 ^= s0 >> 92;
            state1 = s1;
            return state1;
        }
        public uint Generate(uint sstt1,uint sstt2)
        {
            uint s1 = state0;
            uint s0 = state1;
            state0 = s0;
            s1 ^= s1 << 51;
            s1 ^= s1 >> 71;
            s1 ^= s0;
            s1 ^= s0 >> 92;
            state1 = s1;
            return state1;
        }
    }
}
