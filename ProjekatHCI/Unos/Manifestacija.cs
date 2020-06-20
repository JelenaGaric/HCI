using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using ProjekatHCI.Unos;

namespace ProjekatHCI.Unos
{
    [Serializable()]

    public class Manifestacija: INotifyPropertyChanged, ISerializable
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("oznakaManifestacije", oznakaManifestacije);
            info.AddValue("imeManifestacije", imeManifestacije);
            info.AddValue("opisManifestacije", opisManifestacije);
            info.AddValue("kategorijeCijena", kategorijeCijena);
            info.AddValue("tipString", tipManifestacijeStr);
            info.AddValue("statusSluzenjaAlkohola", statusSluzenjaAlkohola);
            info.AddValue("tipString", tipManifestacijeStr);
            info.AddValue("slika", slika);
            info.AddValue("ocekivanaPublika", ocekivanaPublika);
            info.AddValue("datumOdrzavanja", datumOdrzavanja);
            info.AddValue("napoljuIliUnutra", napoljuIliUnutra);
            info.AddValue("etiketa", etiketa.NazivEtikete);
            info.AddValue("etiketaStr", etiketaStr);
            info.AddValue("indeksNaMapi", indeksNaMapi);

        }

        public Manifestacija(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the properties
            oznakaManifestacije = (string)info.GetValue("oznakaManifestacije", typeof(string));
            imeManifestacije = (string)info.GetValue("imeManifestacije", typeof(string));
            opisManifestacije = (string)info.GetValue("opisManifestacije", typeof(string));
            kategorijeCijena = (int)info.GetValue("kategorijeCijena", typeof(int));
            statusSluzenjaAlkohola = (int)info.GetValue("statusSluzenjaAlkohola", typeof(int));
            tipManifestacijeStr = (string)info.GetValue("tipString", typeof(string));
            ocekivanaPublika = (string)info.GetValue("ocekivanaPublika", typeof(string));
            napoljuIliUnutra = (int)info.GetValue("napoljuIliUnutra", typeof(int));
            datumOdrzavanja = (string)info.GetValue("datumOdrzavanja", typeof(string));
            etiketaStr = (string)info.GetValue("etiketaStr", typeof(string));
            indeksNaMapi = (int)info.GetValue("indeksNaMapi", typeof(int));
            foreach (Etiketa e in MainWindow.Lista4)
            {
                if (e.NazivEtikete == etiketaStr)
                    etiketa = e;
            }
            foreach (TipKomponenta t in MainWindow.Lista1)
            {
                if (t.Naziv_Tipa == tipManifestacijeStr)
                    this.tipManifestacije = t;
            }

        }

        public Manifestacija() { }

        private string oznakaManifestacije;

        public string OznakaManifestacije
        {
            get
            {
                return oznakaManifestacije;
            }

            set
            {

                if (value != oznakaManifestacije)
                {
                    oznakaManifestacije = value;
                    OnPropertyChanged("OznakaManifestacije");
                }

            }
        }

        private string tipManifestacijeStr;

        public string TipManifestacijeStr
        {
            get
            {
                return tipManifestacijeStr;
            }

            set
            {

                if (value != tipManifestacijeStr)
                {
                    tipManifestacijeStr = value;
                    OnPropertyChanged("TipManifestacijeStr");
                }

            }
        }

        private string etiketaStr;
        public string EtiketaStr
        {
            get
            {
                return etiketaStr;
            }

            set
            {
                if (value != etiketaStr)
                {
                    etiketaStr = value;
                    OnPropertyChanged("EtiketaStr");
                }
            }
        }

        private string imeManifestacije;

        public string ImeManifestacije
        {
            get
            {
                return imeManifestacije;
            }

            set
            {
                if (value != imeManifestacije)
                {
                    imeManifestacije = value;
                    OnPropertyChanged("ImeManifestacije");
                }
            }
        }

        private string opisManifestacije;

        public string OpisManifestacije
        {
            get
            {
                return opisManifestacije;
            }

            set
            {
                if (value != opisManifestacije)
                {
                    opisManifestacije = value;
                    OnPropertyChanged("OpisManifestacije");
                }
            }
        }

        private int statusSluzenjaAlkohola;

        public int StatusSluzenjaAlkohola
        {
            get
            {
                return statusSluzenjaAlkohola;
            }

            set
            {
                if (value != statusSluzenjaAlkohola)
                {
                    statusSluzenjaAlkohola = value;
                    OnPropertyChanged("StatusSluzenjaAlkohola");
                }
            }
        }

        private int kategorijeCijena;

        public int KategorijeCijena
        {
            get
            {
                return kategorijeCijena;
            }

            set
            {
                if (value != kategorijeCijena)
                {
                    kategorijeCijena = value;
                    OnPropertyChanged("KategorijeCijena");
                }
            }
        }

        private string slika = "";
        public String Slika
        {
            get
            {
                return slika;
            }
            set
            {
                if (value != slika)
                    slika = value;
                OnPropertyChanged("Slika");
            }
        }

        private bool dostupnaZaHendikepirane;

        public bool DostupnaZaHendikepirane
        {
            get
            {
                return dostupnaZaHendikepirane;
            }

            set
            {
                if (value != dostupnaZaHendikepirane)
                {
                    dostupnaZaHendikepirane = value;
                    OnPropertyChanged("DostupnaZaHendikepirane");
                }
            }
        }

        private bool dozvoljenoPusenje;

        public bool DozvoljenoPusenje
        {
            get
            {
                return dozvoljenoPusenje;
            }

            set
            {
                if (value != dozvoljenoPusenje)
                {
                    dozvoljenoPusenje = value;
                    OnPropertyChanged("DozvoljenoPusenje");
                }
            }
        }

        private string ocekivanaPublika;

        public string OcekivanaPublika
        {
            get
            {
                return ocekivanaPublika;
            }

            set
            {
                if (value != ocekivanaPublika)
                {
                    ocekivanaPublika = value;
                    OnPropertyChanged("OcekivanaPublika");
                }
            }
        }

        private string datumOdrzavanja;

        public string DatumOdrzavanja
        {
            get
            {
                return datumOdrzavanja;
            }

            set
            {
                if (value != datumOdrzavanja)
                {
                    datumOdrzavanja = value;
                    OnPropertyChanged("DatumOdrzavanja");
                }
            }
        }
        private int napoljuIliUnutra;

        public int NapoljuIliUnutra
        {
            get
            {
                return napoljuIliUnutra;
            }

            set
            {
                if (value != napoljuIliUnutra)
                {
                    napoljuIliUnutra = value;
                    OnPropertyChanged("NapoljuIliUnutra");
                }
            }
        }

        private int indeksNaMapi = 0;

        public int IndeksNaMapi
        {
            get
            {
                return indeksNaMapi;
            }

            set
            {
                if (value != indeksNaMapi)
                {
                    indeksNaMapi = value;
                    OnPropertyChanged("IndeksNaMapi");
                }
            }
        }

        private Unos.TipKomponenta tipManifestacije;
        public Unos.TipKomponenta TipManifestacije
        {
            get
            {
                return tipManifestacije;
            }

            set
            {
                if (value != tipManifestacije)
                {
                    tipManifestacije = value;
                    OnPropertyChanged("TipManifestacije");
                }
            }
        }



        private Unos.Etiketa etiketa;
        public Unos.Etiketa Etiketa
        {
            get
            {
                return etiketa;
            }

            set
            {
                if (value != etiketa)
                {
                    etiketa = value;
                    OnPropertyChanged("Etiketa");
                }
            }
        }

        private double x = -1;
        private double y = -1;


        public double X
        {
            get
            {
                return x;
            }
            set
            {
                if (value != x)
                    x = value;
                OnPropertyChanged("X");
            }
        }

        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                if (value != y)
                    y = value;
                OnPropertyChanged("Y");
            }
        }
    }
}
