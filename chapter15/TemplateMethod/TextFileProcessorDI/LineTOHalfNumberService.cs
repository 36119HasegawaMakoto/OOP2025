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
            //string result = new string(
            //    line.Select(c => ('０' <= c && c <= '９') ? (char)(c - '０' + '0') : c).ToArray());
            Console.WriteLine(num);
        }
        

        public void Terminate() {

        }
    }
}

