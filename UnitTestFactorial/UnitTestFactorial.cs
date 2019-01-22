using System;
using System.Numerics;
using ClassLibraryMath;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SuuS
{
    [TestClass]
    public class UnitTestFactorial
    {
        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(2, 2)]
        [DataRow(3, 6)]
        [DataRow(4, 24)]
        [DataRow(5, 120)]
        public void TestUnitTestFactorial(int pNumber, Int64 pExpectedValue)
        {
            Factorial myFact;
            myFact = new Factorial();
            Assert.AreEqual(pExpectedValue, myFact.Calculate(pNumber));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestUnitFactorialNegative()
        { 
            Factorial myFact;
            myFact = new Factorial();
            myFact.Calculate(-1);
        }

        [TestMethod]
        public void TestFactorial25BigInt()
        {
            Factorial myFact = new Factorial();
            BigInteger b = BigInteger.Parse("15511210043330985984000000");
            Assert.AreEqual(b, myFact.Calculate(25));
        }

        [TestMethod]
        public void TestPrimeNumbers()
        {
            PrimeNumber pn = new PrimeNumber();
            int[] tab = pn.FindAllPrimesEratosthenes(120);
            Assert.AreEqual(113, tab[29]); //Check du dernier prime
        }
    }
}
