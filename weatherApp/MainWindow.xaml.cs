using System;
using System.Windows;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;
using System.Net;
using System.Windows.Input;
using System.Windows.Controls;

namespace weatherApp
{
    public partial class MainWindow : Window
    {

        string ApiKey = "41cd5be74dd9087720d9927e1a751837";

        public MainWindow()
        {
            InitializeComponent();

            //
            //https://api.openweathermap.org/data/2.5/forecast?q=warsaw&appid=41cd5be74dd9087720d9927e1a751837&units=metric
            //
        }

        private void btnSearch(object sender, RoutedEventArgs e)
        {
            CallApi();
        }

        private void EnterPress(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                CallApi();
            }
        }

        void CallApi()
        {
            try
            {
                using (WebClient web = new WebClient())
                {
                    string url = $"https://api.openweathermap.org/data/2.5/forecast?q={CityNameBox.Text}&appid={ApiKey}&units=metric";
                    var json = web.DownloadString(url);
                    DisplayData.root info = JsonConvert.DeserializeObject<DisplayData.root>(json);

                    // imagePhase. = "https://opeanweathermap.org/img/w/" + info.weather[0].icon + ".png";

                    CityNameBox.Text = "";

                    SetWeatherDetails(info.list[0], info, date1, imagePhase1, labelTemperature1,
                        labelFeltTemperature1, labelPressure1, labelHumidity1, labelWindSpeed1,
                        labelPhase1, labelDescription1, labelCountry1, labelCity1, labelVisibility1);

                    SetWeatherDetails(info.list[8], info, date2, imagePhase2, labelTemperature2,
                        labelFeltTemperature2, labelPressure2, labelHumidity2, labelWindSpeed2,
                        labelPhase2, labelDescription2, labelCountry2, labelCity2, labelVisibility2);
                    // można tutaj dodać kolejne dni
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Invalid city name, try something that exist.");
            }
        }
        void SetWeatherDetails(DisplayData.list weatherInfo, DisplayData.root info, Label lDate, Image iPhase, Label lTemperature,
            Label lFeltTemperature, Label lPressure, Label lHumidity, Label lWindSpeed, Label lPhase, Label lDescription,
            Label lCountry, Label lCity, Label lVisibility)
        {
            lDate.Content = weatherInfo.dt_txt;
            iPhase.Source = new BitmapImage(new Uri("https://openweathermap.org/img/w/" + weatherInfo.weather[0].icon + ".png"));
            lTemperature.Content = $"{weatherInfo.main.temp}°C";
            lFeltTemperature.Content = $"{weatherInfo.main.feels_like}°C";
            lPressure.Content = $"{weatherInfo.main.pressure} hPa";
            lHumidity.Content = $"{weatherInfo.main.humidity}%";
            lWindSpeed.Content = $"{weatherInfo.wind.speed} m/s";
            lPhase.Content = weatherInfo.weather[0].main;
            lDescription.Content = weatherInfo.weather[0].description;
            lCountry.Content = info.city.country;
            lCity.Content = info.city.name;
            lVisibility.Content = $"{weatherInfo.visibility}m";
        }
    }
}
