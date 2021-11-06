using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kassa
{
    class MultiKassa : Kassa
    {
        AutoResetEvent[] kassaArray;
        public MultiKassa(int anzKassa)
        {
            kassaArray = new AutoResetEvent[anzKassa];
            for(int i = 0; i < anzKassa; i++)
            {
                kassaArray[i] = new AutoResetEvent(true);
            }
        }


        public override void checkOut(Kunde kunde)
        {
            int kassaIndex = WaitHandle.WaitAny(kassaArray);

            Console.WriteLine("Der Kunde " + kunde.id + " legt seine Producte auf das Band " + kassaIndex);
            Thread.Sleep(1000);
            Console.WriteLine("Der Kunde " + kunde.id + " hat bezahlt auf " + kassaIndex);
            kassaArray[kassaIndex].Set();
        }
    }
}
