using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESProjekat
{
    public class Logger
    {
        public Object obj = new Object();
        string solutionPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));
        string file;
        public Logger()
        {
            File = Path.Combine(solutionPath, "LogFile.txt");
        }

        public string File { get => file; set => file = value; }

        public void Upisi(string s)
        {   
            lock (obj)
            {
                if (System.IO.File.Exists(File))
                {
                    using (StreamWriter sw = System.IO.File.AppendText(File))
                    {
                        sw.WriteLine(s);
                    }
                }
                else
                {

                    StreamWriter sw = new StreamWriter(File);

                    //Write a line of text
                    sw.WriteLine(s);

                    //Close the file
                    sw.Close();
                }
            }
        }
    }
}
