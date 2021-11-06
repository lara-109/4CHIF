using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Airplane
{
    class MediumAirport : Airport
    {
        public static ManualResetEvent change { get; set; } = new ManualResetEvent(false);
        
        AutoResetEvent[] runway;
        public MediumAirport()
        {
            runway = new AutoResetEvent[2];
            runway[0] = new AutoResetEvent(true);
            runway[1] = new AutoResetEvent(true);
        }

        public override void land(Plane plane)
        {
            int used = WaitHandle.WaitAny(runway);
            change.WaitOne();

            Console.WriteLine("Flugzeug " + plane.id + " landet auf der Landebahn " + (used + 1));
            Thread.Sleep(1000);
            Console.WriteLine("Flugzeug " + plane.id + " ist auf dem Flughafen gelandet");
            runway[used].Set();
        }
    }
}
