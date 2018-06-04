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
        }

        public void Upisi(string s)
        {
            file = Path.Combine(solutionPath, "LogFile.txt");
            lock (obj)
            {
                if (File.Exists(file))
                {
                    using (StreamWriter sw = File.AppendText(file))
                    {
                        sw.WriteLine(s);
                    }
                }
                else
                {

                    StreamWriter sw = new StreamWriter(file);

                    //Write a line of text
                    sw.WriteLine(s);

                    //Close the file
                    sw.Close();
                }
            }
        }
    }
}
