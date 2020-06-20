using ProjekatHCI.Unos;
using ProjekatHCI;

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
    /// Interaction logic for PrikazManifestacija.xaml
    /// </summary>
    public partial class PrikazManifestacija : Window
    {
        public PrikazManifestacija()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            dataGrid1.ItemsSource = MainWindow.manifestacije;
            dataGrid1.SelectionMode = DataGridSelectionMode.Single;
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DodajBtn_Click(object sender, RoutedEventArgs e)
        {
            Unos.Unos_Podataka u = new Unos.Unos_Podataka();
            u.Show();
        }

        private void ObrisiBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.manifestacije.Remove((Manifestacija)(dataGrid1.SelectedItem));
        }
    }
}
