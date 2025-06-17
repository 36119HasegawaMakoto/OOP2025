using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test01 {
    public class Student {
        public required string Name { get; init; } //学生の名前
        public required string Subject { get; init; } //科目名
        public required int Score { get; init; } //点数
    }
}
