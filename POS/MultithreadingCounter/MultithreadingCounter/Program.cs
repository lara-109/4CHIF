using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadingCounter
{
    class Program
    {
        int id = 0;
        static int counter = 1;
        static int anz;
        
        public Program(int id)
        {
            this.id = id;
        }

        void CounterMethod()
        {
            for (int i = 0; i < anz; i++)
            {
                if (counter % id == 0)
                {
                    Console.WriteLine("ID: {0,3} Counter: {1,8} Modulo: {2}", id, counter, counter % id);
                }
                counter++;
            }
        }
        static void Main(string[] args)
        {
            
            int anzahl = 4;
            int.TryParse(args[0], out anzahl);
            int.TryParse(args[1], out anz);
            for(int i = 0; i < anzahl; i++)
            {
                Program obj = new Program(2 + i);
                ThreadStart count = new ThreadStart(obj.CounterMethod);
                Thread c = new Thread(count);
                c.Start();
            }
            
        }
    }
}
