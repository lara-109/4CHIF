using System;

namespace ThreadedPrimeCalculator
{
    public class PrimeEventArgs : EventArgs
    {
        public int id;
        public int count;

        public PrimeEventArgs(int id, int count)
        {
            this.id = id;
            this.count = count;
        }
    }
}