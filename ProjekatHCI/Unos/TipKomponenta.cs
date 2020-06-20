using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ProjekatHCI.Unos
{
    [Serializable()]

    public class TipKomponenta: INotifyPropertyChanged, ISerializable
    {
        public TipKomponenta() { }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public TipKomponenta(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the properties
            oznakaTipa = (string)info.GetValue("oznakaTipa", typeof(string));
            naziv_Tipa = (string)info.GetValue("naziv_Tipa", typeof(string));
            opisTipa = (string)info.GetValue("opisTipa", typeof(string));
            slikaTipa = (string)info.GetValue("slikaTipa", typeof(string));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("naziv_Tipa", naziv_Tipa);
            info.AddValue("opisTipa", opisTipa);
            info.AddValue("oznakaTipa", oznakaTipa);
            info.AddValue("slikaTipa", oznakaTipa);
        }


        private string naziv_Tipa;
        public string Naziv_Tipa
        {
            get
            {
                return naziv_Tipa;
            }

            set
            {
                if (value != naziv_Tipa)
                {
                    naziv_Tipa = value;
                    OnPropertyChanged("Naziv_Tipa");
                }
            }
        }

        private string oznakaTipa;
        public string OznakaTipa
        {
            get
            {
                return oznakaTipa;
            }

            set
            {
                if (value != oznakaTipa)
                {
                    oznakaTipa = value;
                    OnPropertyChanged("OznakaTipa");
                }
            }
        }


        private string opisTipa;
        public string OpisTipa
        {
            get
            {
                return opisTipa;
            }

            set
            {
                if (value != opisTipa)
                {
                    opisTipa = value;
                    OnPropertyChanged("OpisTipa");
                }
            }
        }

        private string slikaTipa = ""; 
        public string SlikaTipa
        {
            get
            {
                return slikaTipa;
            }

            set
            {
                if (value != slikaTipa)
                {
                    slikaTipa = value;
                    OnPropertyChanged("SlikaTipa");
                }
            }
        }


    }
}
