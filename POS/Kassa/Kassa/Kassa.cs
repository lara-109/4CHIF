using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kassa
{
    class Kassa
    {
        public virtual void checkOut(Kunde kunde)
        {
            lock (this)
            {
                Console.WriteLine("Der Kunde" + kunde.id + "legt seine Producte auf das Band");
                Thread.Sleep(1000);
                Console.WriteLine("Der Kunde" + kunde.id + "hat bezahlt");
            }
        }
    }
}
