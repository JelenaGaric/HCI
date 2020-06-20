using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ProjekatHCI.Unos
{
    [Serializable()]

    public class Etiketa: INotifyPropertyChanged, ISerializable
    {

        public Etiketa() { }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public Etiketa(SerializationInfo info, StreamingContext ctxt)
        {
            nazivEtikete = (string)info.GetValue("nazivEtikete", typeof(string));
            opisEtikete = (string)info.GetValue("opisEtikete", typeof(string));
            boja = (Color)info.GetValue("boja", typeof(Color));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("nazivEtikete", nazivEtikete);
            info.AddValue("opisEtikete", opisEtikete);
            info.AddValue("boja", boja);
        }

        private string nazivEtikete;
        public string NazivEtikete
        {
            get
            {
                return nazivEtikete;
            }

            set
            {
                if (value != nazivEtikete)
                {
                    nazivEtikete = value;
                    OnPropertyChanged("NazivEtikete");
                }
            }
        }
        private string opisEtikete;
        public string OpisEtikete
        {
            get
            {
                return opisEtikete;
            }

            set
            {
                if (value != opisEtikete)
                {
                    opisEtikete = value;
                    OnPropertyChanged("OpisEtikete");
                }
            }
        }


        private Color boja;
            public Color Boja
            {
                get
                {
                    return boja;
                }

                set
                {
                    if (value != boja)
                    {
                        boja = value;
                        OnPropertyChanged("Boja");
                    }
                }
            }

    }
}
