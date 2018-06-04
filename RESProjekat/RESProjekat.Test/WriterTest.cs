using NUnit.Framework;
using RESProjekat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESProjekat.Test
{
    [TestFixture]
    public class WriterTest
    {
        [TestCase(Code.CodeSpisak.CODE_ANALOG, 1)]
        [TestCase(Code.CodeSpisak.CODE_DIGITAL, 1)]
        [TestCase(Code.CodeSpisak.CODE_CUSTOM, 1)]
        [TestCase(Code.CodeSpisak.CODE_LIMITSET, 1)]
        [TestCase(Code.CodeSpisak.CODE_SOURCE, 1)]
        [TestCase(Code.CodeSpisak.CODE_CONSUMER, 1)]
        [TestCase(Code.CodeSpisak.CODE_SINGLENOE, 1)]
        [TestCase(Code.CodeSpisak.CODE_MULTIPLENODE, 1)]
        public void Writer_Prosledi(Code.CodeSpisak code, int value)
        {
            //Arrange
            Podatak podatak = new Podatak(code, value);
            List<Podatak> tempList = new List<Podatak>() { podatak };
            Writer _writer = new Writer();
            ReplicatorSender _replicatorSender = new ReplicatorSender();
            Logger _logger = new Logger();
            _writer.P = podatak;

            //Act
            _writer.Prosledi(_replicatorSender, _logger);

            //Assert
            Assert.AreEqual(_replicatorSender.Buffer, tempList);
        }
    }
}
