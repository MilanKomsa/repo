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
    public class ReaderCCCLTest
    {
        [Test]
        public void ReaderCCCL_UpisiUBazu_Jedan_FileNePostoji()
        {
            ReaderCCCL _readerCCCL = new ReaderCCCL();
            Logger l = new Logger();
            _readerCCCL.Buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_CUSTOM, 1), new Podatak(Data.Code.CodeSpisak.CODE_LIMITSET, 2)));
            string expected = "CODE_CUSTOM 1 CODE_LIMITSET 2";
            string actual;
            File.Delete(_readerCCCL.File);

            //Act
            _readerCCCL.UpisiUBazu(l);

            //Post act arange
            using (StreamReader sr = new StreamReader(_readerCCCL.File))
            {
                // Read the stream to a string, and write the string to the console.
                actual = sr.ReadLine();
            }

            //Assert
            Assert.AreEqual(expected, actual);

            //Post assert cleanup
            File.Delete(_readerCCCL.File);
        }
        [Test]
        public void ReaderCCCL_UpisiUBazu_Vise_FileNePostoji()
        {
            //Arange
            ReaderCCCL _readerCCCL = new ReaderCCCL();
            List<Tuple<Podatak, Podatak>> buffer = new List<Tuple<Podatak, Podatak>>();
            Logger l = new Logger();
            buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_CUSTOM, 1), new Podatak(Data.Code.CodeSpisak.CODE_LIMITSET, 2)));
            buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_CUSTOM, 3), new Podatak(Data.Code.CodeSpisak.CODE_LIMITSET, 4)));
            _readerCCCL.Buffer = buffer;
            string expected = "CODE_CUSTOM 1 CODE_LIMITSET 2" + "CODE_CUSTOM 3 CODE_LIMITSET 4";
            string line;
            string actual = "";
            File.Delete(_readerCCCL.File);

            //Act
            _readerCCCL.UpisiUBazu(l);

            //Post act arange
            using (StreamReader sr = new StreamReader(_readerCCCL.File))
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
            File.Delete(_readerCCCL.File);
        }
        [Test]
        public void ReaderCCCL_UpisiUBazu_Jedan_FilePostoji()
        {
            ReaderCCCL _readerCCCL = new ReaderCCCL();
            Logger l = new Logger();
            _readerCCCL.DeadbandList.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_CUSTOM, 1), new Podatak(Data.Code.CodeSpisak.CODE_LIMITSET, 2)));
            string expected = "CODE_CUSTOM 1 CODE_LIMITSET 2";
            string actual;
            var myfile = File.Create(_readerCCCL.File);
            myfile.Close();
            //Act
            _readerCCCL.UpisiUBazu(l);

            //Post act arange
            using (StreamReader sr = new StreamReader(_readerCCCL.File))
            {
                // Read the stream to a string, and write the string to the console.
                actual = sr.ReadLine();
            }

            //Assert
            Assert.AreEqual(expected, actual);

            //Post assert cleanup
            File.Delete(_readerCCCL.File);
        }
        [Test]
        public void ReaderCCCL_UpisiUBazu_Vise_FilePostoji()
        {
            //Arange
            ReaderCCCL _readerCCCL = new ReaderCCCL();
            List<Tuple<Podatak, Podatak>> buffer = new List<Tuple<Podatak, Podatak>>();
            Logger l = new Logger();
            buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_CUSTOM, 1), new Podatak(Data.Code.CodeSpisak.CODE_LIMITSET, 2)));
            buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_CUSTOM, 3), new Podatak(Data.Code.CodeSpisak.CODE_LIMITSET, 4)));
            _readerCCCL.DeadbandList = buffer;
            string expected = "CODE_CUSTOM 1 CODE_LIMITSET 2" + "CODE_CUSTOM 3 CODE_LIMITSET 4";
            string line;
            string actual = "";
            var myfile = File.Create(_readerCCCL.File);
            myfile.Close();

            //Act
            _readerCCCL.UpisiUBazu(l);

            //Post act arange
            using (StreamReader sr = new StreamReader(_readerCCCL.File))
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
            File.Delete(_readerCCCL.File);
        }

        [Test]
        public void ReaderCCCL_Deadband()
        {
            //Arange

            ReaderCCCL _readerCCCL = new ReaderCCCL();
            File.Delete(_readerCCCL.File);
            Logger l = new Logger();
            List<Tuple<Podatak, Podatak>> buffer = new List<Tuple<Podatak, Podatak>>();
            List<Tuple<Podatak, Podatak>> baza = new List<Tuple<Podatak, Podatak>>();
            List<Tuple<Podatak, Podatak>> expectedDeadbandList = new List<Tuple<Podatak, Podatak>>();
            baza.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_CUSTOM, 1), new Podatak(Data.Code.CodeSpisak.CODE_LIMITSET, 2)));
            baza.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_CUSTOM, 3), new Podatak(Data.Code.CodeSpisak.CODE_LIMITSET, 4)));
            buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_CUSTOM, 1), new Podatak(Data.Code.CodeSpisak.CODE_LIMITSET, 2)));
            buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_CUSTOM, 3), new Podatak(Data.Code.CodeSpisak.CODE_LIMITSET, 4)));
            buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_CUSTOM, 15), new Podatak(Data.Code.CodeSpisak.CODE_LIMITSET, 22)));
            buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_CUSTOM, 69), new Podatak(Data.Code.CodeSpisak.CODE_LIMITSET, 72)));
            buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_CUSTOM, 15), new Podatak(Data.Code.CodeSpisak.CODE_LIMITSET, 22)));
            buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_CUSTOM, 36), new Podatak(Data.Code.CodeSpisak.CODE_LIMITSET, 49)));
            expectedDeadbandList.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_CUSTOM, 15), new Podatak(Data.Code.CodeSpisak.CODE_LIMITSET, 22)));
            expectedDeadbandList.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_CUSTOM, 69), new Podatak(Data.Code.CodeSpisak.CODE_LIMITSET, 72)));
            expectedDeadbandList.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_CUSTOM, 36), new Podatak(Data.Code.CodeSpisak.CODE_LIMITSET, 49)));
            _readerCCCL.Buffer = baza;
            _readerCCCL.UpisiUBazu(l);
            _readerCCCL.Buffer = buffer;

            //Act
            _readerCCCL.Deadband(l);

            //Assert
            CollectionAssert.AreEqual(expectedDeadbandList, _readerCCCL.DeadbandList);
        }
    }
}
