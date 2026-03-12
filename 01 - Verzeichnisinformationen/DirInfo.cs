using System;
using System.Collections.Generic;
using System.Text;

namespace _01___Verzeichnisinformationen
{
    internal class DirInfo
    {
        public string Pfad { get; set; }
        public DateTime ErstellungsDatum { get; set; }
        public int AnzahlDateien { get; set; }

        public override string ToString()
        {
            return $"{Pfad} Angelegt: {ErstellungsDatum} Anzahl Dateien: {AnzahlDateien}";
        }
    }
}
