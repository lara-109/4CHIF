using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFactory
{
    public class Polargebietgenerator : AbstractGenerator
    {
        public Pflanze createPflanze()
        {
            return new Flechte();
        }

        public Tier createTier()
        {
            return new Eisbär();
        }

        public Untergrund createUntergrund()
        {
            return new Schnee();
        }
    }
}