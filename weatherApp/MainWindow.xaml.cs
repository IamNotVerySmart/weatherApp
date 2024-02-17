using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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
using Newtonsoft.Json;
using System.Net;

namespace weatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string ApiKey = "41cd5be74dd9087720d9927e1a751837";

        public MainWindow()
        {
            InitializeComponent();

            //
            //
            //
        }

        private void btnSearch(object sender, RoutedEventArgs e)
        {
            CallApi();
        }

        void CallApi()
        {
            using (WebClient web = new WebClient())
            {
                string url = $"https://api.openweathermap.org/data/2.5/weather?q={CityNameBox.Text}&appid={ApiKey}&units=metric";
                var json = web.DownloadString(url);
                DisplayData.root info = JsonConvert.DeserializeObject<DisplayData.root>(json);

                // imagePhase. = "https://opeanweathermap.org/img/w/" + info.weather[0].icon + ".png";

                imagePhase.Source = new BitmapImage(new Uri("https://opeanweathermap.org/img/w/" + info.weather[0].icon + ".png"));
                labelTemperature.Content = info.main.temp + "°C";
                labelFeltTemperature.Content = info.main.feels_like + "°C";
                labelPressure.Content = info.main.pressure + "hPa";
                labelHumidity.Content = info.main.humidity + "%";
                labelWindSpeed.Content = info.wind.speed + "m/s";
                labelPhase.Content = info.weather[0].main;
                labelDescription.Content = info.weather[0].description;
                labelCountry.Content = info.sys.country;
                labelVisibility.Content = info.visibility + "m";
                
            }
        }
    }
}
