using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace Bank
{
    /// <summary>
    /// Логика взаимодействия для ExchangeRateWindow.xaml
    /// </summary>
    public partial class ExchangeRateWindow : Window
    {
        public static ObservableCollection<ValuteObject> Obj { get; set; }
        public ExchangeRateWindow()
        {
            InitializeComponent();

            string jsonStr;

            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                jsonStr = client.DownloadString("https://www.cbr-xml-daily.ru/daily_json.js");
            }

            Valutes valute = JsonConvert.DeserializeObject<Valutes>(jsonStr);
            Obj = new ObservableCollection<ValuteObject>();

            usdTextBlock.Text = valute.USD.Value.ToString();
            kztTextBlock.Text = valute.KZT.Value.ToString();
            eurTextBlock.Text = valute.EUR.Value.ToString();
        }
    }
}
