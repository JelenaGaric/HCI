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
    /// Interaction logic for ListaManifestacja.xaml
    /// </summary>
    public partial class ListaManifestacja : Window
    {
        public ListaManifestacja()
        {
            InitializeComponent();
            listViewManifestacije.ItemsSource = MainWindow.manifestacije;

            listViewManifestacije.SelectionMode = SelectionMode.Single;
        }
    }
}
