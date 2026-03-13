
using System.Runtime;
using System.Text.Json;

namespace _03___FizzBuzz
{
    internal class Program
    {
        static List<Teiler> listeTeiler = new List<Teiler>();
        static void Main(string[] args)
        {
            Menue();
            // FizzBuzz(); //<== Erster Aufgabenteil
        }

        private static void Menue()
        {
            Console.WriteLine("Menü:\n 1: Eigene Angaben\n 2: JSON-Datei angeben ");
            int auswahl = int.Parse(Console.ReadLine());
            switch (auswahl)
            {
                case 1:
                    Eingabe();
                    JsonErstellen();
                    AusgabeAusJson();
                    break;
                case 2:
                    string dateiname = EingabeJson();
                    AusgabeAusJson(dateiname);
                    break;
                default:
                    Console.WriteLine("Keine gültige Auswahl!");
                    Console.ReadKey();
                    break;
            }
        }

        private static void AusgabeAusJson()
        {
            JsonSerializerOptions opt = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };
            FileStream fs = new FileStream($@"..\..\..\Text\FizzBuzz.json", FileMode.Open, FileAccess.Read);
            StreamReader l = new StreamReader(fs);

            List<Teiler> listeAusgabe = JsonSerializer.Deserialize<List<Teiler>>(l.ReadToEnd(), opt);

            for (int i = 1; i <= 100; i++)
            {
                string ausgabe = string.Empty;
                foreach (Teiler t in listeAusgabe)
                {
                    if (i % t.Value == 0)
                        ausgabe += t.Output;
                }
                if (string.IsNullOrEmpty(ausgabe))
                    ausgabe += i;
                Console.WriteLine(ausgabe);
            }
        }

        private static void AusgabeAusJson(string dateiname)
        {
            JsonSerializerOptions opt = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };
            FileStream fs = new FileStream($@"..\..\..\Text\{dateiname}.json", FileMode.Open, FileAccess.Read);
            StreamReader l = new StreamReader(fs);

            List<Teiler> listeAusgabe = JsonSerializer.Deserialize<List<Teiler>>(l.ReadToEnd(), opt);

            for (int i = 1; i <= 100; i++)
            {
                string ausgabe = string.Empty;
                foreach (Teiler t in listeAusgabe)
                {
                    if (i % t.Value == 0)
                        ausgabe += t.Output;
                }
                if (string.IsNullOrEmpty(ausgabe))
                    ausgabe += i;
                Console.WriteLine(ausgabe);
            }
        }


        private static void JsonErstellen()
        {
            JsonSerializerOptions opt = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(listeTeiler, opt);
            File.WriteAllText(@"..\..\..\Text\FizzBuzz.json", json);
        }

        private static string EingabeJson()
        {
            Console.Write("Dateinamen angeben: ");
            string dateiname = Console.ReadLine();
            return dateiname;
        }

        private static void Eingabe()
        {
            Console.Write("Anzahl Teiler: ");
            int anzahlTeiler = int.Parse(Console.ReadLine());
            for (int i = 0; i < anzahlTeiler; i++)
            {
                Console.Write("Teiler: ");
                int teiler = int.Parse(Console.ReadLine());
                Console.Write("\nAusgabe: ");
                string ausgabe = Console.ReadLine();
                if (teiler != 0 && ausgabe != null)
                {
                    Teiler t = new Teiler();
                    t.Value = teiler;
                    t.Output = ausgabe;
                    listeTeiler.Add(t);
                }   
            }
        }

        static public void FizzBuzz()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                    Console.WriteLine("FizzBuzz");
                else if (i % 3 == 0)
                    Console.WriteLine("Fizz");
                else if (i % 5 == 0)
                    Console.WriteLine("Buzz");
                else
                    Console.WriteLine(i);
            }
        }
    }
}
