using System;
using System.Threading;

namespace ThreadedPrimeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfThreads = int.Parse(args[0]);
            int max = int.Parse(args[1]);

            Application calc = new Application();
            calc.Start(max, numberOfThreads);
        }
    }
}
