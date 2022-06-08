using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFactory
{
    public class Regenwaldgenerator : AbstractGenerator
    {
        public Pflanze createPflanze()
        {
            return new Baum();
        }

        public Tier createTier()
        {
            return new Elefant();
        }

        public Untergrund createUntergrund()
        {
            return new Gras();
        }
    }
}