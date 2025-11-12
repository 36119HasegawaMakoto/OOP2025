using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFileProcessor;

namespace LineCounter {
    internal class LineCounterProcessor : TextProcessor {
        private int _count = 0;

        protected override void Initialize(string fname) => _count = 0;

        protected override void Execute(string line) => _count++;


        protected override void Terminate() => Console.WriteLine("{0} 個", _count);
    }
}
