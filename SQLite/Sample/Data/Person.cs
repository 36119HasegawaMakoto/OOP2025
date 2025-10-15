using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Data {
    public class Person {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// 電話番号
        /// </summary>
        public string Phone { get; set; } = string.Empty;

        public override string ToString() {
            return $"{Id}{Name}{Phone}";
        }

    }
}
