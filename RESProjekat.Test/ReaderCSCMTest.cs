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
    public class ReaderCSCMTest
    {
        [Test]
        public void ReaderCSCM_UpisiUBazu_Jedan_FileNePostoji()
        {
            ReaderCSCM _readerCSCM = new ReaderCSCM();
            Logger l = new Logger();
            _readerCSCM.Buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_SINGLENOE, 1), new Podatak(Data.Code.CodeSpisak.CODE_MULTIPLENODE, 2)));
            string expected = "CODE_SINGLENOE 1 CODE_MULTIPLENODE 2";
            string actual;
            File.Delete(_readerCSCM.File);

            //Act
            _readerCSCM.UpisiUBazu(l);

            //Post act arange
            using (StreamReader sr = new StreamReader(_readerCSCM.File))
            {
                // Read the stream to a string, and write the string to the console.
                actual = sr.ReadLine();
            }

            //Assert
            Assert.AreEqual(expected, actual);

            //Post assert cleanup
            File.Delete(_readerCSCM.File);
        }
        [Test]
        public void ReaderCSCM_UpisiUBazu_Vise_FileNePostoji()
        {
            //Arange
            ReaderCSCM _readerCSCM = new ReaderCSCM();
            List<Tuple<Podatak, Podatak>> buffer = new List<Tuple<Podatak, Podatak>>();
            Logger l = new Logger();
            buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_SINGLENOE, 1), new Podatak(Data.Code.CodeSpisak.CODE_MULTIPLENODE, 2)));
            buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_SINGLENOE, 3), new Podatak(Data.Code.CodeSpisak.CODE_MULTIPLENODE, 4)));
            _readerCSCM.Buffer = buffer;
            string expected = "CODE_SINGLENOE 1 CODE_MULTIPLENODE 2" + "CODE_SINGLENOE 3 CODE_MULTIPLENODE 4";
            string line;
            string actual = "";
            File.Delete(_readerCSCM.File);

            //Act
            _readerCSCM.UpisiUBazu(l);

            //Post act arange
            using (StreamReader sr = new StreamReader(_readerCSCM.File))
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
            File.Delete(_readerCSCM.File);
        }
        [Test]
        public void ReaderCSCM_UpisiUBazu_Jedan_FilePostoji()
        {
            ReaderCSCM _readerCSCM = new ReaderCSCM();
            Logger l = new Logger();
            _readerCSCM.DeadbandList.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_SINGLENOE, 1), new Podatak(Data.Code.CodeSpisak.CODE_MULTIPLENODE, 2)));
            string expected = "CODE_SINGLENOE 1 CODE_MULTIPLENODE 2";
            string actual;
            var myfile = File.Create(_readerCSCM.File);
            myfile.Close();
            //Act
            _readerCSCM.UpisiUBazu(l);

            //Post act arange
            using (StreamReader sr = new StreamReader(_readerCSCM.File))
            {
                // Read the stream to a string, and write the string to the console.
                actual = sr.ReadLine();
            }

            //Assert
            Assert.AreEqual(expected, actual);

            //Post assert cleanup
            File.Delete(_readerCSCM.File);
        }
        [Test]
        public void ReaderCCCS_UpisiUBazu_Vise_FilePostoji()
        {
            //Arange
            ReaderCSCM _readerCSCM = new ReaderCSCM();
            List<Tuple<Podatak, Podatak>> buffer = new List<Tuple<Podatak, Podatak>>();
            Logger l = new Logger();
            buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_SINGLENOE, 1), new Podatak(Data.Code.CodeSpisak.CODE_MULTIPLENODE, 2)));
            buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_SINGLENOE, 3), new Podatak(Data.Code.CodeSpisak.CODE_MULTIPLENODE, 4)));
            _readerCSCM.DeadbandList = buffer;
            string expected = "CODE_SINGLENOE 1 CODE_MULTIPLENODE 2" + "CODE_SINGLENOE 3 CODE_MULTIPLENODE 4";
            string line;
            string actual = "";
            var myfile = File.Create(_readerCSCM.File);
            myfile.Close();

            //Act
            _readerCSCM.UpisiUBazu(l);

            //Post act arange
            using (StreamReader sr = new StreamReader(_readerCSCM.File))
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
            File.Delete(_readerCSCM.File);
        }

        [Test]
        public void ReaderCCCS_Deadband()
        {
            //Arange

            ReaderCSCM _readerCSCM = new ReaderCSCM();
            File.Delete(_readerCSCM.File);
            Logger l = new Logger();
            List<Tuple<Podatak, Podatak>> buffer = new List<Tuple<Podatak, Podatak>>();
            List<Tuple<Podatak, Podatak>> baza = new List<Tuple<Podatak, Podatak>>();
            List<Tuple<Podatak, Podatak>> expectedDeadbandList = new List<Tuple<Podatak, Podatak>>();
            baza.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_SINGLENOE, 1), new Podatak(Data.Code.CodeSpisak.CODE_MULTIPLENODE, 2)));
            baza.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_SINGLENOE, 3), new Podatak(Data.Code.CodeSpisak.CODE_MULTIPLENODE, 4)));
            buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_SINGLENOE, 1), new Podatak(Data.Code.CodeSpisak.CODE_MULTIPLENODE, 2)));
            buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_SINGLENOE, 3), new Podatak(Data.Code.CodeSpisak.CODE_MULTIPLENODE, 4)));
            buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_SINGLENOE, 15), new Podatak(Data.Code.CodeSpisak.CODE_MULTIPLENODE, 22)));
            buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_SINGLENOE, 69), new Podatak(Data.Code.CodeSpisak.CODE_MULTIPLENODE, 72)));
            buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_SINGLENOE, 15), new Podatak(Data.Code.CodeSpisak.CODE_MULTIPLENODE, 22)));
            buffer.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_SINGLENOE, 36), new Podatak(Data.Code.CodeSpisak.CODE_MULTIPLENODE, 49)));
            expectedDeadbandList.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_SINGLENOE, 15), new Podatak(Data.Code.CodeSpisak.CODE_MULTIPLENODE, 22)));
            expectedDeadbandList.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_SINGLENOE, 69), new Podatak(Data.Code.CodeSpisak.CODE_MULTIPLENODE, 72)));
            expectedDeadbandList.Add(Tuple.Create(new Podatak(Data.Code.CodeSpisak.CODE_SINGLENOE, 36), new Podatak(Data.Code.CodeSpisak.CODE_MULTIPLENODE, 49)));
            _readerCSCM.Buffer = baza;
            _readerCSCM.UpisiUBazu(l);
            _readerCSCM.Buffer = buffer;

            //Act
            _readerCSCM.Deadband(l);

            //Assert
            CollectionAssert.AreEqual(expectedDeadbandList, _readerCSCM.DeadbandList);
        }
    }
}
