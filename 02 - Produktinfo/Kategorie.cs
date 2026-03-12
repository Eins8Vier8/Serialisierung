using System;
using System.Collections.Generic;
using System.Text;

namespace _02___Produktinfo
{
    public class Kategorie
    {
        public List<Produkt> Products { get; set; }
        public string CategoryName { get; set; }

        public override string ToString()
        {
            return $"{CategoryName}";
        }
    }
}
