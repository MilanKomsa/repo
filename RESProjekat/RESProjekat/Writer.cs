using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESProjekat
{
    public class Writer
    {
        public Object obj = new Object();
        private Podatak p;

        public Writer()
        {

        }

        public void Prosledi(ReplicatorSender r, Logger l)
        {
            lock (obj)
            {
                r.Buffer.Add(p);
                string s = String.Format("{0}: Writer prosledjuje \n", DateTime.Now);
                l.Upisi(s);
            }
        }


        public Podatak P { get => p; set => p = value; }
    }
}
