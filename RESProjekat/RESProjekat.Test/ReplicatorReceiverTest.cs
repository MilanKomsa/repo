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
            //Arrange
            Podatak[] p = new Podatak[1];
            List<CollectionDescription> collectionDescription = new List<CollectionDescription>();
            int brojac = 0;
            Podatak podatak1 = new Podatak(Code.CodeSpisak.CODE_ANALOG, 1);
            Podatak podatak2 = new Podatak(Code.CodeSpisak.CODE_DIGITAL, 1);
            Podatak podatak3 = new Podatak(Code.CodeSpisak.CODE_CUSTOM, 1);
            Podatak podatak4 = new Podatak(Code.CodeSpisak.CODE_LIMITSET, 1);
            Podatak podatak5 = new Podatak(Code.CodeSpisak.CODE_SOURCE, 1);
            Podatak podatak6 = new Podatak(Code.CodeSpisak.CODE_CONSUMER, 1);
            Podatak podatak7 = new Podatak(Code.CodeSpisak.CODE_SINGLENOE, 1);
            Podatak podatak8 = new Podatak(Code.CodeSpisak.CODE_MULTIPLENODE, 1);
            List<Podatak> bufferPodaci = new List<Podatak> { podatak1,podatak2,podatak3,podatak4,podatak5,podatak6,podatak7,podatak8};
            //bufferPodaci.Add(podatak1);
            //bufferPodaci.Add(podatak2);
            //bufferPodaci.Add(podatak3);
            //bufferPodaci.Add(podatak4);
            //bufferPodaci.Add(podatak5);
            //bufferPodaci.Add(podatak6);
            //bufferPodaci.Add(podatak7);
            //bufferPodaci.Add(podatak8);

            HistoricalCollection hc1 = new HistoricalCollection();
            HistoricalCollection hc2 = new HistoricalCollection();
            HistoricalCollection hc3 = new HistoricalCollection();
            HistoricalCollection hc4 = new HistoricalCollection();
            HistoricalCollection hc5 = new HistoricalCollection();
            HistoricalCollection hc6 = new HistoricalCollection();
            HistoricalCollection hc7 = new HistoricalCollection();
            HistoricalCollection hc8 = new HistoricalCollection();
           
            
            hc1.ReceiverProperty[0] = podatak1;
            collectionDescription.Add(new CollectionDescription(brojac++, DataSet.DataSetSpisak.CACD, hc1));
            p[0] = podatak2;
            hc2.ReceiverProperty[0] = podatak2;
            collectionDescription.Add(new CollectionDescription(brojac++, DataSet.DataSetSpisak.CACD, hc2));
            p[0] = podatak3;
            hc3.ReceiverProperty = p;
            collectionDescription.Add(new CollectionDescription(brojac++, DataSet.DataSetSpisak.CCCL, hc3));
            p[0] = podatak4;
            hc4.ReceiverProperty = p;
            collectionDescription.Add(new CollectionDescription(brojac++, DataSet.DataSetSpisak.CCCL, hc4));
            p[0] = podatak5;
            hc5.ReceiverProperty = p;
            collectionDescription.Add(new CollectionDescription(brojac++, DataSet.DataSetSpisak.CCCS, hc5));
            p[0] = podatak6;
            hc6.ReceiverProperty = p;
            collectionDescription.Add(new CollectionDescription(brojac++, DataSet.DataSetSpisak.CCCS, hc6));
            p[0] = podatak7;
            hc7.ReceiverProperty = p;
            collectionDescription.Add(new CollectionDescription(brojac++, DataSet.DataSetSpisak.CSCM, hc7));
            p[0] = podatak8;
            hc8.ReceiverProperty = p;
            collectionDescription.Add(new CollectionDescription(brojac++, DataSet.DataSetSpisak.CSCM, hc8));

            ReplicatorReceiver _replicatorReceiver = new ReplicatorReceiver();
            _replicatorReceiver.Buffer = bufferPodaci;
            Logger l = new Logger();

            //Act
            _replicatorReceiver.Razvrstaj(l);

            //Assert
            for(int i = 0; i<_replicatorReceiver.Cd.Count;i++)
            {
                Assert.AreEqual(_replicatorReceiver.Cd[i].Hc.ReceiverProperty[0].Code, collectionDescription[0].Hc.ReceiverProperty[0].Code);
                Assert.AreEqual(_replicatorReceiver.Cd[i].Hc.ReceiverProperty[0].Value, collectionDescription[0].Hc.ReceiverProperty[0].Value);
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
            List<CollectionDescription> collectionDescription = new List<CollectionDescription>();
            Podatak[] p = new Podatak[1];
            int brojac = 0;
            Podatak podatak1 = new Podatak(Code.CodeSpisak.CODE_ANALOG, 1);
            Podatak podatak2 = new Podatak(Code.CodeSpisak.CODE_DIGITAL, 1);
            Podatak podatak3 = new Podatak(Code.CodeSpisak.CODE_CUSTOM, 1);
            Podatak podatak4 = new Podatak(Code.CodeSpisak.CODE_LIMITSET, 1);
            Podatak podatak5 = new Podatak(Code.CodeSpisak.CODE_SOURCE, 1);
            Podatak podatak6 = new Podatak(Code.CodeSpisak.CODE_CONSUMER, 1);
            Podatak podatak7 = new Podatak(Code.CodeSpisak.CODE_SINGLENOE, 1);
            Podatak podatak8 = new Podatak(Code.CodeSpisak.CODE_MULTIPLENODE, 1);

            HistoricalCollection hc = new HistoricalCollection();
            p[0] = podatak1;
            hc.ReceiverProperty = p;
            collectionDescription.Add(new CollectionDescription(brojac++, DataSet.DataSetSpisak.CACD, hc));
            p[0] = podatak2;
            hc.ReceiverProperty = p;
            collectionDescription.Add(new CollectionDescription(brojac++, DataSet.DataSetSpisak.CACD, hc));
            p[0] = podatak3;
            hc.ReceiverProperty = p;
            collectionDescription.Add(new CollectionDescription(brojac++, DataSet.DataSetSpisak.CCCL, hc));
            p[0] = podatak4;
            hc.ReceiverProperty = p;
            collectionDescription.Add(new CollectionDescription(brojac++, DataSet.DataSetSpisak.CCCL, hc));
            p[0] = podatak5;
            hc.ReceiverProperty = p;
            collectionDescription.Add(new CollectionDescription(brojac++, DataSet.DataSetSpisak.CCCS, hc));
            p[0] = podatak6;
            hc.ReceiverProperty = p;
            collectionDescription.Add(new CollectionDescription(brojac++, DataSet.DataSetSpisak.CCCS, hc));
            p[0] = podatak7;
            hc.ReceiverProperty = p;
            collectionDescription.Add(new CollectionDescription(brojac++, DataSet.DataSetSpisak.CSCM, hc));
            p[0] = podatak8;
            hc.ReceiverProperty = p;
            collectionDescription.Add(new CollectionDescription(brojac++, DataSet.DataSetSpisak.CSCM, hc));
            _replicatorReceiver.Cd = collectionDescription;

            //Act
            _replicatorReceiver.Prosledi(rCACD, rCCCL, rCSCM, rCCCS, l);

            //Assert
            Assert.AreEqual(_replicatorReceiver.Cd[0].Hc.ReceiverProperty[0],rCACD.Buffer[0].Item1);
        }
    }
}
