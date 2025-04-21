using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSample {
    //商品クラス
    public class Product {
        //商品コード
        public int Code { get; private set; }           //プロパティ
        //商品名
        public string Name { get; private set; }
        //商品価格（税抜き）
        public int Price { get; private set; }

        //消費税率は10％
        private readonly double _taxRate = 0.1; //フィールド

        //消費税額を求める
        public int GetTax() {                   //メソッド
            return (int)(Price * _taxRate);
        }

        //コンストラクタ
        public Product (int code, string name, int price) {
            this.Code = code;
            this.Name = name;
            this.Price = price;
        }

        //税込み価格を求める
        public int GetPriceIncludingTax() {
            return Price + GetTax();
        }

    }
}
