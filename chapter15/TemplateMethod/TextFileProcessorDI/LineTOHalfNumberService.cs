using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileProcessorDI {
    public class LineTOHalfNumberService : ITextFileService {
        //p362 問題15.1

        public void Initialize(string fname) {
            
        }

        public void Execute(string line) {
            string num = Strings.StrConv(line, VbStrConv.Narrow, 0);
            Console.WriteLine(num);
        }

        public void Terminate() {

        }
    }
}

