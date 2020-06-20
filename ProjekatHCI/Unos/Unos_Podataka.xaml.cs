using Microsoft.Win32;
using ProjekatHCI.Help;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for Unos_Podataka.xaml
    /// </summary>
    public partial class Unos_Podataka : Window,INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
            if (focusedControl is DependencyObject)
            {
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                HelpProvider.ShowHelp(str, this);
            }
        }
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public static ObservableCollection<string> Lista2
        {
            get;
            set;
        }
        public static ObservableCollection<string> Lista3
        {
            get;
            set;
        }

        public static List<string> napoljuIliUnutra
        {
            get;
            set;
        }


        
        private string slika = "";
        public string Slika
        {
            get { return slika; }
            set
            {
                if (value != slika)
                {
                    slika = value;
                    OnPropertyChanged("Slika");
                }

            }
        }

        private string oznaka;
        public string Oznaka
        {
            get
            {
                return oznaka;
            }
            set
            {
                if (value != oznaka)
                {
                    oznaka = value;
                    OnPropertyChanged("Oznaka");
                }
            }
        }
        private string ime;
        public string Ime
        {
            get
            {
                return ime;
            }
            set
            {
                if (value != ime)
                {
                    ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }

        public Unos_Podataka()
        {
            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            cbx1.ItemsSource = MainWindow.Lista1;

            Lista2 = new ObservableCollection<string>();
            Lista2.Add("Nema alkohola");
            Lista2.Add("Alkohol se može kupiti na licu mjesta");
            Lista2.Add("Alkohol se može donijeti");
            cbx2.ItemsSource = Lista2;

            Lista3 = new ObservableCollection<string>();
            Lista3.Add("Besplatno");
            Lista3.Add("Niske cijene");
            Lista3.Add("Srednje cijene");
            Lista3.Add("Visoke cijene");
            cbx3.ItemsSource = Lista3;

           cbx4.ItemsSource = MainWindow.Lista4;

            napoljuIliUnutra = new List<string>();
            
            napoljuIliUnutra.Add("Napolju");
            napoljuIliUnutra.Add("Unutra");
            napoljuIliUnutraCbx.ItemsSource = napoljuIliUnutra;

        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();


            fileDialog.Title = "Odaberi ikonicu manifestacije...";
            fileDialog.Filter = "Images|*.jpg;*.jpeg;*.png|" +
                                "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                                "Portable Network Graphic (*.png)|*.png";
            if (fileDialog.ShowDialog() == true)
            {
                ikonica.Source = new BitmapImage(new Uri(fileDialog.FileName));
                Slika = ikonica.Source.ToString();
            }
        }

      
        private void Otvori_Tip(object sender, RoutedEventArgs e)
        {
            Prikaz.Tip s = new Prikaz.Tip();
            s.Show();
        }

        private void Otvori_Etiketu(object sender, RoutedEventArgs e)
        {
            UnosEtikete u = new UnosEtikete();
            u.Show();
        }

        private void OdustaniBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            if (imeTxt.Text == "" || oznakaTxt.Text == "" || cbx1.SelectedIndex == -1 || cbx4.SelectedIndex == -1)
            {
                System.Windows.MessageBox.Show("Obavezan unos oznake, tipa, etikete, naziva manifestacije.", "Neuspjesno!");
                return;
            }
           /* if (StringToDoubleValidationRule.flag == 1)
            {
                System.Windows.MessageBox.Show("Neispravan format podataka.", "Neuspjesno!");
                return;
            }*/

            TipKomponenta t = (TipKomponenta)cbx1.SelectedItem;
            string naz = t.Naziv_Tipa;
            if (t.SlikaTipa.Equals(""))
            {
                t.SlikaTipa = "file:///D:/HCI/ProjekatHCI/ProjekatHCI/defaultLokacija.png";
            }
           
           
            MainWindow.manifestacije.Add(new Manifestacija() { OznakaManifestacije = Oznaka, TipManifestacijeStr=naz,
                ImeManifestacije = imeTxt.Text, TipManifestacije = (Unos.TipKomponenta)cbx1.SelectedItem,
                DatumOdrzavanja = datePicker.Text, Slika = slika, DostupnaZaHendikepirane = (bool)dostupnost.IsChecked,
                DozvoljenoPusenje = (bool)pusenje.IsChecked, KategorijeCijena = cbx3.SelectedIndex,
                OcekivanaPublika = ocekivana.Text, Etiketa = (Unos.Etiketa)cbx4.SelectedItem, OpisManifestacije = opisTxt.Text,
                StatusSluzenjaAlkohola = cbx2.SelectedIndex, NapoljuIliUnutra = napoljuIliUnutraCbx.SelectedIndex,
                EtiketaStr = ((Etiketa)cbx4.SelectedItem).NazivEtikete
            });

            System.Windows.MessageBox.Show("Uspješno unešena manifestacija.", "Uspješno!");
            this.Close();
        }

    }
}
