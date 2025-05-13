using System.Reflection;

namespace Exercise01 {
    public class Program {
        static void Main(string[] args) {

            //2.1.3
            var songs = new Song[] {
                new Song("Let it be", "The Beatles", 243),
                new Song("Bridge Over Troubled Water", "Simon & Garfunkel", 293),
                new Song("Close To You", "Carpenters", 276),
                new Song("Honesty", "Billy Joel", 231),
                new Song("I Will Always Love You", "Whitney Houston", 273),
            };
            printSongs(songs);
        }
        //2.1.4
        private static void printSongs(Song[] songs) {
            foreach(Song song in songs) {
                TimeSpan time =  TimeSpan.FromSeconds(song.Length);
                Console.WriteLine(song.Title + " : " + song.ArtistName + " : " + time.ToString(@"mm\:ss"));
            }
           
        }
    }
}
