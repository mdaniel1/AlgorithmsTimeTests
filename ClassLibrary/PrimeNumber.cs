using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryMath
{
    public class PrimeNumber
    {
        public PrimeNumber()
        {

        }

        public int[] FindAllPrimesHomemade(int Max)
        {
            List<int> listPrimes = new List<int>();
            
            for(int cpt = 2; cpt < Max; cpt++)
            {
                //Console.WriteLine($"Testing {cpt}...");
                if (isPrime(cpt))
                    listPrimes.Add(cpt);
            }

            return listPrimes.ToArray();
        }

        private bool isPrime(int number)
        {
            if (number <= 1)
                return false;

            for (int cpt = 2; cpt < number; cpt++)
                if (number % cpt == 0)
                    return false;

            return true;
        }

        public int[] FindAllPrimesEratosthenes(int Max)
        {
            bool[] Primes = new bool[Max + 1];
            Primes[0] = false; //Must manually put those two values at false as we start the iterator at 2
            Primes[1] = false;

            //Primes = Primes.Select(n => true).ToArray(); // OutOfMemoryException with Max = 1 billion
            for (int i = 2; i < Primes.Length; i++) //The loop takes the same time as the instruction using LINQ, but it takes way less RAM.
            {
                Primes[i] = true;
            }

            int iterator = 2;
            double end = Math.Sqrt(Max); //Another way of speeding the process : Not looping through redundant values
            while(iterator <= end)
            {
                if(Primes[iterator])
                {
                    for (int i = iterator*2; i <= Max; i += iterator)
                    {
                        Primes[i] = false;
                    }
                }
                iterator++;
            }

            List<int> listPrimes = new List<int>();
            for (int i = 0; i < Primes.Length; i++)
            {
                if (Primes[i])
                    listPrimes.Add(i); //As the tab only has true or false as value, the one that stayed as true as prime numbers, the prime number being the index.
            }

            return listPrimes.ToArray();
        }
    }
}
