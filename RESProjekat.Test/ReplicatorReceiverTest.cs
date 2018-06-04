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
    public class ReplicatorReceiverTest
    {
        [Test]
        public void ReplicatorReceiver_Razvrstaj()
        {
            //Arange
            Podatak[] p = new Podatak[1];
            Podatak podatak1 = new Podatak(Code.CodeSpisak.CODE_ANALOG, 1);
            Podatak podatak2 = new Podatak(Code.CodeSpisak.CODE_DIGITAL, 1);
            Podatak podatak3 = new Podatak(Code.CodeSpisak.CODE_CUSTOM, 1);
            Podatak podatak4 = new Podatak(Code.CodeSpisak.CODE_LIMITSET, 1);
            Podatak podatak5 = new Podatak(Code.CodeSpisak.CODE_SOURCE, 1);
            Podatak podatak6 = new Podatak(Code.CodeSpisak.CODE_CONSUMER, 1);
            Podatak podatak7 = new Podatak(Code.CodeSpisak.CODE_SINGLENOE, 1);
            Podatak podatak8 = new Podatak(Code.CodeSpisak.CODE_MULTIPLENODE, 1);
            List<Podatak> bufferPodaci = new List<Podatak> { podatak1,podatak2,podatak3,podatak4,podatak5,podatak6,podatak7,podatak8};
            CollectionDescription cd1 = new CollectionDescription();
            HistoricalCollection hc1 = new HistoricalCollection();
            hc1.ReceiverProperty = new Podatak[1] { podatak1 };
            cd1.Dataset = DataSet.DataSetSpisak.CACD;
            cd1.Hc = hc1;
            cd1.Id = 0;
            CollectionDescription cd2 = new CollectionDescription();
            HistoricalCollection hc2 = new HistoricalCollection();
            hc2.ReceiverProperty = new Podatak[1] { podatak2 };
            cd2.Dataset = DataSet.DataSetSpisak.CACD;
            cd2.Hc = hc2;
            cd2.Id = 1;
            CollectionDescription cd3 = new CollectionDescription();
            HistoricalCollection hc3 = new HistoricalCollection();
            hc3.ReceiverProperty = new Podatak[1] { podatak3 };
            cd3.Dataset = DataSet.DataSetSpisak.CCCL;
            cd3.Hc = hc3;
            cd3.Id = 2;
            CollectionDescription cd4 = new CollectionDescription();
            HistoricalCollection hc4 = new HistoricalCollection();
            hc4.ReceiverProperty = new Podatak[1] { podatak4 };
            cd4.Dataset = DataSet.DataSetSpisak.CCCL;
            cd4.Hc = hc4;
            cd4.Id = 3;
            CollectionDescription cd5 = new CollectionDescription();
            HistoricalCollection hc5 = new HistoricalCollection();
            hc5.ReceiverProperty = new Podatak[1] { podatak5 };
            cd5.Dataset = DataSet.DataSetSpisak.CCCS;
            cd5.Hc = hc5;
            cd5.Id = 4;
            CollectionDescription cd6 = new CollectionDescription();
            HistoricalCollection hc6 = new HistoricalCollection();
            hc6.ReceiverProperty = new Podatak[1] { podatak6 };
            cd6.Dataset = DataSet.DataSetSpisak.CCCS;
            cd6.Hc = hc6;
            cd6.Id = 5;
            CollectionDescription cd7 = new CollectionDescription();
            HistoricalCollection hc7 = new HistoricalCollection();
            hc7.ReceiverProperty = new Podatak[1] { podatak7 };
            cd7.Dataset = DataSet.DataSetSpisak.CSCM;
            cd7.Hc = hc7;
            cd7.Id = 6;
            CollectionDescription cd8 = new CollectionDescription();
            HistoricalCollection hc8 = new HistoricalCollection();
            hc8.ReceiverProperty = new Podatak[1] { podatak8 };
            cd8.Dataset = DataSet.DataSetSpisak.CSCM;
            cd8.Hc = hc8;
            cd8.Id = 7;
            List<CollectionDescription> collectionDescription = new List<CollectionDescription>() { cd1,cd2,cd3,cd4,cd5,cd6,cd7,cd8};
            ReplicatorReceiver _replicatorReceiver = new ReplicatorReceiver();
            _replicatorReceiver.Buffer = bufferPodaci;
            Logger l = new Logger();

            //Act
            _replicatorReceiver.Razvrstaj(l);

            //Assert
            //CollectionAssert.AreEqual(_replicatorReceiver.Cd, collectionDescription);
            for (int i = 0; i < _replicatorReceiver.Cd.Count; i++)
            {
                Assert.AreEqual(_replicatorReceiver.Cd[i].Hc.ReceiverProperty[0].Code, collectionDescription[i].Hc.ReceiverProperty[0].Code);
                Assert.AreEqual(_replicatorReceiver.Cd[i].Hc.ReceiverProperty[0].Value, collectionDescription[i].Hc.ReceiverProperty[0].Value);
            }
        }
        [Test]
        public void ReplicatorReceiver_Prosledi()
        {
            //Arange
            ReaderCACD rCACD = new ReaderCACD();
            ReaderCCCL rCCCL = new ReaderCCCL();
            ReaderCSCM rCSCM = new ReaderCSCM();
            ReaderCCCS rCCCS = new ReaderCCCS();
            Logger l = new Logger();
            ReplicatorReceiver _replicatorReceiver = new ReplicatorReceiver();
            Podatak[] p = new Podatak[1];
            Podatak podatak1 = new Podatak(Code.CodeSpisak.CODE_ANALOG, 1);
            Podatak podatak2 = new Podatak(Code.CodeSpisak.CODE_DIGITAL, 1);
            Podatak podatak3 = new Podatak(Code.CodeSpisak.CODE_CUSTOM, 1);
            Podatak podatak4 = new Podatak(Code.CodeSpisak.CODE_LIMITSET, 1);
            Podatak podatak5 = new Podatak(Code.CodeSpisak.CODE_SOURCE, 1);
            Podatak podatak6 = new Podatak(Code.CodeSpisak.CODE_CONSUMER, 1);
            Podatak podatak7 = new Podatak(Code.CodeSpisak.CODE_SINGLENOE, 1);
            Podatak podatak8 = new Podatak(Code.CodeSpisak.CODE_MULTIPLENODE, 1);
            CollectionDescription cd1 = new CollectionDescription();
            HistoricalCollection hc1 = new HistoricalCollection();
            hc1.ReceiverProperty = new Podatak[1] { podatak1 };
            cd1.Dataset = DataSet.DataSetSpisak.CACD;
            cd1.Hc = hc1;
            cd1.Id = 0;
            CollectionDescription cd2 = new CollectionDescription();
            HistoricalCollection hc2 = new HistoricalCollection();
            hc2.ReceiverProperty = new Podatak[1] { podatak2 };
            cd2.Dataset = DataSet.DataSetSpisak.CACD;
            cd2.Hc = hc2;
            cd2.Id = 1;
            CollectionDescription cd3 = new CollectionDescription();
            HistoricalCollection hc3 = new HistoricalCollection();
            hc3.ReceiverProperty = new Podatak[1] { podatak3 };
            cd3.Dataset = DataSet.DataSetSpisak.CCCL;
            cd3.Hc = hc3;
            cd3.Id = 2;
            CollectionDescription cd4 = new CollectionDescription();
            HistoricalCollection hc4 = new HistoricalCollection();
            hc4.ReceiverProperty = new Podatak[1] { podatak4 };
            cd4.Dataset = DataSet.DataSetSpisak.CCCL;
            cd4.Hc = hc4;
            cd4.Id = 3;
            CollectionDescription cd5 = new CollectionDescription();
            HistoricalCollection hc5 = new HistoricalCollection();
            hc5.ReceiverProperty = new Podatak[1] { podatak5 };
            cd5.Dataset = DataSet.DataSetSpisak.CCCS;
            cd5.Hc = hc5;
            cd5.Id = 4;
            CollectionDescription cd6 = new CollectionDescription();
            HistoricalCollection hc6 = new HistoricalCollection();
            hc6.ReceiverProperty = new Podatak[1] { podatak6 };
            cd6.Dataset = DataSet.DataSetSpisak.CCCS;
            cd6.Hc = hc6;
            cd6.Id = 5;
            CollectionDescription cd7 = new CollectionDescription();
            HistoricalCollection hc7 = new HistoricalCollection();
            hc7.ReceiverProperty = new Podatak[1] { podatak7 };
            cd7.Dataset = DataSet.DataSetSpisak.CSCM;
            cd7.Hc = hc7;
            cd7.Id = 6;
            CollectionDescription cd8 = new CollectionDescription();
            HistoricalCollection hc8 = new HistoricalCollection();
            hc8.ReceiverProperty = new Podatak[1] { podatak8 };
            cd8.Dataset = DataSet.DataSetSpisak.CSCM;
            cd8.Hc = hc8;
            cd8.Id = 7;
            List<CollectionDescription> collectionDescription = new List<CollectionDescription>() { cd1, cd2, cd3, cd4, cd5, cd6, cd7, cd8 };
            List<CollectionDescription> expectedCd = new List<CollectionDescription>() { cd1, cd2, cd3, cd4, cd5, cd6, cd7, cd8 };
            _replicatorReceiver.Cd = collectionDescription;

            //Act
            _replicatorReceiver.Prosledi(rCACD, rCCCL, rCSCM, rCCCS, l);

            //Assert
            Assert.AreEqual(expectedCd[0].Hc.ReceiverProperty[0],rCACD.Buffer[0].Item1);
            Assert.AreEqual(expectedCd[1].Hc.ReceiverProperty[0], rCACD.Buffer[0].Item2);
            Assert.AreEqual(expectedCd[2].Hc.ReceiverProperty[0], rCCCL.Buffer[0].Item1);
            Assert.AreEqual(expectedCd[3].Hc.ReceiverProperty[0], rCCCL.Buffer[0].Item2);
            Assert.AreEqual(expectedCd[4].Hc.ReceiverProperty[0], rCCCS.Buffer[0].Item1);
            Assert.AreEqual(expectedCd[5].Hc.ReceiverProperty[0], rCCCS.Buffer[0].Item2);
            Assert.AreEqual(expectedCd[6].Hc.ReceiverProperty[0], rCSCM.Buffer[0].Item1);
            Assert.AreEqual(expectedCd[7].Hc.ReceiverProperty[0], rCSCM.Buffer[0].Item2);
        }
    }
}
