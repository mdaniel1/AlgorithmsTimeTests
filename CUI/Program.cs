using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClassLibraryMath;

namespace CUI
{
    class Program
    {
        private const int NUMBER_DASH = 32;
        private const int NUMBER_BLANK = 11;

        static void Main(string[] args)
        {
            ShowMenu();
        }

        private static void ShowMenu()
        {
            ConsoleKeyInfo cki;
            do
            {
                Console.WriteLine("\n{0}MAIN MENU{0}", new string(' ', NUMBER_BLANK));
                Console.WriteLine("{0}", new string('-', NUMBER_DASH));
                Console.WriteLine("    1) Calculate factorial\n    2) Calculate prime number\n    3) Test strings");
                Console.WriteLine("{0}", new string('-', NUMBER_DASH));
                cki = Console.ReadKey();
                Console.Clear();
            }
            while (cki.Key != ConsoleKey.D1 &&
            cki.Key != ConsoleKey.D2 &&
            cki.Key != ConsoleKey.NumPad1 &&
            cki.Key != ConsoleKey.NumPad2 &&
            cki.Key != ConsoleKey.D3 &&
            cki.Key != ConsoleKey.NumPad3);

            switch (cki.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    DoFactorial();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    DoPrimeNumber();
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    DoStringBuilder();
                    break;
            }
        }

        static void DoFactorial()
        {
            Console.Write("Factorial to process : ");
            Factorial myFact = new Factorial();
            int number = int.Parse(Console.ReadLine());

            //Non-recursive
            WarningMessage();
            var watch = Stopwatch.StartNew();
            BigInteger result = myFact.CalculateRecursive(number);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            Console.WriteLine($"\n Elapsed time : {elapsedMs}ms\n-------------------------------------------------\n{result}\n-------------------------------------------------");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();


        }

        static void DoPrimeNumber()
        {
            Console.Write("Calculate prime numbers until : ");
            int number = int.Parse(Console.ReadLine());

            PrimeNumber pn = new PrimeNumber();
            WarningMessage();
            var watch = Stopwatch.StartNew();
            var result = pn.FindAllPrimesEratosthenes(number);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"\n Elapsed time : {elapsedMs} ms\n Number of occurences : {result.Count()}\n-------------------------------------------------\n ");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static void DoStringBuilder()
        {
            string test = "";
            StringBuilder sb = new StringBuilder();

            Console.Write("Number of times 'a' will be appended : ");
            int number = int.Parse(Console.ReadLine());

            WarningMessage();

            Console.WriteLine("\n---TESTING WITH STRING---");
            var watch = Stopwatch.StartNew();
            for (int i = 0; i < number; i++)
            {
                test += 'a';
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"\n Elapsed time : {elapsedMs} ms\n-------------------------------------------------\n ");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();

            Console.WriteLine("\n---TESTING WITH STRINGBUILDER---");
            watch = Stopwatch.StartNew();
            for (int i = 0; i < number; i++)
            {
                sb.Append('a');
            }
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"\n Elapsed time : {elapsedMs} ms\n-------------------------------------------------\n ");
            Console.WriteLine("\nPress any key to continue...");

            Console.ReadKey();
        }

        private static void WarningMessage()
        {
            Console.WriteLine("\n---STARTING---");
            Console.WriteLine("It may take a while, please do not interrupt the program.");
            Thread.Sleep(1000);
        }
    }
}
