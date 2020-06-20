using ProjekatHCI.Logovanje;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Xml.Serialization;

namespace ProjekatHCI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public static ObservableCollection<Korisnik> korisnici;


        public Login()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            ucitajPodatke();
        }

        private void ucitajPodatke()
        {
            korisnici = new ObservableCollection<Korisnik>();

            XmlSerializer deserializerM = new XmlSerializer(typeof(ObservableCollection<Korisnik>));

            FileStream fsM1 = File.Open(@"D:\HCI\ProjekatHCI\ProjekatHCI\Korisnici.xml", FileMode.Append);

            fsM1.Close();

            using (FileStream fsM = File.OpenRead(@"D:\HCI\ProjekatHCI\ProjekatHCI\Korisnici.xml"))
            {
                if (fsM.Length != 0)
                    korisnici = (ObservableCollection<Korisnik>)deserializerM.Deserialize(fsM);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        

        private void OdustaniBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LogovanjeClick(object sender, RoutedEventArgs e)
        {
            bool uspjesno = false;
            Korisnik trenutni = null;
            foreach(Korisnik k in korisnici)
            {
                if (korisnickoImeTxt.Text.Equals(k.KorisnickoIme) && sifraTxt.Password.Equals(k.Sifra))
                {
                    trenutni = k;
                    uspjesno = true;
                    break;
                }

            }
            if (uspjesno)
            {
                MainWindow m = new MainWindow(trenutni);
                m.Show();
                this.Close();
            } else
            {
                System.Windows.MessageBox.Show("Korisničko ime ili šifra nisu tačni.", "Neuspjesno!");

            }

        }

        private void RegistracijaBtn_Click(object sender, RoutedEventArgs e)
        {
            Registracija r = new Registracija();
            r.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            using (Stream fs = new FileStream(@"D:\HCI\ProjekatHCI\ProjekatHCI\Korisnici.xml", FileMode.Create, FileAccess.Write,
                FileShare.None))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Korisnik>));
                serializer.Serialize(fs, korisnici);
            }
            korisnici = null;
        }
    }
}
