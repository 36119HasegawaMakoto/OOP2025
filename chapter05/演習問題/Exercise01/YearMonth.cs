using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    //5.1.1
    public class YearMonth {
        public int Year { get; init; }
        public int Month { get; init; }

        public YearMonth(int year, int month) {
            Year = year;
            Month = month;
        }
        //5.1.2
        //設定されている西暦が21世紀か判定する　Yearが2001～2100年の間ならture,それ以外ならfalseを返す
        public bool Is21Century(int year) => year >= 2001 && year <= 2100;

        //5.1.3
        public YearMonth AddOneMonth() {
            int nextYear = Year;
            int nextMonth = Month;
            if(Month < 12) {
                nextMonth++;                
            } else {
                nextYear++;
                nextMonth = 1;
            }
            return new YearMonth(nextYear, nextMonth);
        }
        //5.1.4
        public override string ToString() => Year + "年" + Month + "月";
            
        
    }
}
