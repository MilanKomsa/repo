using RESProjekat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESProjekat
{
    public struct Podatak
    {
        private Code.CodeSpisak code;
        private int value;


        public Podatak(Code.CodeSpisak c, int v)
        {
            code = c;
            value = v;
        }
        public Code.CodeSpisak Code { get => code; set => code = value; }
        public int Value { get => value; set => this.value = value; }
    }
}
