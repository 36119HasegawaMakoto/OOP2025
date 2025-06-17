namespace Test01 {
    public class ScoreCounter {
        private IEnumerable<Student> _score;

        // コンストラクタ
        public ScoreCounter(string filePath) {
            _score = ReadScore(filePath);
        }

        //メソッドの概要： 点数を読み込み。Studentオブジェクトのリストを返す
        private static IEnumerable<Student> ReadScore(string filePath) {
            //点数を入れるリストオブジェクトを生成
            var students = new List<Student>();
            //ファイルを一気に読み込む
            string[] lines = File.ReadAllLines(filePath);
            //読み込んだ行数分繰り返し
            foreach (var line in lines) {
                string[] items = line.Split(',');
                //Studentオブジェクトを生成
                var student = new Student() {
                    Name = items[0],
                    Subject = items[1],
                    Score = int.Parse(items[2]),
                };
                students.Add(student);
            }
            return students;
        }

        //メソッドの概要： 科目別の点数を求める
        public IDictionary<string, int> GetPerStudentScore() {
            var dict = new Dictionary<string, int>();
            foreach (var student in _score) {
                if (dict.ContainsKey(student.Subject))
                    dict[student.Subject] += student.Score;
                else
                    dict[student.Subject] = student.Score;

            }
            return dict;




        }
    }
}
