using System.Text.Json;
using System.Threading.Channels;

namespace _01___Verzeichnisinformationen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<DirInfo> dir = Durchsuchen();

            ListeInJsonSpeichern(dir);

            ListeDeserialisieren();
        }
        static List<DirInfo> Durchsuchen()
        {
            string pfad = @"C:\Windows\";
            List<DirInfo> Verzeichnisse = new List<DirInfo>(); ;
            string[] verzeichnisse = Directory.GetDirectories(pfad);
            foreach (string d in verzeichnisse)
            {
                try
                {
                    string[] dateien = Directory.GetFiles(d);
                    DirectoryInfo info = new DirectoryInfo(d);
                    DirInfo vz = new DirInfo();
                    vz.Pfad = d;
                    vz.ErstellungsDatum = info.CreationTime;
                    vz.AnzahlDateien = dateien.Length;
                    Verzeichnisse.Add(vz);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return Verzeichnisse;

        }

        static void ListeInJsonSpeichern(List<DirInfo> liste)
        {
            JsonSerializerOptions opt = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(liste, opt);
            File.AppendAllText(@"..\..\..\Text\DirInfoText.json", json + "\n");

        }

        static void ListeDeserialisieren()
        {
            JsonSerializerOptions opt = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            FileStream fs = new FileStream(@"..\..\..\Text\DirInfoText.json", FileMode.Open, FileAccess.Read);
            StreamReader l = new StreamReader(fs);

            List<DirInfo> d = JsonSerializer.Deserialize<List<DirInfo>>(l.ReadToEnd(), opt);
            foreach (DirInfo s in d)
            {
                Console.WriteLine(s);
            }


        }
    }
}
