using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCalculator {
    //売上集計クラス
    public class SalesCounter {
        private readonly List<Sale> _sales;

        //コンストラクタ
        public SalesCounter(List<Sale> sales) {
            _sales = sales;

        }
        //店舗別売上を求める
        public Dictionary<string, int> GetPerStoreSales() {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (Sale sale in _sales) {
                if (dict.ContainsKey(sale.ShopName))
                    dict[sale.ShopName] += sale.Amount;
                else
                    dict[sale.ShopName] = sale.Amount;

            }
            return dict;
        }
        //売上データを読み込み。Saleオブジェクトのリストを返す
        public static List<Sale> ReadSales(string filePath) {
            //売上データを入れるリストオブジェクトを生成
            List<Sale> sales = new List<Sale>();
            //ファイルを一気に読み込む
            string[] lines = File.ReadAllLines(filePath);
            //読み込んだ行数分繰り返し
            foreach (string line in lines) {
                string[] items = line.Split(',');
                //Saleオブジェクトを生成
                Sale sale = new Sale() {
                    ShopName = items[0],
                    ProductCategory = items[1],
                    Amount = int.Parse(items[2]),
                };
                sales.Add(sale);
            }

            return sales;


        }
    }

}
