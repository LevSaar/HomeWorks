using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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

namespace ControlW
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string data = GetHTML();
            List<string> links = GetLinks(data);

            this.Background = new ImageBrush(new BitmapImage(new Uri(links[0].ToString())));
            this.Icon = new BitmapImage(new Uri(links[1].ToString()));

            Timer timer = new Timer(RefreshData, links[0].ToString(), 0, 15000);
        }

        public string GetHTML()
        {
            string mainUrl = "https://www.google.com/search?q=background&tbm=isch";
            string result = "";

            var request = (HttpWebRequest)WebRequest.Create(mainUrl);
            var response = (HttpWebResponse)request.GetResponse();

            using (Stream dataStream = response.GetResponseStream())
            {
                if (dataStream == null)
                {
                    MessageBox.Show("Data stream exception !");
                }
                using (var sr = new StreamReader(dataStream))
                {
                    result = sr.ReadToEnd();
                }
            }
            return result;
        }

        private List<string> GetLinks(string _html)
        {
            var links = new List<string>();
            int index = _html.IndexOf("class=\"images_table\"", StringComparison.Ordinal);
            index = _html.IndexOf("<img", index, StringComparison.Ordinal);

            while (index >= 0)
            {
                index = _html.IndexOf("src=\"", index, StringComparison.Ordinal);
                index = index + 5;
                int secondIndex = _html.IndexOf("\"", index, StringComparison.Ordinal);
                string url = _html.Substring(index, secondIndex - index);
                links.Add(url);
                index = _html.IndexOf("<img", index, StringComparison.Ordinal);
            }

            return links;
        }

        private void RefreshData(object oldBgUrl)
        {
            string _background = (string)oldBgUrl;

            string _data = GetHTML();
            List<string> _links = GetLinks(_data);

            if (_background != _links[0].ToString())
            {
                /* Не работает DialogResult
                 * 
                DialogResult dialogResult = MessageBox.Show("New updates available.", "Would you like to update the application?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Background = new ImageBrush(new BitmapImage(new Uri(_links[0].ToString())));
                    this.Icon = new BitmapImage(new Uri(_links[1].ToString()));
                }
                else return;
                */

                MessageBox.Show("New updates available.", "Would you like to update the application?", MessageBoxButton.YesNo);
                this.Background = new ImageBrush(new BitmapImage(new Uri(_links[0].ToString())));
                this.Icon = new BitmapImage(new Uri(_links[1].ToString()));
            }
        }
    }
}
