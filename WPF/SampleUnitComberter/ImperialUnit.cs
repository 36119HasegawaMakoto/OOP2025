using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUnitComberter {
    class ImperialUnit :DIstanceUnit{
        private static List<ImperialUnit> units = new List<ImperialUnit>{
            new ImperialUnit{Name = "in",Coefficient = 1, },
            new ImperialUnit{Name = "ft",Coefficient = 12, },
            new ImperialUnit{Name = "yd",Coefficient = 12 * 3, },
            new ImperialUnit{Name = "ml",Coefficient = 10 * 3 * 1760, },

        };
        public static ICollection<ImperialUnit> Units { get => units; }

        /// <summary>
        /// メートル単位からヤード単位に変換
        /// </summary>
        /// <param name="unit">変換元の単位</param>
        /// <param name="value">変換する値</param>
        /// <returns>変換した値</returns>
        public double FromMetricUnit(MetricUnit unit, Double value) {
            return (value * unit.Coefficient) / 25.4 / Coefficient;
        }
    }
}
