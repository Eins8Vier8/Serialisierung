using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    internal class Person
    {
        private string vorname;
        public string Vorname { get=> vorname; set=>vorname =value; }
        public string Nachname { get; set; }
        public int Alter { get; set; }
        public string Telefon { get; set; }
        public bool Männlich { get; set; }
        public string[] Hobbys { get; set; }
        public Person[] Kinder { get; set; }
        public Person Partner { get; set; }
        public Adress Adresse { get; set; }
    }
}
