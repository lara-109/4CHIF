using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Postbote
{
    class Postbote
    {
        private Random random = new Random();
        public static object Briefkasten { get; } = new object();
        public static List<string> Post { get; set; } = new List<string>();
        public void ausliefern()
        {
            for(int i = 0; i < 3; i++)
            {  
                Thread.Sleep(TimeSpan.FromSeconds(random.Next(10, 15)));
                lock (Briefkasten)
                {
                    Postbote.Post.Add("Robert");
                    Postbote.Post.Add("Robert");
                    Postbote.Post.Add("Peter");
                    Monitor.PulseAll(Briefkasten);
                }
            }
        }

        static void Main(string[] args)
        {

            Postbote pb = new Postbote();
            ThreadStart worker = new ThreadStart(pb.ausliefern);
            Thread t = new Thread(worker);
            t.Start();

            Bewohner robert = new Bewohner("Robert");
            Bewohner franz = new Bewohner("Franz");
            Bewohner peter = new Bewohner("Peter");

            robert.StartThread();
            franz.StartThread();
            peter.StartThread();


        }
    }
}
