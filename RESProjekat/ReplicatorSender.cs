using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESProjekat
{
    public class ReplicatorSender
    {
        List<Podatak> buffer = new List<Podatak>();
        public Object obj = new Object();
        public ReplicatorSender()
        {

        }

        public void Prosledi(ReplicatorReceiver r, Logger l)
        {
            lock (obj)
            {
                int granica = buffer.Count;
                for (int i = 0; i < granica; granica--)
                {
                    r.Buffer.Add(buffer[i]);
                    buffer.Remove(buffer[i]);
                }
                string s = String.Format("{0}: Replicator Sender prosledjuje", DateTime.Now);
                l.Upisi(s);
            }
        }
        public List<Podatak> Buffer { get => buffer; set => buffer = value; }
    }
}
