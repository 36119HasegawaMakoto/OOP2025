using System.Reflection;

namespace Exercise01 {
    public class Program {
        static void Main(string[] args) {
            //データ入れるリストを生成
            var sing = new List<Song>();
            Console.WriteLine("***  曲の登録　***");
            while (true) {
                Console.Write("曲名:");
                string? title = Console.ReadLine();
                if (title.Equals("end", StringComparison.OrdinalIgnoreCase))
                    break;

                Console.Write("アーティスト名");
                string? artistName = Console.ReadLine();
                Console.Write("演奏時間（秒）");
                int length = int.Parse(Console.ReadLine());
                var song = new Song() {
                    Title = title,
                    ArtistName = artistName,
                    Length = length
                };
                sing.Add(song);
                
            }
            printSongs(sing);
        }


        //2.1.4
        private static void printSongs(IEnumerable<Song> sing) {
            foreach (Song song in sing) {
                TimeSpan time = TimeSpan.FromSeconds(song.Length);
                Console.WriteLine(song.Title + " : " + song.ArtistName + " : " + time.ToString(@"mm\:ss"));
            }

        }
    }
}
