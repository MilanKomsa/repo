using RESProjekat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESProjekat
{
    public class ReplicatorReceiver
    {
        private List<Podatak> buffer = new List<Podatak>();
        private List<CollectionDescription> cd = new List<CollectionDescription>();
        private int brojac = 0;
        public Object obj = new Object();
        public ReplicatorReceiver()
        {
        }

        public void Razvrstaj(Logger l)
        {
            lock (obj)
            {
                HistoricalCollection hc = new HistoricalCollection();
                //Podatak a = new Podatak();
                int granica = buffer.Count;
                for (int i = 0; i < granica; granica--)
                {

                    //int x = a.Value;
                    Podatak[] p = new Podatak[1];

                    //a.Code = x.Code;
                    //a.Value = x.Value;
                    //p[0] = buffer[i];

                    //hc.ReceiverProperty = new Podatak[1] { buffer[i]};
                    if (buffer[i].Code == Code.CodeSpisak.CODE_ANALOG || buffer[i].Code == Code.CodeSpisak.CODE_DIGITAL)
                    {
                        CollectionDescription c = new CollectionDescription(brojac++, DataSet.DataSetSpisak.CACD, new HistoricalCollection(new Podatak[1] { buffer[i] }));
                        Cd.Add(c);
                        buffer.Remove(buffer[i]);
                    }
                    else if (buffer[i].Code == Code.CodeSpisak.CODE_CUSTOM || buffer[i].Code == Code.CodeSpisak.CODE_LIMITSET)
                    {
                        CollectionDescription c = new CollectionDescription(brojac++, DataSet.DataSetSpisak.CCCL, new HistoricalCollection(new Podatak[1] { buffer[i] }));
                        Cd.Add(c);
                        buffer.Remove(buffer[i]);
                    }
                    else if (buffer[i].Code == Code.CodeSpisak.CODE_SINGLENOE || buffer[i].Code == Code.CodeSpisak.CODE_MULTIPLENODE)
                    {
                        CollectionDescription c = new CollectionDescription(brojac++, DataSet.DataSetSpisak.CSCM, new HistoricalCollection(new Podatak[1] { buffer[i] }));
                        Cd.Add(c);
                        buffer.Remove(buffer[i]);
                    }
                    else
                    {
                        CollectionDescription c = new CollectionDescription(brojac++, DataSet.DataSetSpisak.CCCS, new HistoricalCollection(new Podatak[1] { buffer[i] }));
                        Cd.Add(c);
                        buffer.Remove(buffer[i]);
                    }
                }
                string s = String.Format("{0}: Replikator Receiver razvrstava", DateTime.Now);
                l.Upisi(s);
            }
            //switch (a.Code)
            //{
            //    case Code.CodeSpisak.CODE_ANALOG:
            //    cd.Dictionary.Add(Tuple.Create(++brojac, DataSet.DataSetSpisak.CACD), hc);
            //    break;
            //    case Code.CodeSpisak.CODE_DIGITAL:
            //    cd.Dictionary.Add(Tuple.Create(++brojac, DataSet.DataSetSpisak.CACD), hc);
            //    break;
            //    case Code.CodeSpisak.CODE_CUSTOM:
            //    cd.Dictionary.Add(Tuple.Create(++brojac, DataSet.DataSetSpisak.CCCL), hc);
            //    break;
            //    case Code.CodeSpisak.CODE_LIMITSET:
            //    cd.Dictionary.Add(Tuple.Create(++brojac, DataSet.DataSetSpisak.CCCL), hc);
            //    break;
            //case Code.CodeSpisak.CODE_SINGLENOE:
            //    cd.Dictionary.Add(Tuple.Create(++brojac, DataSet.DataSetSpisak.CSCM), hc);
            //    break;
            //    case Code.CodeSpisak.CODE_MULTIPLENODE:
            //    cd.Dictionary.Add(Tuple.Create(++brojac, DataSet.DataSetSpisak.CSCM), hc);
            //    break;
            //    case Code.CodeSpisak.CODE_CONSUMER:
            //    cd.Dictionary.Add(Tuple.Create(++brojac, DataSet.DataSetSpisak.CCCS), hc);
            //    break;
            //    case Code.CodeSpisak.CODE_SOURCE:
            //    cd.Dictionary.Add(Tuple.Create(++brojac, DataSet.DataSetSpisak.CCCS), hc);
            //    break;
            //    default:
            //        break;
            //}
        }
        public void Prosledi(ReaderCACD r1, ReaderCCCL r2, ReaderCSCM r3, ReaderCCCS r4, Logger l)
        {
            lock (obj)
            {
                int granica = Cd.Count;
                for (int i = 0; i < granica;i++)
                {

                    if (Cd[i].Dataset == DataSet.DataSetSpisak.CACD)
                        for (int j = 0+i; j < granica; j++)
                        {

                            if (Cd[j].Dataset == DataSet.DataSetSpisak.CACD && Cd[i].Hc.ReceiverProperty[0].Code != Cd[j].Hc.ReceiverProperty[0].Code)
                            {
                                Tuple<Podatak, Podatak> t = new Tuple<Podatak, Podatak>(Cd[i].Hc.ReceiverProperty[0], Cd[j].Hc.ReceiverProperty[0]);
                                r1.Buffer.Add(t);
                                Cd.Remove(Cd[i]);
                                Cd.Remove(Cd[j - 1]);
                                i--;
                                granica = granica - 2;
                                break;
                            }
                        }

                    else if (Cd[i].Dataset == DataSet.DataSetSpisak.CCCL)
                        for (int j = 0+i; j < granica; j++)
                        {

                            if (Cd[j].Dataset == DataSet.DataSetSpisak.CCCL && Cd[i].Hc.ReceiverProperty[0].Code != Cd[j].Hc.ReceiverProperty[0].Code)
                            {
                                Tuple<Podatak, Podatak> t = new Tuple<Podatak, Podatak>(Cd[i].Hc.ReceiverProperty[0], Cd[j].Hc.ReceiverProperty[0]);
                                r2.Buffer.Add(t);
                                Cd.Remove(Cd[i]);
                                Cd.Remove(Cd[j - 1]);
                                i--;
                                granica = granica - 2;
                                break;
                            }

                        }
                    else if (Cd[i].Dataset == DataSet.DataSetSpisak.CSCM)
                        for (int j = 0+i; j < granica; j++)
                        {

                            if (Cd[j].Dataset == DataSet.DataSetSpisak.CSCM && Cd[i].Hc.ReceiverProperty[0].Code != Cd[j].Hc.ReceiverProperty[0].Code)
                            {
                                Tuple<Podatak, Podatak> t = new Tuple<Podatak, Podatak>(Cd[i].Hc.ReceiverProperty[0], Cd[j].Hc.ReceiverProperty[0]);
                                r3.Buffer.Add(t);
                                Cd.Remove(Cd[i]);
                                Cd.Remove(Cd[j - 1]);
                                i--;
                                granica = granica - 2;
                                break;
                            }

                        }
                    else 
                        for (int j = 0+i; j < granica; j++)
                        {

                            if (Cd[j].Dataset == DataSet.DataSetSpisak.CCCS && Cd[i].Hc.ReceiverProperty[0].Code != Cd[j].Hc.ReceiverProperty[0].Code)
                            {
                                Tuple<Podatak, Podatak> t = new Tuple<Podatak, Podatak>(Cd[i].Hc.ReceiverProperty[0], Cd[j].Hc.ReceiverProperty[0]);
                                r4.Buffer.Add(t);
                                Cd.Remove(Cd[i]);
                                Cd.Remove(Cd[j - 1]);
                                i--;
                                granica = granica - 2;
                                break;
                            }

                        }
                }
                string s = String.Format("{0}: Replikator Receiver prosledjuje\n", DateTime.Now);
                l.Upisi(s);
            }
        }
        public List<Podatak> Buffer { get => buffer; set => buffer = value; }
        public List<CollectionDescription> Cd { get => cd; set => cd = value; }
    }
}
