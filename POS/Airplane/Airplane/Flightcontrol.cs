using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Airplane
{
    class Flightcontrol
    {
        public void control()
        {
            while (true)
            {
                MediumAirport.change.Set();
                Console.WriteLine("Tag bricht an");
                Thread.Sleep(4000);
                MediumAirport.change.Reset();
                Console.WriteLine("Nacht beginnt");
                Thread.Sleep(2000);
            }
        }

        public void Start()
        {
            Thread t = new Thread(control);
            t.IsBackground = true;
            t.Start();
        }
    }
}
