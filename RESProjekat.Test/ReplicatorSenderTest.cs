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
    public class ReplicatorSenderTest
    {

        [TestCase(Code.CodeSpisak.CODE_ANALOG, 1)]
        [TestCase(Code.CodeSpisak.CODE_DIGITAL, 1)]
        [TestCase(Code.CodeSpisak.CODE_CUSTOM, 1)]
        [TestCase(Code.CodeSpisak.CODE_LIMITSET, 1)]
        [TestCase(Code.CodeSpisak.CODE_SOURCE, 1)]
        [TestCase(Code.CodeSpisak.CODE_CONSUMER, 1)]
        [TestCase(Code.CodeSpisak.CODE_SINGLENOE, 1)]
        [TestCase(Code.CodeSpisak.CODE_MULTIPLENODE, 1)]
        public void ReplicatorSender_Prosledi_Vise(Code.CodeSpisak code, int value)
        {
            //Arange
            Podatak podatak = new Podatak(code, value);
            List<Podatak> tempList = new List<Podatak>() { podatak,podatak,podatak };
            ReplicatorSender _replicatorSender = new ReplicatorSender();
            ReplicatorReceiver _replicatorReceiver = new ReplicatorReceiver();
            Logger _logger = new Logger();
            _replicatorSender.Buffer.Add(podatak);
            _replicatorSender.Buffer.Add(podatak);
            _replicatorSender.Buffer.Add(podatak);

            //Act
            _replicatorSender.Prosledi(_replicatorReceiver, _logger);

            //Assert
            Assert.AreEqual(_replicatorReceiver.Buffer, tempList);
        }
        [TestCase(Code.CodeSpisak.CODE_ANALOG, 1)]
        [TestCase(Code.CodeSpisak.CODE_DIGITAL, 1)]
        [TestCase(Code.CodeSpisak.CODE_CUSTOM, 1)]
        [TestCase(Code.CodeSpisak.CODE_LIMITSET, 1)]
        [TestCase(Code.CodeSpisak.CODE_SOURCE, 1)]
        [TestCase(Code.CodeSpisak.CODE_CONSUMER, 1)]
        [TestCase(Code.CodeSpisak.CODE_SINGLENOE, 1)]
        [TestCase(Code.CodeSpisak.CODE_MULTIPLENODE, 1)]
        public void ReplicatorSender_Prosledi_Jedan(Code.CodeSpisak code, int value)
        {
            //Arange
            Podatak podatak = new Podatak(code, value);
            List<Podatak> tempList = new List<Podatak>() { podatak};
            ReplicatorSender _replicatorSender = new ReplicatorSender();
            ReplicatorReceiver _replicatorReceiver = new ReplicatorReceiver();
            Logger _logger = new Logger();
            _replicatorSender.Buffer.Add(podatak);

            //Act
            _replicatorSender.Prosledi(_replicatorReceiver, _logger);

            //Assert
            Assert.AreEqual(_replicatorReceiver.Buffer, tempList);
        }
    }
}
