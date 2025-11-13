using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileProcessor {
    public abstract class TextProcessor {
        public static void Run<T>(string fileName) where T : TextProcessor, new() {
            var self = new T();
            self.Process(fileName);
        }

        private void Process(string fileName) {
            Initialize(fileName);
            var lines = File.ReadLines(fileName);
            Console.WriteLine("検索する単語");
            var tango = Console.ReadLine();
            foreach (var line in lines) {
                if (line.Contains(tango)) {
                    Execute(line);
                }
            }
            Terminate();
        }

        protected virtual void Initialize(string fname) { }
        protected virtual void Execute(string word) { }
        protected virtual void Terminate() { }
    }
}
