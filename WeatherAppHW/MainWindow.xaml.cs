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

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            WeatherData weatherData = new WeatherData(citySearchBox.Text);
            mainPage.Items.Add(weatherData.Temp);
            //listView.Items.Add("Текст").Index;
        }
    }

    public class WeatherData
    {
        private string city;
        private float temp;
        private float tempMax;
        private float tempMin;

        public string City { get => city; set => city = value; }
        public float Temp { get => temp; set => temp = value; }
        public float TempMax { get => tempMax; set => tempMax = value; }
        public float TempMin { get => tempMin; set => tempMin = value; }

        public WeatherData(string City)
        {
            city = City;
        }

        public void CheckWeather()
        {
            WeatherAPI DataAPI = new WeatherAPI(City);
            temp = DataAPI.GetTemp();
        }
    }
    public class WeatherAPI
    {
        private const string AppId = "bd5e378503939ddaee76f12ad7a97608";
        private string CurrentURL;
        private XmlDocument xmlDocument;

        public WeatherAPI(string city)
        {
            SetCurrentURL(city);
            xmlDocument = GetXML(CurrentURL);
        }

        public float GetTemp()
        {
            XmlNode temp_node = xmlDocument.SelectSingleNode("//temperature");
            XmlAttribute temp_value = temp_node.Attributes["value"];
            string temp_string = temp_value.Value;
            return float.Parse(temp_string);
        }

        private void SetCurrentURL(string location)
        {
            CurrentURL = "http://api.openweathermap.org/data/2.5/weather?q=" + location + "&mode=xml&units=metric&APPID=" + AppId;
        }

        private XmlDocument GetXML(string CurrentURL)
        {
            using (WebClient client = new WebClient())
            {
                string xmlContent = client.DownloadString(CurrentURL);
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xmlContent);
                return xmlDocument;
            }
        }
    }
}
