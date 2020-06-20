using ProjekatHCI.Unos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjekatHCI.Prikaz
{
    /// <summary>
    /// Interaction logic for Tip.xaml
    /// </summary>
    public partial class Tip : Window
    {

        public Tip()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            listaTipova.ItemsSource = MainWindow.Lista1;
        }

        private void ListaTipova_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
             
        private void DodajBtn_Click(object sender, RoutedEventArgs e)
        {
            UnosNovogTipa u = new UnosNovogTipa();
            u.Show();
        }

        private void ObrisiBtn_Click(object sender, RoutedEventArgs e)
        {
            Manifestacija zaBrisanje = new Manifestacija();
            foreach (Manifestacija m in MainWindow.manifestacije)
            {
                if(m.TipManifestacijeStr == ((TipKomponenta)listaTipova.SelectedItem).Naziv_Tipa)
                {
                     zaBrisanje = m;
                }
            }

            MainWindow.manifestacije.Remove(zaBrisanje);

            MainWindow.Lista1.RemoveAt(listaTipova.SelectedIndex);

        }
    }
}
