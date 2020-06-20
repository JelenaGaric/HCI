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
using System.Xml.Serialization;

namespace ProjekatHCI.Logovanje
{
    /// <summary>
    /// Interaction logic for Registracija.xaml
    /// </summary>
    public partial class Registracija : Window
    {
        public Registracija()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void RegistrujSeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!potvrdaSifreTxt.Text.Equals(sifraTxt.Text))
            {
                System.Windows.MessageBox.Show("Potvrda sifre nije uspjela.", "Neuspjesno!");
            }
            Login.korisnici.Add(new Korisnik(this.korisnickoImeTxt.Text, this.sifraTxt.Text, this.emailTxt.Text));
            System.Windows.MessageBox.Show("Registracija uspjela.", "Uspjesno!");
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
