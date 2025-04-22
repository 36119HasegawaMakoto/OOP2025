using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    public static class FeetConverter {

        //定数
        private const double retio = 0.3048;

        //フィートからメートルへの対応表を出力
        public static double FromMeter(double meter) {
            return meter / retio;
        }
        //メートルからフィートへの対応表を出力
        public static double ToMeter(double feet) {
            return feet * retio;
        }
    }
}

