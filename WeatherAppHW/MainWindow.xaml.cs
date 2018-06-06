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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace WeatherAppHW
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            mainPage.Children.Clear();

            var xml = await GetXml(citySearchBox.Text);

            if (xml != null)
            {
                foreach (var result in xml.Forecast.ForecastDay)
                {
                    mainPage.Children.Add(new WeatherControl(result));
                }
            }
        }
        public Task<Root> GetXml(string city)
        {
            return Task.Run(() =>
            {
                try
                {
                    string data;

                    using (var webClient = new WebClient())
                    {
                        webClient.Encoding = Encoding.UTF8;
                        data = webClient.DownloadString("https://api.apixu.com/v1/forecast.xml?key=f5ea02745ad04b66805103401182805%20&q=" + city + "&days=7");

                        XmlSerializer formatter = new XmlSerializer(typeof(Root));

                        using (TextReader reader = new StringReader(data))
                        {
                            Root root = (Root)formatter.Deserialize(reader);
                            return root;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Error !\nThe city is not found.");
                    return null;
                }
            });
        }
    }
}
