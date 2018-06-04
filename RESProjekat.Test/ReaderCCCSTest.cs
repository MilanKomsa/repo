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
    public class ReaderCCCSTest
    {
        [Test]
        public void ReaderCCCS_UpisiUBazu_Jedan_FileNePostoji()
        {
            ReaderCCCS _readerCCCS = new ReaderCCCS();
            Logger l = new Logger();
            _readerCCCS.Buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_CONSUMER, 1), new Podatak(Data.Code.CodeSpisak.CODE_SOURCE, 2)));
            string expected = "CODE_CONSUMER 1 CODE_SOURCE 2";
            string actual;
            File.Delete(_readerCCCS.File);

            //Act
            _readerCCCS.UpisiUBazu(l);

            //Post act arange
            using (StreamReader sr = new StreamReader(_readerCCCS.File))
            {
                // Read the stream to a string, and write the string to the console.
                actual = sr.ReadLine();
            }

            //Assert
            Assert.AreEqual(expected, actual);

            //Post assert cleanup
            File.Delete(_readerCCCS.File);
        }
        [Test]
        public void ReaderCCCS_UpisiUBazu_Vise_FileNePostoji()
        {
            //Arange
            ReaderCCCS _readerCCCS = new ReaderCCCS();
            List<Tuple<Podatak, Podatak>> buffer = new List<Tuple<Podatak, Podatak>>();
            Logger l = new Logger();
            buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_CONSUMER, 1), new Podatak(Data.Code.CodeSpisak.CODE_SOURCE, 2)));
            buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_CONSUMER, 3), new Podatak(Data.Code.CodeSpisak.CODE_SOURCE, 4)));
            _readerCCCS.Buffer = buffer;
            string expected = "CODE_CONSUMER 1 CODE_SOURCE 2" + "CODE_CONSUMER 3 CODE_SOURCE 4";
            string line;
            string actual = "";
            File.Delete(_readerCCCS.File);

            //Act
            _readerCCCS.UpisiUBazu(l);

            //Post act arange
            using (StreamReader sr = new StreamReader(_readerCCCS.File))
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
            File.Delete(_readerCCCS.File);
        }
        [Test]
        public void ReaderCCCS_UpisiUBazu_Jedan_FilePostoji()
        {
            ReaderCCCS _readerCCCS = new ReaderCCCS();
            Logger l = new Logger();
            _readerCCCS.DeadbandList.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_CONSUMER, 1), new Podatak(Data.Code.CodeSpisak.CODE_SOURCE, 2)));
            string expected = "CODE_CONSUMER 1 CODE_SOURCE 2";
            string actual;
            var myfile = File.Create(_readerCCCS.File);
            myfile.Close();
            //Act
            _readerCCCS.UpisiUBazu(l);

            //Post act arange
            using (StreamReader sr = new StreamReader(_readerCCCS.File))
            {
                // Read the stream to a string, and write the string to the console.
                actual = sr.ReadLine();
            }

            //Assert
            Assert.AreEqual(expected, actual);

            //Post assert cleanup
            File.Delete(_readerCCCS.File);
        }
        [Test]
        public void ReaderCCCS_UpisiUBazu_Vise_FilePostoji()
        {
            //Arange
            ReaderCCCS _readerCCCS = new ReaderCCCS();
            List<Tuple<Podatak, Podatak>> buffer = new List<Tuple<Podatak, Podatak>>();
            Logger l = new Logger();
            buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_CONSUMER, 1), new Podatak(Data.Code.CodeSpisak.CODE_SOURCE, 2)));
            buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_CONSUMER, 3), new Podatak(Data.Code.CodeSpisak.CODE_SOURCE, 4)));
            _readerCCCS.DeadbandList = buffer;
            string expected = "CODE_CONSUMER 1 CODE_SOURCE 2" + "CODE_CONSUMER 3 CODE_SOURCE 4";
            string line;
            string actual = "";
            var myfile = File.Create(_readerCCCS.File);
            myfile.Close();

            //Act
            _readerCCCS.UpisiUBazu(l);

            //Post act arange
            using (StreamReader sr = new StreamReader(_readerCCCS.File))
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
            File.Delete(_readerCCCS.File);
        }

        [Test]
        public void ReaderCCCS_Deadband()
        {
            //Arange

            ReaderCCCS _readerCCCS = new ReaderCCCS();
            File.Delete(_readerCCCS.File);
            Logger l = new Logger();
            List<Tuple<Podatak, Podatak>> buffer = new List<Tuple<Podatak, Podatak>>();
            List<Tuple<Podatak, Podatak>> baza = new List<Tuple<Podatak, Podatak>>();
            List<Tuple<Podatak, Podatak>> expectedDeadbandList = new List<Tuple<Podatak, Podatak>>();
            baza.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_CONSUMER, 1), new Podatak(Data.Code.CodeSpisak.CODE_SOURCE, 2)));
            baza.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_CONSUMER, 3), new Podatak(Data.Code.CodeSpisak.CODE_SOURCE, 4)));
            buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_CONSUMER, 1), new Podatak(Data.Code.CodeSpisak.CODE_SOURCE, 2)));
            buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_CONSUMER, 3), new Podatak(Data.Code.CodeSpisak.CODE_SOURCE, 4)));
            buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_CONSUMER, 15), new Podatak(Data.Code.CodeSpisak.CODE_SOURCE, 22)));
            buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_CONSUMER, 69), new Podatak(Data.Code.CodeSpisak.CODE_SOURCE, 72)));
            buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_CONSUMER, 15), new Podatak(Data.Code.CodeSpisak.CODE_SOURCE, 22)));
            buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_CONSUMER, 36), new Podatak(Data.Code.CodeSpisak.CODE_SOURCE, 49)));
            expectedDeadbandList.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_CONSUMER, 15), new Podatak(Data.Code.CodeSpisak.CODE_SOURCE, 22)));
            expectedDeadbandList.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_CONSUMER, 69), new Podatak(Data.Code.CodeSpisak.CODE_SOURCE, 72)));
            expectedDeadbandList.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_CONSUMER, 36), new Podatak(Data.Code.CodeSpisak.CODE_SOURCE, 49)));
            _readerCCCS.Buffer = baza;
            _readerCCCS.UpisiUBazu(l);
            _readerCCCS.Buffer = buffer;

            //Act
            _readerCCCS.Deadband(l);

            //Assert
            CollectionAssert.AreEqual(expectedDeadbandList, _readerCCCS.DeadbandList);
        }
    }
}
