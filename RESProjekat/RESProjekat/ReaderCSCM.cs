using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESProjekat
{
    public class ReaderCSCM
    {
        private List<Tuple<Podatak, Podatak>> buffer = new List<Tuple<Podatak, Podatak>>();
        private List<Tuple<Podatak, Podatak>> deadbandList = new List<Tuple<Podatak, Podatak>>();
        public Object obj = new Object();
        string solutionPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));
        string file;

        public ReaderCSCM()
        {
            file = Path.Combine(solutionPath, "CSCM.txt");
        }

        public void Deadband(Logger l)
        {
            lock (obj)
            {
                if (File.Exists(file))
                {
                    try
                    {
                        string[] allText = File.ReadAllLines(file);
                        foreach (string line in allText)
                        {
                            if (!String.IsNullOrWhiteSpace(line))
                            {
                                string[] niz = line.Split(' ');
                                string code1 = niz[0];
                                int code1Value;
                                Int32.TryParse(niz[1], out code1Value);
                                string code2 = niz[2];
                                int code2Value;
                                Int32.TryParse(niz[3], out code2Value);
                                foreach (var podatak in Buffer)
                                {
                                    if (code1 == podatak.Item1.Code.ToString())
                                    {
                                        if (podatak.Item1.Value < code1Value * 0.98 ||
                                           podatak.Item1.Value > code1Value * 1.02 &&
                                           podatak.Item2.Value < code2Value * 0.98 ||
                                           podatak.Item2.Value > code2Value * 1.02)
                                        {
                                            if (!DeadbandList.Contains(podatak))
                                            {
                                                DeadbandList.Add(podatak);
                                            }
                                        }
                                    }
                                    if (code1 == podatak.Item2.Code.ToString())
                                    {
                                        if (podatak.Item1.Value < code2Value * 0.98 ||
                                           podatak.Item1.Value > code2Value * 1.02 &&
                                           podatak.Item2.Value < code1Value * 0.98 ||
                                           podatak.Item2.Value > code1Value * 1.02)
                                        {
                                            if (!DeadbandList.Contains(podatak))
                                            {
                                                DeadbandList.Add(podatak);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        Buffer.Clear();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("The file could not be read:");
                        Console.WriteLine(e.Message);
                    }

                    string log = String.Format("{0}: ReaderCSCM vrsi deadband proveru\n", DateTime.Now);
                    l.Upisi(log);
                }
            }
        }
        public void UpisiUBazu(Logger l)
        {
            lock (obj)
            {
                if (File.Exists(file))
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(file, true))
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
                    using (StreamWriter sw = new StreamWriter(file, true))
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
                string log = String.Format("{0}: ReaderCSCM upisuje u bazu\n", DateTime.Now);
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
                string log = String.Format("{0}: ReaderCSCM iscitava iz baze\n", DateTime.Now);
                l.Upisi(log);
            }
        }
        public List<Tuple<Podatak, Podatak>> DeadbandList { get => deadbandList; set => deadbandList = value; }
        public List<Tuple<Podatak, Podatak>> Buffer { get => buffer; set => buffer = value; }
    }
}
