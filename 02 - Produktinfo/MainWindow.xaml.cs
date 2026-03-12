using System.Diagnostics;
using System.IO;
using System.Runtime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _02___Produktinfo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Kategorie> kategorien = new List<Kategorie>();
        public MainWindow()
        {
            InitializeComponent();
            ProdukteEinlesen();
            ComboKategorien.ItemsSource = kategorien;
            
        }

        public void ProdukteEinlesen()
        {
            string pfad = @"..\..\..\Produkte\Produkte.json";
            JsonSerializerOptions opt = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve,

            };
            string json = File.ReadAllText(pfad);
            kategorien.AddRange(JsonSerializer.Deserialize<List<Kategorie>>(json, opt));

            //Zum Testen:
            //foreach (var kat in kategorien)
            //{
            //    Debug.WriteLine($"Kategorie: {kat.CategoryName}");
            //    foreach (var produkt in kat.Products)
            //    {
            //        Debug.WriteLine($"  {produkt.Name} - {produkt.Price} €");
            //    }
            //}
        }

        private void ComboKategorien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboKategorien.SelectedItem is Kategorie Auswahl)
            {
                ProduktBox.ItemsSource = Auswahl.Products;
            }
            
        }

        private void ProduktBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProduktBox.SelectedItem is Produkt p)
            {
                TextboxProduktname.Text = p.Name;
                TextboxPreis.Text = p.Price.ToString()+" €";
            }
        }
    }
}