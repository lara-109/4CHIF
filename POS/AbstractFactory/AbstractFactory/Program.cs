using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            AbstractGenerator polar = new Polargebietgenerator();

            Console.WriteLine(polar.createPflanze());
            Console.WriteLine(polar.createTier());
            Console.WriteLine(polar.createUntergrund());


            AbstractGenerator wüste = new Wüstengenerator();

            Console.WriteLine(wüste.createPflanze());
            Console.WriteLine(wüste.createTier());
            Console.WriteLine(wüste.createUntergrund());


            AbstractGenerator regen = new Regenwaldgenerator();

            Console.WriteLine(regen.createPflanze());
            Console.WriteLine(regen.createTier());
            Console.WriteLine(regen.createUntergrund());
        }
    }
}
