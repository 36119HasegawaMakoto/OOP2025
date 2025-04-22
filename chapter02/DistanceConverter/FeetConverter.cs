using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    public class FeetConverter {
        //フィートからメートルへの対応表を出力
        public static double FromMeter(double meter) {
            return meter / 0.3048;
        }



        //メートルからフィートへの対応表を出力
        public static double ToMeter(double feet) {
            return feet * 0.3048;
        }
    }
}

