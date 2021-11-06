using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Airplane
{
    class SimpleAirport : Airport
    {
        public override void land(Plane plane)
        {
            lock (this)
            {
                Console.WriteLine("Flugzeug " + plane.id + " landet auf dem Flughafen");
                Thread.Sleep(1000);
                Console.WriteLine("Flugzeug " + plane.id + " ist auf dem Flughafen gelandet");
            }
        }
    }
}
