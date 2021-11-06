using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airplane
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int x;
            int.TryParse(args[0], out x);
            MediumAirport a = new MediumAirport();
            Flightcontrol f = new Flightcontrol();
            f.Start();

            for (int i = 0; i < x; i++)
            {
                Plane p = new Plane(i + 1, a);
                p.Start();  
            }
        }
    }
}
