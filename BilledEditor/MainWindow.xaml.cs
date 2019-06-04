using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace BilledEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<User> bTabel = new List<User>();
        public List<User> uTabel = new List<User>();
        Button b = null;
        string billedeSti = "";

        public MainWindow()
        {
            InitializeComponent();
            btn_load.Visibility = Visibility.Visible;
            btn_opret.Visibility = Visibility.Visible;
            btn_save.Visibility = Visibility.Visible;
            txt_nr.Visibility = Visibility.Hidden;
            btn_PlaceButton.Visibility = Visibility.Hidden;
            btn_tilbage.Visibility = Visibility.Hidden;
            btn_lock.Visibility = Visibility.Hidden;
            btn_annulere.Visibility = Visibility.Hidden;
        }

        private void btn_load_Click(object sender, RoutedEventArgs e)
        {           
            OpenFileDialog op = new OpenFileDialog();
            op.InitialDirectory = @"C:\Program Files (x86)\ZBC\Urmager Programmer\Instruktion\";
            op.Title = "Vælg et billed";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                        "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + 
                        "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imageviewer.Height = 747;
                imageviewer.Width = 547;
                imageviewer.Source = new BitmapImage(new Uri(op.FileName));
                
                billedeSti = op.FileName;
            }
        }

        private void btn_opret_Click(object sender, RoutedEventArgs e)
        {          
            txt_nr.Visibility = Visibility.Visible;
            btn_PlaceButton.Visibility = Visibility.Visible;
            btn_load.Visibility = Visibility.Hidden;
            btn_opret.Visibility = Visibility.Hidden;
            btn_save.Visibility = Visibility.Hidden;
            btn_tilbage.Visibility = Visibility.Visible;
            btn_hentXml.Visibility = Visibility.Hidden;
        }

        private Button OpretNyButton()
        {
            Button btn = new Button();
            btn.Height = 20;
            btn.Width = 20;
            btn.Content = "";
            btn.Opacity = 0.5;
            btn.Background = Brushes.Gold;          
            btn.ToolTip = txt_nr.Text;
            return btn;
        }            

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {            
            GemTilXml();           
        }            

        private void btn_lock_Click(object sender, RoutedEventArgs e)
        {
            btn_load.Visibility = Visibility.Hidden;
            btn_opret.Visibility = Visibility.Hidden;
            btn_save.Visibility = Visibility.Hidden;
            txt_nr.Visibility = Visibility.Visible;
            btn_PlaceButton.Visibility = Visibility.Visible;
            btn_tilbage.Visibility = Visibility.Visible;
            btn_lock.Visibility = Visibility.Hidden;
            btn_annulere.Visibility = Visibility.Hidden;
            btn_hentXml.Visibility = Visibility.Hidden;

            Point relativePoint = b.TransformToVisual(canvas).Transform(new Point(0, 0));            
            b.IsEnabled = false;

            User u = new User();
            u.X = relativePoint.X;
            u.Y = relativePoint.Y;
            u.TIP = b.ToolTip.ToString();
            u.STI = billedeSti;
            bTabel.Add(u);
            
        }

        private void btn_PlaceButton_Click(object sender, RoutedEventArgs e)
        {
            bool ok = DalManager.FindesNummer(txt_nr.Text);
            if (ok == true && txt_nr.Text.Length > 0)
            {
                btn_load.Visibility = Visibility.Hidden;
                btn_opret.Visibility = Visibility.Hidden;
                btn_save.Visibility = Visibility.Hidden;
                txt_nr.Visibility = Visibility.Hidden;
                btn_PlaceButton.Visibility = Visibility.Hidden;
                btn_tilbage.Visibility = Visibility.Hidden;
                btn_lock.Visibility = Visibility.Visible;
                btn_annulere.Visibility = Visibility.Visible;
                btn_hentXml.Visibility = Visibility.Hidden;
                DragCanvas dc = new DragCanvas();
                b = OpretNyButton();
                dc.Children.Add(b);
                ImageRamme.Children.Add(dc);

                txt_nr.Text = "";
            }
            else
            {
                MessageBox.Show("ArtikkelNr " + txt_nr.Text + " findes ikke i Databasen");
                txt_nr.Text = "";
            }
        }

        private void btn_tilbage_Click(object sender, RoutedEventArgs e)
        {
            // til start menu
            btn_load.Visibility = Visibility.Visible;
            btn_opret.Visibility = Visibility.Visible;
            btn_save.Visibility = Visibility.Visible;
            btn_hentXml.Visibility = Visibility.Visible;
            txt_nr.Visibility = Visibility.Hidden;
            btn_PlaceButton.Visibility = Visibility.Hidden;
            btn_tilbage.Visibility = Visibility.Hidden;
            btn_lock.Visibility = Visibility.Hidden;
            btn_annulere.Visibility = Visibility.Hidden;
        }

        private void btn_annulere_Click(object sender, RoutedEventArgs e)
        {
            // annulere opret mærke
            btn_load.Visibility = Visibility.Hidden;
            btn_opret.Visibility = Visibility.Hidden;
            btn_save.Visibility = Visibility.Hidden;
            btn_hentXml.Visibility = Visibility.Hidden;
            txt_nr.Visibility = Visibility.Visible;
            btn_PlaceButton.Visibility = Visibility.Visible;
            btn_tilbage.Visibility = Visibility.Visible;
            btn_lock.Visibility = Visibility.Hidden;
            btn_annulere.Visibility = Visibility.Hidden;
        }

        public void GemTilXml()
        {            
            string filename = "";
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.InitialDirectory = @"C:\Program Files (x86)\ZBC\Urmager Programmer\Instruktion\";
            dlg.DefaultExt = ".xml"; 
            dlg.Filter = "xml fil (*.xml)|*.xml"; 
          
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                filename = dlg.FileName;


                using (var writer = new FileStream(filename, FileMode.Create))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(List<User>), new XmlRootAttribute("user_list"));
                    List<User> list = new List<User>();

                    foreach (User data in bTabel)
                    {
                        list.Add(new User { X = data.X, Y = data.Y, TIP = data.TIP, STI = billedeSti });
                    }
                    ser.Serialize(writer, list);
                }
            }           
        }

        

        private void btn_hentXml_Click(object sender, RoutedEventArgs e)
        {           
            HentXmlData();
        }

        public void HentXmlData()
        {
            string sti = "";
            canvas.Children.Clear();
            ImageRamme.Children.Clear();
            imageviewer.Source = null;
            canvas.Children.Add(ImageRamme);
            ImageRamme.Children.Add(imageviewer);
            OpenFileDialog op = new OpenFileDialog();
            op.InitialDirectory = @"C:\Program Files (x86)\ZBC\Urmager Programmer\Instruktion\";
            op.Title = "Vælg xml fil";
            op.Filter = "xml file (*.xml)|*.xml";
            if (op.ShowDialog() == true)
            {
                sti = op.FileName;

                imageviewer.Source = null;
                imageviewer.Height = 747;
                imageviewer.Width = 547;

                List<User> users;
                using (var reader = new StreamReader(sti))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(List<User>), new XmlRootAttribute("user_list"));
                    users = (List<User>)deserializer.Deserialize(reader);
                }

                string stiTilBillede = users[0].STI;
                imageviewer.Source = new BitmapImage(new Uri(stiTilBillede));

                bTabel.Clear();
                User uu = null;
                foreach (User u in users)
                {
                    b = new Button();
                    b.Margin = new Thickness(u.X, u.Y, 0, 0);
                    b.Height = 20;
                    b.Width = 20;
                    b.Content = "";
                    b.Opacity = 0.5;
                    b.Background = Brushes.Gold;
                    b.ToolTip = u.TIP;
                    canvas.Children.Add(b);
                    uu = new User();
                    uu.X = u.X;
                    uu.Y = u.Y;
                    uu.TIP = u.TIP;
                    uu.STI = u.STI;
                    billedeSti = u.STI;
                    bTabel.Add(uu);
                }
            }
        }
    }
}
