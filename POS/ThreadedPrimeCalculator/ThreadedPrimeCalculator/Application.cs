using System;
using System.Threading;

namespace ThreadedPrimeCalculator
{
    public class Application
    {
        private int total;

        public void Start(int max, int numberOfThreads)
        {
            Thread[] threads = new Thread[numberOfThreads];

            PrimeFinder calculator = new PrimeFinder(max);
            calculator.onPrimesFound += OnPrimesFound;

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(new ThreadStart(calculator.worker));
                threads[i].Start();
            }

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }

            Console.WriteLine("Insgesamt wurden {0} Primzahlen gefunden.", this.total);
        }

        private void OnPrimesFound(object sender, PrimeEventArgs e)
        {
            lock (this)
            {
                this.total += e.count;
            }

            Console.WriteLine("Thread {0} hat {1} Primzahlen gefunden.", e.id, e.count);
        }
    }
}