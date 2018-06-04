using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESProjekat.Test
{
    [TestFixture]
    public class ReaderCACDTest
    {
        [Test]
        public void ReaderCACD_UpisiUBazu_Jedan()
        {
            //Arange
            ReaderCACD _readerCACD = new ReaderCACD();
            Logger l = new Logger();
            _readerCACD.Buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_ANALOG, 1), new Podatak(Data.Code.CodeSpisak.CODE_DIGITAL, 2)));
            string expected = "CODE_ANALOG 1 CODE_DIGITAL 2";
            string actual;
            File.Delete(_readerCACD.File);

            //Act
            _readerCACD.UpisiUBazu(l);

            //Post act arange
            using (StreamReader sr = new StreamReader(_readerCACD.File))
            {
                // Read the stream to a string, and write the string to the console.
                actual = sr.ReadLine();
            }

            //Assert
            Assert.AreEqual(expected, actual);

            //Post assert cleanup
            File.Delete(_readerCACD.File);
        }
        [Test]
        public void ReaderCACD_UpisiUBazu_Vise()
        {
            //Arange
            ReaderCACD _readerCACD = new ReaderCACD();
            List<Tuple<Podatak, Podatak>> buffer = new List<Tuple<Podatak, Podatak>>();
            Logger l = new Logger();
            buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_ANALOG, 1), new Podatak(Data.Code.CodeSpisak.CODE_DIGITAL, 2)));
            buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_ANALOG, 3), new Podatak(Data.Code.CodeSpisak.CODE_DIGITAL, 4)));
            _readerCACD.Buffer = buffer;
            string expected = "CODE_ANALOG 1 CODE_DIGITAL 2" + "CODE_ANALOG 3 CODE_DIGITAL 4";
            string line;
            string actual = "";
            File.Delete(_readerCACD.File);

            //Act
            _readerCACD.UpisiUBazu(l);

            //Post act arange
            using (StreamReader sr = new StreamReader(_readerCACD.File))
            {
                // Read the stream to a string, and write the string to the console.
                for (int i = 0; i < 2; i++)
                {
                    line = sr.ReadLine();
                    actual = actual + line;
                }
            }

            //Assert
            Assert.AreEqual(expected, actual);

            //Post assert cleanup
            File.Delete(_readerCACD.File);
        }
    }
}
