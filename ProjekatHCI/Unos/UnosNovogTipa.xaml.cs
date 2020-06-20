using Microsoft.Win32;
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
    /// Interaction logic for UnosNovogTipa.xaml
    /// </summary>
    public partial class UnosNovogTipa : Window
    {
        public UnosNovogTipa()
        {
            InitializeComponent();
            slikaTxt.IsEnabled = false;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            int flag = 0;
            

            foreach (TipKomponenta t in MainWindow.Lista1)
            {
                if (t.Naziv_Tipa == nazivTxt.Text)
                {
                    flag = 1;
                }
            }
            if (flag != 1)
            {
                

                MainWindow.Lista1.Add(new TipKomponenta() { Naziv_Tipa = nazivTxt.Text,
                    OznakaTipa = oznakaTxt.Text, OpisTipa = opisTxt.Text, SlikaTipa = slikaTxt.Text });
                this.Close();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Taj tip manifestacije već postoji!", "Greška!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            
        }

        private void OdustaniBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BrowseBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.Title = "Odaberi ikonicu manifestacije...";
            fileDialog.Filter = "Images|*.jpg;*.jpeg;*.png|" +
                                "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                                "Portable Network Graphic (*.png)|*.png";
            if (fileDialog.ShowDialog() == true)
            {
                ikonica.Source = new BitmapImage(new Uri(fileDialog.FileName));
                slikaTxt.Text = ikonica.Source.ToString();
            }
        }
    }
}
