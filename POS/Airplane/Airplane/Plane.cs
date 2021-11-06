using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Airplane
{
    class Plane
    {
        public int id;
        Random r;
        Airport airport;

        public Plane(int id, Airport airport)
        {
            this.id = id;
            r = new Random();
            this.airport = airport;
        }

        public void Start()
        {
            Thread t = new Thread(fly);
            t.Start();
        }

        public void fly()
        {
            Thread.Sleep(r.Next(1000, 10000));
            airport.land(this);
        }
    }
}
