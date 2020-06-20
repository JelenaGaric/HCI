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

namespace ProjekatHCI.Unos
{
    /// <summary>
    /// Interaction logic for UnosEtikete.xaml
    /// </summary>
    public partial class UnosEtikete : Window
    {
        public UnosEtikete()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            listaEtiketa.ItemsSource = MainWindow.Lista4;
            if (listaEtiketa.SelectedItem == null)
            {
                txtEtiketa.Text = "Ništa nije selektovano iz liste etiketa...";
            }
            listaEtiketa.SelectionMode = SelectionMode.Single;
        }

        private void DodajBtn_Click(object sender, RoutedEventArgs e)
        {
            NovaEtiketa n = new NovaEtiketa();
            n.Show();
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ObrisiBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Lista4.RemoveAt(listaEtiketa.SelectedIndex);
        }
        private void cp_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (cp.SelectedColor.HasValue)
            {
               
            }
        }

        private void ListaEtiketa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Etiketa et = (Etiketa)listaEtiketa.SelectedItem;
            cp.SelectedColor = et.Boja;
        }

        private void OdustaniBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
