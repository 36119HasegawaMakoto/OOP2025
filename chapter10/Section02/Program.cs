namespace Section02 {
    internal class Program {
        static void Main(string[] args) {
            var filePath = "吾輩は猫である.txt";
            using (var witer = new StreamWriter(filePath)) {
                witer.WriteLine("いろはにほへと　ちりぬるを");
                witer.WriteLine("我が世たれぞ　常ならむ");
                witer.WriteLine("宇井の奥山　今日超えて");
                witer.WriteLine("あさきゆめみし　酔いもせず");
            }
        }
    }
}
