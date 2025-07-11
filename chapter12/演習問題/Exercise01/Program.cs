using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;
using System.Xml;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var emp = new Employee {
                Id = 123,
                Name = "長嶋健一",
                HireDate = new DateTime(1980, 10, 21),
            };
            var jsonString = Serialize(emp);
            Console.WriteLine(jsonString);
            var obj = Deserialize(jsonString);
            Console.WriteLine(obj);
        }
        static string Serialize(Employee emp) {
            var options = new JsonSerializerOptions {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            };
            string jsonString = JsonSerializer.Serialize(emp, options);
            return jsonString;
        }
        static Employee? Deserialize(string text) {
            return JsonSerializer.Deserialize<Employee>(text);
            
        }
        public record Employee {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public DateTime HireDate { get; set; }
        }
    }
}
