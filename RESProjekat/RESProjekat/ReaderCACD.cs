using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESProjekat
{
    public class ReaderCACD
    {
        private List<Tuple<Podatak, Podatak>> buffer = new List<Tuple<Podatak, Podatak>>();

        public List<Tuple<Podatak, Podatak>> Buffer { get => buffer; set => buffer = value; }
        string solutionPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));
        string file;
        public Object obj = new Object();
        public ReaderCACD()
        {
            file = Path.Combine(solutionPath, "CACD.txt");
        }

        public void UpisiUBazu(Logger l)

       {
            lock (obj)
            {
                for (int i = 0; i < Buffer.Count; i++)
                {
                    using (StreamWriter sw = new StreamWriter(file, true))
                    {
                        string c1 = $"{Buffer[i].Item1.Code} {Buffer[i].Item1.Value}";
                        string c2 = $"{Buffer[i].Item2.Code} {Buffer[i].Item2.Value}";

                        sw.WriteLine($"{c1} {c2}");
                        Buffer.Remove(Buffer[i]);
                    }
                }
                string log = String.Format("{0}: ReaderCACD upisuje u bazu\n", DateTime.Now);
                l.Upisi(log);
            }
        }

        public void IscitajIzBaze(Logger l)
        {
            lock (obj)
            {
                try
                {   // Open the text file using a stream reader.
                    using (StreamReader sr = new StreamReader(file))
                    {
                        // Read the stream to a string, and write the string to the console.
                        String line = sr.ReadToEnd();
                        Console.WriteLine(line);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }
                string log = String.Format("{0}: ReaderCACD iscitava iz baze\n", DateTime.Now);
                l.Upisi(log);
            }
        }

    }
}
