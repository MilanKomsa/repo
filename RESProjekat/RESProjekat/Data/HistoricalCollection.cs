using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESProjekat.Data
{
    public class HistoricalCollection
    {
        Podatak[] receiverProperty;

        public HistoricalCollection()
        {
        }

        //public HistoricalCollection(Podatak[] p)
        //{
        //    receiverProperty = p;
        //}

        public Podatak[] ReceiverProperty { get => receiverProperty; set => receiverProperty = value; }
    }
}
