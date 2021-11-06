using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kassa
{
    class Kunde
    {
        public int id;
        Random r = new Random();
        Kassa kassa = new Kassa();

        public Kunde(int id, Kassa kassa)
        {
            this.id = id;
            this.kassa = kassa;

        }
        
        public void Start()
        {
            Thread t = new Thread(worker);
            t.Start();
        }

        void worker()
        {
            Thread.Sleep(r.Next(1000, 20000));
            kassa.checkOut(this);
        }
    }
}
