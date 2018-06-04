using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESProjekat.Data
{
    public class CollectionDescription
    {
        private int id;
        private DataSet.DataSetSpisak dataset;
        private HistoricalCollection hc;

        public CollectionDescription()
        {
        }

        public CollectionDescription(int id, DataSet.DataSetSpisak dataset, HistoricalCollection hc)
        {
            this.id = id;
            this.dataset = dataset;
            this.hc = hc;
        }


        public int Id { get => id; set => id = value; }
        public DataSet.DataSetSpisak Dataset { get => dataset; set => dataset = value; }
        public HistoricalCollection Hc { get => hc; set => hc = value; }
    }
}
