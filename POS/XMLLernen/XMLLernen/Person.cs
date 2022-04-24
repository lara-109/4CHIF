using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLLernen
{
    public class Person
    {
        public string Vname { get; set; }
        public string Nname { get; set; }
        public string Geb { get; set; }

        public Person(string vorname, string nachname, string geb)
        {
            Vname = vorname;
            Nname = nachname;
            this.Geb = geb;
        }

        public Person()
        {

        }
    }
}
