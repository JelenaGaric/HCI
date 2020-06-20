using ProjekatHCI.Unos;
using ProjekatHCI.Prikaz;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
// Used for writing to a file
using System.IO;

// Used to serialize an object to binary format
using System.Runtime.Serialization.Formatters.Binary;

// Used to serialize into XML
using System.Xml.Serialization;
using ProjekatHCI.Logovanje;

namespace ProjekatHCI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<Manifestacija> manifestacije;


        public static ObservableCollection<TipKomponenta> Lista1
        {
            get;
            set;
        }

        public static ObservableCollection<Etiketa> Lista4
        {
            get;
            set;
        }

        public MainWindow(Korisnik k)
        {
                InitializeComponent();
                ucitajPodatke(k);
                listViewManifestacije.ItemsSource = manifestacije;
                listViewManifestacije.SelectionMode = SelectionMode.Single;

            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        public static Manifestacija PretragaPoNazivu(string naziv)
        {
            Manifestacija retVal = null;
            foreach(Manifestacija m in manifestacije)
            {
                if (m.ImeManifestacije.Equals(naziv))
                    retVal = m;
            }
            return retVal;
        }

        private void ucitajPodatke(Korisnik k)
        {
            manifestacije = new ObservableCollection<Manifestacija>();

            XmlSerializer deserializerM = new XmlSerializer(typeof(ObservableCollection<Manifestacija>));

            FileStream fsM1 = File.Open(@"D:\HCI\ProjekatHCI\ProjekatHCI\Manifestacije.xml", FileMode.Append);

            fsM1.Close();


            using (FileStream fsM = File.OpenRead(@"D:\HCI\ProjekatHCI\ProjekatHCI\Manifestacije.xml"))
            {
                if (fsM.Length != 0)
                    manifestacije = (ObservableCollection<Manifestacija>)deserializerM.Deserialize(fsM);
            }
            foreach(Manifestacija m in manifestacije)
            {
                m.IndeksNaMapi = 0;
            }

            Lista1 = new ObservableCollection<TipKomponenta>();
        
            XmlSerializer deserializerT = new XmlSerializer(typeof(ObservableCollection<TipKomponenta>));


            FileStream fsT1 = File.Open(@"D:\HCI\ProjekatHCI\ProjekatHCI\Tipovi.xml", FileMode.Append);

            fsT1.Close();


            using (FileStream fsT = File.OpenRead(@"D:\HCI\ProjekatHCI\ProjekatHCI\Tipovi.xml"))
            {
                if (fsT.Length != 0)
                    Lista1 = (ObservableCollection<TipKomponenta>)deserializerT.Deserialize(fsT);
            }

            /*foreach(TipKomponenta t in Lista1)
            {
                if (!t.Naziv_Tipa.Equals("Kultura/Zabava"))
                {
                    Lista1.Add(new TipKomponenta() { Naziv_Tipa = "Kultura/Zabava", OznakaTipa = "1", OpisTipa = "Generican tip" });
                }
                if (!t.Naziv_Tipa.Equals("Nauka/Edukacija"))
                {
                    Lista1.Add(new TipKomponenta() { Naziv_Tipa = "Nauka/Edukacija", OznakaTipa = "2", OpisTipa = "Generican tip" });
                }
                if (!t.Naziv_Tipa.Equals("Politika/Ekonomija"))
                {
                    Lista1.Add(new TipKomponenta() { Naziv_Tipa = "Politika/Ekonomija", OznakaTipa = "3", OpisTipa = "Generican tip" });
                }
                if (!t.Naziv_Tipa.Equals("Ostalo"))
                {
                    Lista1.Add(new TipKomponenta() { Naziv_Tipa = "Ostalo", OznakaTipa = "4", OpisTipa = "Generican tip" });
                }
 
            }*/

            Lista4 = new ObservableCollection<Etiketa>();
            Lista4.Add(new Etiketa() { NazivEtikete = "Genericna etiketa...", OpisEtikete = "default vrijednost za etiketiranje", Boja = Colors.ForestGreen });

            XmlSerializer deserializerE = new XmlSerializer(typeof(ObservableCollection<Etiketa>));

            FileStream fsE1 = File.Open(@"D:\HCI\ProjekatHCI\ProjekatHCI\Etikete.xml", FileMode.Append);

            fsE1.Close();


            using (FileStream fsE = File.OpenRead(@"D:\HCI\ProjekatHCI\ProjekatHCI\Etikete.xml"))
            {
                if (fsE.Length != 0)
                    Lista4 = (ObservableCollection<Etiketa>)deserializerE.Deserialize(fsE);
            }
            
            
            foreach(Manifestacija m in manifestacije)
            {
                if(m.X!=-1 && m.Y != -1) {

                    Image img = new Image();

                    if (!m.Slika.Equals(""))
                    {
                        img.Source = new BitmapImage(new Uri(m.Slika));

                    }
                    else if (!m.TipManifestacije.SlikaTipa.Equals(""))
                    {

                        img.Source = new BitmapImage(new Uri(m.TipManifestacije.SlikaTipa));

                    }
                    else
                    {
                        img.Source = new BitmapImage(new Uri("file:///D:/HCI/ProjekatHCI/ProjekatHCI/defaultLokacija.png"));
                    }

                    img.Width = 30;
                    img.Height = 30;
                    img.Tag = m.OznakaManifestacije;
                    
                    WrapPanel wp = new WrapPanel();
                    wp.Orientation = Orientation.Vertical;


                    TextBox oznaka = new TextBox();
                    oznaka.IsEnabled = false;
                    oznaka.Text = "Oznaka: " + m.OznakaManifestacije;
                    wp.Children.Add(oznaka);

                    TextBox naziv = new TextBox();
                    naziv.IsEnabled = false;
                    naziv.Text = "Naziv: " + m.ImeManifestacije;
                    wp.Children.Add(naziv);


                    TextBox tip = new TextBox();
                    tip.IsEnabled = false;
                    tip.Text = "Tip: " + m.TipManifestacije.OznakaTipa;
                    wp.Children.Add(tip);


                    TextBox opis = new TextBox();
                    opis.IsEnabled = false;
                    opis.Text = "Opis: " + m.OpisManifestacije;
                    wp.Children.Add(opis);



                    TextBox etikete = new TextBox();
                    etikete.IsEnabled = false;
                    etikete.Text = "Etikete:" + System.Environment.NewLine;
                    Etiketa et = m.Etiketa;
                    etikete.Text = et.NazivEtikete;
                    wp.Children.Add(etikete);



                    ToolTip tt = new ToolTip();
                    tt.Content = wp;
                    img.ToolTip = tt;

                    img.MouseMove += ExistingImageMove;

                    canvasMap.Children.Add(img);

                    int idx = canvasMap.Children.Count;
                    m.IndeksNaMapi = idx;

                    Canvas.SetLeft(img, m.X - 20);
                    Canvas.SetTop(img, m.Y - 20);

                }
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            using (Stream fs = new FileStream(@"D:\HCI\ProjekatHCI\ProjekatHCI\Manifestacije.xml", FileMode.Create, FileAccess.Write,
                FileShare.None))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Manifestacija>));
                serializer.Serialize(fs, manifestacije);
            }
            manifestacije = null;

            using (Stream fsT = new FileStream(@"D:\HCI\ProjekatHCI\ProjekatHCI\Tipovi.xml", FileMode.Create, FileAccess.Write,
               FileShare.None))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<TipKomponenta>));
                serializer.Serialize(fsT, Lista1);
            }
            Lista1 = null;

            using (Stream fsE = new FileStream(@"D:\HCI\ProjekatHCI\ProjekatHCI\Etikete.xml", FileMode.Create, FileAccess.Write,
              FileShare.None))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Etiketa>));
                serializer.Serialize(fsE, Lista4);
            }
            Lista4 = null;

        }


        private void Otvori_Unos(object sender, RoutedEventArgs e)
        {
            Unos_Podataka s = new Unos_Podataka();
            s.Show();
        }

        private void Otvori_Listu_Manifestacija(object sender, RoutedEventArgs e)
        {
            PrikazManifestacija l = new PrikazManifestacija();
            l.Show();
        }

        private void IzlazBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EtiketaBtn_Click(object sender, RoutedEventArgs e)
        {
            Unos.UnosEtikete u = new Unos.UnosEtikete();
            u.Show();
        }

        private void UnosTipaBtn_Click(object sender, RoutedEventArgs e)
        {
            Tip t = new Tip();
            t.Show();
        }

        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public void doThings(string param)
        {
            this.izlazBtn.Background = new SolidColorBrush(Color.FromRgb(32, 64, 128));
            Title = param;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
            if (focusedControl is DependencyObject)
            {
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                HelpProvider.ShowHelp(str, this);
            }
        }

        Point startPoint = new Point();

        private void ListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void ListView_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                // Get the dragged ListViewItem
                ListView listView = sender as ListView;
                ListViewItem listViewItem =
                    FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);

                // Find the data behind the ListViewItem
                if(listView.SelectedItem == null)
                {
                    return;
                }

                Manifestacija m = (Manifestacija)listView.ItemContainerGenerator.
                    ItemFromContainer(listViewItem);

                // Initialize the drag & drop operation
                DataObject dragData = new DataObject("Manifestacija", m);
                DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);

            
            }
        }

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }


        private void CanvasMap_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("Manifestacija") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
            Manifestacija m = e.Data.GetData("Manifestacija") as Manifestacija;
           /* if (m.IndeksNaMapi != 0)
            {
                e.Effects = DragDropEffects.None;
                System.Windows.MessageBox.Show("Ikonica te manifestacije već se nalazi na mapi.", "Neuspješno!");
                
            }*/
        }


        public void ucitajSve()
        {
            foreach (Manifestacija m in manifestacije)
            {
                bool result = canvasMap.Children.Cast<Image>()
                           .Any(x => x.Tag != null && x.Tag.ToString() == m.OznakaManifestacije);

                if (result)
                    continue;

                if (m.X != -1 || m.Y != -1)
                {
                    Image img = new Image();
                    /* if (!m.Slika.Equals(""))
                         img.Source = new BitmapImage(new Uri(m.Slika));
                     else
                         img.Source = new BitmapImage(new Uri(m.Tip.Slika));*/


                    img.Width = 50;
                    img.Height = 50;
                    img.Tag = m.OznakaManifestacije;
                    WrapPanel wp = new WrapPanel();
                    wp.Orientation = Orientation.Vertical;

                    TextBox oznaka = new TextBox();
                    oznaka.IsEnabled = false;
                    oznaka.Text = "Oznaka: " + m.OznakaManifestacije;
                    wp.Children.Add(oznaka);

                    TextBox naziv = new TextBox();
                    naziv.IsEnabled = false;
                    naziv.Text = "Naziv: " + m.ImeManifestacije;
                    wp.Children.Add(naziv);


                    TextBox tip = new TextBox();
                    tip.IsEnabled = false;
                    tip.Text = "Tip: " + m.TipManifestacije.OznakaTipa;
                    wp.Children.Add(tip);


                    TextBox opis = new TextBox();
                    opis.IsEnabled = false;
                    opis.Text = "Opis: " + m.OpisManifestacije;
                    wp.Children.Add(opis);

                    
                    ToolTip tt = new ToolTip();
                    tt.Content = wp;
                    img.ToolTip = tt;
                   
                    canvasMap.Children.Add(img);
                    Image proba = (Image)canvasMap.Children[0];

                    Canvas.SetLeft(img, m.X - 20);
                    Canvas.SetTop(img, m.Y - 20);
                }
            }
        }
        private void CanvasMap_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("Manifestacija"))
            {
                Manifestacija m = e.Data.GetData("Manifestacija") as Manifestacija;

               
                System.Windows.Point d0 = e.GetPosition(canvasMap);
                {

                    Image img = new Image();

                    if (!m.Slika.Equals(""))
                    {
                        img.Source = new BitmapImage(new Uri(m.Slika));

                    }
                    else if(!m.TipManifestacije.SlikaTipa.Equals(""))
                    {
                       
                          img.Source = new BitmapImage(new Uri(m.TipManifestacije.SlikaTipa));

                    } else
                    {
                        img.Source = new BitmapImage(new Uri("file:///D:/HCI/ProjekatHCI/ProjekatHCI/defaultLokacija.png"));
                    }

                        img.Width = 30;
                        img.Height = 30;
                        img.Tag = m.OznakaManifestacije;
                        var positionX = e.GetPosition(canvasMap).X;
                        var positionY = e.GetPosition(canvasMap).Y;

                        m.X = positionX;
                        m.Y = positionY;

                        WrapPanel wp = new WrapPanel();
                        wp.Orientation = Orientation.Vertical;

                       // img.PreviewMouseLeftButtonDown += DraggedImagePreviewMouseLeftButtonDown;
                        //img.MouseMove += DraggedImageMouseMove;

                    
                    TextBox oznaka = new TextBox();
                    oznaka.IsEnabled = false;
                    oznaka.Text = "Oznaka: " + m.OznakaManifestacije;
                    wp.Children.Add(oznaka);

                    TextBox naziv = new TextBox();
                    naziv.IsEnabled = false;
                    naziv.Text = "Naziv: " + m.ImeManifestacije;
                    wp.Children.Add(naziv);


                    TextBox tip = new TextBox();
                    tip.IsEnabled = false;
                    tip.Text = "Tip: " + m.TipManifestacije.OznakaTipa;
                    wp.Children.Add(tip);


                    TextBox opis = new TextBox();
                    opis.IsEnabled = false;
                    opis.Text = "Opis: " + m.OpisManifestacije;
                    wp.Children.Add(opis);

                    
                    
                    TextBox etikete = new TextBox();
                    etikete.IsEnabled = false;
                    etikete.Text = "Etikete:" + System.Environment.NewLine;
                   Etiketa et = m.Etiketa;
                    etikete.Text = et.NazivEtikete;
                    wp.Children.Add(etikete);

                  

                    ToolTip tt = new ToolTip();
                    tt.Content = wp;
                    img.ToolTip = tt;
                                
                    img.MouseMove += ExistingImageMove;

                    canvasMap.Children.Add(img);

                    int idx = canvasMap.Children.Count;
                    m.IndeksNaMapi = idx;

                    Canvas.SetLeft(img, positionX - 20);
                    Canvas.SetTop(img, positionY - 20);

                }
                

            }
          
        }

        

        private void ExistingImageMove(object sender, MouseEventArgs e)
        {
            System.Windows.Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;
            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                 Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                Image img = sender as Image;
                var oznaka = img.Tag as string;
                var lok = findManifestacijaById(oznaka);
                canvasMap.Children.Remove(img);
                DataObject dragData = new DataObject("Manifestacija", lok);
                DragDrop.DoDragDrop(img, dragData, DragDropEffects.Move);
            }
        }

        public Manifestacija findManifestacijaById(string uid)
        {
            foreach (var m in manifestacije)
            {
                if (m.OznakaManifestacije == uid)
                {
                    return m;
                }
            }

            return null;
        }

        private void ObrisiBtn_Click(object sender, RoutedEventArgs e)
        {
            Manifestacija m = (Manifestacija)listViewManifestacije.SelectedItem;
            /* Image selektovana = new Image();

             foreach (Image img in canvasMap.Children)
             {
                 if (m.OznakaManifestacije.Equals(img.Tag))
                 {
                     selektovana = img;
                 }
             }*/


            Image selektovana = null;
            foreach (var img in canvasMap.Children)
            {
                foreach(Manifestacija manif in manifestacije){
                    /*if (manif.OznakaManifestacije.Equals(img.Tag))
                    {
                        selektovana = img;
                        break;
                    } */
                }
               
            }
            canvasMap.Children.Remove(selektovana);
           // manifestacije.Remove(m);
          
                   

        }

        /*
        private void DraggedImagePreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            startPoint = e.GetPosition(null);
            Image img = sender as Image;

            foreach (Manifestacija man in manifestacije)
            {
                if (man.OznakaManifestacije.Equals(img.Tag))
                {
                    listViewManifestacije.SelectedValue = man;
                   
                }
            }
            if (e.LeftButton == MouseButtonState.Released)
                e.Handled = true;

        }

        private void DraggedImageMouseMove(object sender, MouseEventArgs e)
        {
            System.Windows.Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;
            if (e.LeftButton == MouseButtonState.Pressed &&
               (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
               Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {


                Manifestacija selektovana = (Manifestacija)listViewManifestacije.SelectedValue;

                if (selektovana != null)
                {
                    Image img = sender as Image;
                    canvasMap.Children.Remove(img);
                    DataObject dragData = new DataObject("manifestacija", selektovana);
                    DragDrop.DoDragDrop(img, dragData, DragDropEffects.Move);

                }

            }

        }*/

    }


}
