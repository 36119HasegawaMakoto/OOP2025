namespace Section05 {
    internal class Program {
        static void Main(string[] args) {
            var text = "The quick brown fox jumps over the lazy dog";
            var words = text.Split(' ');
            var wood = words.FirstOrDefault(s => s.Length == 4);

            var numbers = new List<int> { 9, 7, -5, -4, 2, 5, 4, 0, -4, 8, -1, 0, 4 };
            var index = numbers.FindIndex(n => n < 0);



        }
    }
}
