using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    //5.1.1
    public record YearMonth(int Year, int Month) {
        public int Year { get; init; } = Year;
        public int Month { get; init; } = Month;

        //5.1.2
        //設定されている西暦が21世紀か判定する　Yearが2001～2100年の間ならture,それ以外ならfalseを返す
        public bool Is21Century => 2001 <= Year && Year <= 2100;

        //5.1.3
        public YearMonth AddOneMonth() {            
            if(Month < 12) {
                return new YearMonth(Year, Month + 1);               
            } else {
                return new YearMonth(Year + 1, 1);
            }
            
        }
        //5.1.4
        public override string ToString() => Year + "年" + Month + "月";
            
        
    }
}
