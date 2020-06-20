using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;
using ProjekatHCI.Unos;
using System.Collections.ObjectModel;

namespace ProjekatHCI.Logovanje

{
    [Serializable()]

    public class Korisnik
    {

        public static ObservableCollection<Manifestacija> manifestacije;

        private ObservableCollection<string> manifestacijeStr;
        public ObservableCollection<string> ManifestacijeStr
        {
            get
            {
                return manifestacijeStr;
            }

            set
            {
                if (value != manifestacijeStr)
                {
                    manifestacijeStr = value;
                    OnPropertyChanged("ManifestacijeStr");
                }
            }
        }

        public static ObservableCollection<TipKomponenta> tipovi
        {
            get;
            set;
        }

        private ObservableCollection<string> tipoviStr;
        public ObservableCollection<string> TipoviStr
        {
            get
            {
                return tipoviStr;
            }

            set
            {
                if (value != tipoviStr)
                {
                    tipoviStr = value;
                    OnPropertyChanged("TipoviStr");
                }
            }
        }


        public static ObservableCollection<Etiketa> etikete
        {
            get;
            set;
        }

        private ObservableCollection<string> etiketeStr;
        public ObservableCollection<string> EtiketeStr
        {
            get
            {
                return etiketeStr;
            }

            set
            {
                if (value != etiketeStr)
                {
                    etiketeStr = value;
                    OnPropertyChanged("EtiketeStr");
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Korisnik()
        {

        }

        public Korisnik(SerializationInfo info, StreamingContext ctxt)
        {
            korisnickoIme = (string)info.GetValue("korisnickoIme", typeof(string));
            sifra = (string)info.GetValue("sifra", typeof(string));
            email = (string)info.GetValue("email", typeof(string));
            manifestacijeStr = (ObservableCollection<string>)info.GetValue("manifestacijeStr", typeof(ObservableCollection<string>));
            tipoviStr = (ObservableCollection<string>)info.GetValue("tipoviStr", typeof(ObservableCollection<string>));
            etiketeStr = (ObservableCollection<string>)info.GetValue("etiketeStr", typeof(ObservableCollection<string>));

            foreach(string m in manifestacijeStr)
            {
                manifestacije.Add(MainWindow.PretragaPoNazivu(m));
            }
            Console.WriteLine(manifestacije.ElementAt(0).ImeManifestacije);
        }

        public Korisnik(string i, string s, string e) //konstruktor sa registracije
        {
            korisnickoIme = i;
            sifra = s;
            email = e;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("korisnickoIme", korisnickoIme);
            info.AddValue("sifra", sifra);
            info.AddValue("email", email);
            info.AddValue("manifestacijeStr", manifestacijeStr);
            info.AddValue("tipoviStr", tipoviStr);
            info.AddValue("etiketeStr", etiketeStr);
        }


        private string korisnickoIme;
        public string KorisnickoIme
        {
            get
            {
                return korisnickoIme;
            }

            set
            {
                if (value != korisnickoIme)
                {
                    korisnickoIme = value;
                    OnPropertyChanged("KorisnickoIme");
                }
            }
        }

        private string sifra;
        public string Sifra
        {
            get
            {
                return sifra;
            }

            set
            {
                if (value != sifra)
                {
                    sifra = value;
                    OnPropertyChanged("Sifra");
                }
            }
        }

        private string email;
        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                if (value != email)
                {
                    email = value;
                    OnPropertyChanged("Email");
                }
            }
        }



    }
}
