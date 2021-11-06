using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassa
{
    class Program
    {
        static void Main(string[] args)
        {
            int anzahl = 10;
            if (args.Length > 0)
            {
                int.TryParse(args[0], out anzahl);
            }

            MultiKassa kas = new MultiKassa(3);

            for (int i = 0; i < anzahl; i++)
            {
                Kunde kunde = new Kunde(i + 1, kas);
                kunde.Start();
            }
        }
    }
}
