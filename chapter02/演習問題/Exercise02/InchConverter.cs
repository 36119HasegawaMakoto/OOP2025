﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    public static class InchConverter {

        //定数
        private const double retio = 0.9144;


        public static double FromMeter(double meter) {
            return meter * retio;
        }
        public static double FromYard(double yard) {
            return yard / retio;
        }
    }
}
