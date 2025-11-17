using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileProcessorDI {
    public class LineCoumterService : ITextFileService {
        private int _count = 0;

         public void Initialize(string fname) {
             _count = 0;
        }

         public void Execute(string line) {
            _count++;
        }

         public void Terminate() {
            Console.WriteLine("{0} 個", _count);
        }
    }
}
