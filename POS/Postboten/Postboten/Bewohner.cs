using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Postbote
{
    class Bewohner
    {
        public string name;
        public Bewohner(string name)
        {
            this.name = name;
        }
        public void warten()
        {
            while (true)
            {
                lock (Postbote.Briefkasten)
                {
                    if (Postbote.Post.Contains(name))
                    {
                        Console.WriteLine(name + " hat Post bekommen");
                        Postbote.Post.Remove(name);
                    }
                    else
                    {
                        Monitor.Wait(Postbote.Briefkasten);
                    }
                }
            }
        }
        public void StartThread()
        {
            ThreadStart worker = new ThreadStart(warten);
            Thread t = new Thread(worker);
            t.IsBackground = true;
            t.Start();
        }
    }
}
