using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    public class MeterConverter : ConverterBase {
        public override bool IsMyUnit(string name) =>
            name.ToLower() == "meter" || name == UnitName;
        protected override double Ratio => 1;
        public override string UnitName => "メートル";        
    }
    public class FeetConverter : ConverterBase {
        public override bool IsMyUnit(string name) =>
            name.ToLower() == "feet" || name == UnitName;
        protected override double Ratio => 0.3048;
        public override string UnitName => "フィート";
    }
    public class InchConverter : ConverterBase {
        public override bool IsMyUnit(string name) =>
            name.ToLower() == "inch" || name == UnitName;
        protected override double Ratio => 0.0254;
        public override string UnitName => "インチ";
    }
    public class YardConverter : ConverterBase {
        public override bool IsMyUnit(string name) =>
            name.ToLower() == "yard" || name == UnitName;
        protected override double Ratio => 0.9144;
        public override string UnitName => "ヤード";
    }
    public class MileConverter : ConverterBase {
        public override bool IsMyUnit(string name) =>
            name.ToLower() == "mile" || name == UnitName;
        protected override double Ratio => 1609.344;
        public override string UnitName => "マイル";
    }
    public class KmConverter : ConverterBase {
        public override bool IsMyUnit(string name) =>
            name.ToLower() == "km" || name == UnitName;
        protected override double Ratio => 1000;
        public override string UnitName => "キロメートル";
    }


}
