using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFactory
{
    public class Wüstengenerator : AbstractGenerator
    {
        public Pflanze createPflanze()
        {
            return new Kaktus();
        }

        public Tier createTier()
        {
            return new Kamel();
        }

        public Untergrund createUntergrund()
        {
            return new Sand();
        }
    }
}