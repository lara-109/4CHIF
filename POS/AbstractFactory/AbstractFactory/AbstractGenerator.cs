using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFactory
{
    public interface AbstractGenerator
    {
        Pflanze createPflanze();
        Tier createTier();
        Untergrund createUntergrund();
    }
}