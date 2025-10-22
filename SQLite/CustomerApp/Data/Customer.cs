using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CustomerApp.Data {
    internal class Customer {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// 電話番号
        /// </summary>
        public string Phone {  get; set; } =string.Empty;
        /// <summary>
        /// 住所
        /// </summary>
        public string Address { get; set; } = string.Empty;
        /// <summary>
        /// 画像
        /// </summary>
        public byte[] Picture {  get; set; }

        public BitmapImage PictureImage {
            get {
                if (Picture == null) return null;
                using (var ms = new MemoryStream(Picture)) {
                    var image = new BitmapImage();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = ms;
                    image.EndInit();
                    return image;
                }
            }
        }
    }
}
