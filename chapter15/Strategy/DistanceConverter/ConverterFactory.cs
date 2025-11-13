using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    public static class ConverterFactory {
        //あらかじめインスタンスを生成し、配列に入れとく
        private readonly static ConverterBase[] _convarters = {
            new MeterConverter(),
            new FeetConverter(),
            new YardConverter(),
            new InchConverter(),
        };
        public static ConverterBase? GetInstance(string  name) =>
            _convarters.FirstOrDefault(x=>x.IsMyUnit(name));
        
    }
}
