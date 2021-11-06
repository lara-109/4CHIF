using System;
using System.Threading;

namespace ThreadedPrimeCalculator
{
    public class PrimeFinder
    {
        private int current;
        private int max;
        public event EventHandler<PrimeEventArgs> onPrimesFound;

        public PrimeFinder(int max)
        {
            this.max = max;
        }

        public void worker()
        {
            int max;
            int current;
            int count = 0;

            lock (this)
            {
                max = this.max;
                current = this.current;
                this.current++;
            }

            while (current < max)
            {
                if (IsPrime(current))
                {
                    count++;
                }

                lock (this)
                {
                    current = this.current;
                    this.current++;
                }
            }

            int id = Thread.CurrentThread.ManagedThreadId;

            this.FireOnPrimesFound(id, count);
        }

        protected virtual void FireOnPrimesFound(int id, int count)
        {
            onPrimesFound?.Invoke(this, new PrimeEventArgs(id, count));
        }

        private static bool IsPrime(int n)
        {
            if (n == 2 || n == 3)
                return true;

            if (n <= 1 || n % 2 == 0 || n % 3 == 0)
                return false;

            for (int i = 5; i * i <= n; i += 6)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                    return false;
            }

            return true;
        }
    }
}