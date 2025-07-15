using System.Text.Json;
using System.IO;
using System.Xml.Serialization;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Xml;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var employees = Deserialize("employees.json");
            ToXmlFile(employees);
        }

        static Employee[] Deserialize(string filePath) {
            var options = new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            };
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<Employee[]>(json, options) ?? [];

        }

        static void ToXmlFile(Employee[] employees) {            
            using (var writer = XmlWriter.Create("employee.xml")) {
                XmlRootAttribute xRoot = new XmlRootAttribute {
                    ElementName = "Employees"
                };
                var serializer = new XmlSerializer(employees.GetType(),xRoot);
                serializer.Serialize(writer, employees);
            }
        }
    }

    public record Employee {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime HireDate { get; set; }
    }
}
