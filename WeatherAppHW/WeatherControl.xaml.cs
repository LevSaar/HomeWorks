using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace WeatherAppHW
{
    /// <summary>
    /// Логика взаимодействия для WeatherControl.xaml
    /// </summary>
    public partial class WeatherControl : UserControl
    {
        private ForecastDay mainData;
        public WeatherControl(ForecastDay data)
        {
            InitializeComponent();
            mainData = data;
            date.Text = data.Date;
            SetImage();
            dayTemp.Text = data.Day.Maxtemp;
            nightTemp.Text = data.Day.Mintemp;
            specification.Text = data.Day.Condition.Text;
            humidity.Text = data.Day.Humidity;
            wind.Text = data.Day.Maxwind;
        }

        private async void SetImage()
        {
            var img = new BitmapImage();
            img.BeginInit();
            img.StreamSource = await GetImage();
            img.EndInit();
            image.Source = img;
        }

        private Task<MemoryStream> GetImage()
        {
            return Task.Run(() =>
            {
                using (WebClient client = new WebClient())
                {
                    mainData.Day.Condition.Icon = "https:" + mainData.Day.Condition.Icon;
                    var data = client.DownloadData(mainData.Day.Condition.Icon);
                    var stream = new MemoryStream(data);
                    return stream;
                }
            });
        }
    }
}
