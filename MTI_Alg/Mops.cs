using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTI_Alg
{
    static class Mops
    {
        public static ulong mod(ulong a, ulong b)
        {
            return a % b;
        }
        public static ulong mul(ulong a, ulong b)
        {
            return a * b;
        }
        public static ulong pow(ulong a, ulong b)
        {
            ulong result = 1;
            for (ulong i = 0; i < b; i++)
                result = result * a;
            return result;
        }
        public static ulong mulMod(ulong a, ulong b, ulong n)// a*b mod n - умножение a на b по модулю n
        {
            ulong sum = 0;
            for (ulong i = 0; i < b; i++)
            {
                sum += a;
                if (sum >= n)
                {
                    sum -= n;
                }
            }
            return sum;
        }
        public static ulong powMod(ulong a, ulong b, ulong n)
        {
            ulong tmp = a;
            ulong sum = tmp;
            for (ulong i = 1; i < b; i++)
            {
                for (ulong j = 1; j < a; j++)
                {
                    sum += tmp;
                    if (sum >= n)
                    {
                        sum -= n;
                    }
                }
                tmp = sum;
            }
            return tmp;
        }

        // Вычисление первообразного корня
        // Ограничение: p - простое
        public static ulong POGen(ulong p)
        {
            List<ulong> fact = new List<ulong>();
            ulong phi = p - 1;
            ulong n = phi;
            for (ulong i = 2; i * i <= n; ++i)
                if (n % i == 0)
                {
                    fact.Add(i);
                    while (n % i == 0)
                        n /= i;
                }
            if (n > 1)
                fact.Add(n);

            for (ulong res = 2; res <= p; ++res)
            {
                bool ok = true;
                for (int i = 0; i < fact.Count() && ok; ++i)
                    ok &= powMod(res, phi / fact[i], p) != 1;
                if (ok) return res;
            }
            return 0;
        }
        public static ulong GetPRoot(ulong p)
        {
            for (ulong i = 0; i < p; i++)
                if (IsPRoot(p, i))
                    return i;
            return 0;
        }

        public static bool IsPRoot(ulong p, ulong a)
        {
            if (a == 0 || a == 1)
                return false;
            ulong last = 1;
            HashSet<ulong> set = new HashSet<ulong>();
            for (ulong i = 0; i < p - 1; i++)
            {
                last = (last * a) % p;
                if (set.Contains(last)) // Если повтор
                    return false;
                set.Add(last);
            }
            return true;
        }
    }

}
