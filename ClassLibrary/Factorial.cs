using System;
using System.Numerics;

namespace ClassLibraryMath
{
    public class Factorial
    {
        public Factorial()
        {
        }

        public BigInteger CalculateRecursive(int pNumber)
        {
            if (pNumber < 0)
                throw new ArgumentOutOfRangeException();

            return pNumber > 0 ? pNumber * CalculateRecursive(pNumber - 1) : 1;
        }
        public BigInteger Calculate(int pNumber)
        {
            if (pNumber < 0)
                throw new ArgumentOutOfRangeException();

            if (pNumber > 0)
            {
                BigInteger result = 1;

                for (int i = 1; i <= pNumber; i++)
                {
                    result *= i;
                }

                return result;
            }
            else
            {
                return 1;
            }
        }
    }
}