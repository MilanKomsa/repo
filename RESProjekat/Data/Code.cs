using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESProjekat.Data
{
    public struct Code
    {
        public enum CodeSpisak
        {
            CODE_ANALOG,
            CODE_DIGITAL,
            CODE_CUSTOM,
            CODE_LIMITSET,
            CODE_SINGLENOE,
            CODE_MULTIPLENODE,
            CODE_CONSUMER,
            CODE_SOURCE
        }
    }
}
