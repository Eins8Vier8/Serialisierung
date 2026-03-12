using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Latin1;

            JsonSerializerOptions opt = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            };
            string json = File.ReadAllText(@"..\..\..\Text\jsconfig1.json");
            Console.WriteLine(json);
            Person x = JsonSerializer.Deserialize<Person>(json,opt);
            x.Partner = new Person
            {
                Vorname = "Gertrud",
                Nachname = "Schneider",
                Alter = 43,
                Telefon = "0178342323",
                Männlich = false,
                Hobbys = ["Lesen", "Fahrrad fahren"],
                Kinder = null,
                Partner = x,
                Adresse = x.Adresse
            };

            string json2 = JsonSerializer.Serialize(x,opt);
            Console.WriteLine(json2);
            File.WriteAllText(@"..\..\..\Text\jsconfig1.json", json2);
        }
    }
}
