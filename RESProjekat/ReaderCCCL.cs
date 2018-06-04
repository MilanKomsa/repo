using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESProjekat
{
    public class ReaderCCCL
    {
        private List<Tuple<Podatak, Podatak>> buffer = new List<Tuple<Podatak, Podatak>>();
        private List<Tuple<Podatak, Podatak>> deadbandList = new List<Tuple<Podatak, Podatak>>();
        public Object obj = new Object();
        string solutionPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));
        string file;

        public ReaderCCCL()
        {
            File = Path.Combine(solutionPath, "CCCL.txt");
        }

        public void Deadband(Logger l)
        {
            lock (obj)
            {
                if (System.IO.File.Exists(File))
                {
                    try
                    {
                        string[] allText = System.IO.File.ReadAllLines(File);
                        foreach (string line in allText)
                        {
                            if (!string.IsNullOrWhiteSpace(line))
                            {
                                string[] niz = line.Split(' ');
                                string code1 = niz[0];
                                int code1Value;
                                int.TryParse(niz[1], out code1Value);
                                string code2 = niz[2];
                                int code2Value;
                                int.TryParse(niz[3], out code2Value);
                                for(int i = 0; i <buffer.Count; i++)
                                {
                                    if (code1 == buffer[i].Item1.Code.ToString())
                                    {
                                        if (buffer[i].Item1.Value < code1Value * 0.98 ||
                                           buffer[i].Item1.Value > code1Value * 1.02 &&
                                           buffer[i].Item2.Value < code2Value * 0.98 ||
                                           buffer[i].Item2.Value > code2Value * 1.02)
                                        {
                                            //if (!DeadbandList.Contains(buffer[i]))
                                            //{
                                            //    DeadbandList.Add(buffer[i]);
                                            //}
                                        }
                                        else
                                        {
                                            buffer.Remove(buffer[i]);
                                            i--;
                                        }
                                    }
                                    else if (code1 == buffer[i].Item2.Code.ToString())
                                    {
                                        if (buffer[i].Item1.Value < code2Value * 0.98 ||
                                           buffer[i].Item1.Value > code2Value * 1.02 &&
                                           buffer[i].Item2.Value < code1Value * 0.98 ||
                                           buffer[i].Item2.Value > code1Value * 1.02)
                                        {
                                            //if (!DeadbandList.Contains(buffer[i]))
                                            //{
                                            //    DeadbandList.Add(buffer[i]);
                                            //}
                                        }
                                        else
                                        {
                                            buffer.Remove(buffer[i]);
                                            i--;
                                        }
                                    }
                                }
                            }
                        }
                        foreach(var podatak in buffer)
                        {
                            if(!DeadbandList.Contains(podatak))
                            DeadbandList.Add(podatak);
                        }
                        Buffer.Clear();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("The file could not be read:");
                        Console.WriteLine(e.Message);
                    }

                    string log = string.Format("{0}: ReaderCCCL vrsi deadband proveru\n", DateTime.Now);
                    l.Upisi(log);
                }
            }
        }
        public void UpisiUBazu(Logger l)
        {
            lock (obj)
            {
                if (System.IO.File.Exists(File))
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(File, true))
                        {
                            foreach (var podatak in DeadbandList)
                            {
                                string c1 = $"{podatak.Item1.Code} {podatak.Item1.Value}";
                                string c2 = $"{podatak.Item2.Code} {podatak.Item2.Value}";

                                sw.WriteLine($"{c1} {c2}");
                            }
                            DeadbandList.Clear();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("The file could not be read:");
                        Console.WriteLine(e.Message);
                    }
                }
                else if (Buffer.Count != 0)
                {
                    using (StreamWriter sw = new StreamWriter(File, true))
                    {
                        foreach (var podatak in Buffer)
                        {
                            string c1 = $"{podatak.Item1.Code} {podatak.Item1.Value}";
                            string c2 = $"{podatak.Item2.Code} {podatak.Item2.Value}";

                            sw.WriteLine($"{c1} {c2}");
                        }
                        Buffer.Clear();
                    }
                }
                string log = String.Format("{0}: ReaderCCCL upisuje u bazu\n", DateTime.Now);
                l.Upisi(log);
            }
        }
        public void IscitajIzBaze(Logger l)
        {
            lock (obj)
            {
                try
                {   // Open the text file using a stream reader.
                    using (StreamReader sr = new StreamReader(File))
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
                string log = String.Format("{0}: ReaderCCCL iscitava iz baze\n", DateTime.Now);
                l.Upisi(log);
            }
        }
        public List<Tuple<Podatak, Podatak>> DeadbandList { get => deadbandList; set => deadbandList = value; }
        public List<Tuple<Podatak, Podatak>> Buffer { get => buffer; set => buffer = value; }
        public string File { get => file; set => file = value; }
    }
}
