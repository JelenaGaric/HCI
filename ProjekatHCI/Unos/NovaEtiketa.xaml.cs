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


namespace ProjekatHCI.Unos
{
    /// <summary>
    /// Interaction logic for NovaEtiketa.xaml
    /// </summary>
    public partial class NovaEtiketa : Window
    {
        public NovaEtiketa()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Lista4.Add(new Etiketa() { NazivEtikete = etiketaTxt.Text, Boja = (Color)cp.SelectedColor, OpisEtikete = opisTxt.Text });
            this.Close();
        }

        private void OdustaniBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
