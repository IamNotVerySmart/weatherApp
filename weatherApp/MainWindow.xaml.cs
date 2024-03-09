using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;
using System.Net;
using System.Windows.Input;
using System.Collections.Generic;

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
            //https://api.openweathermap.org/data/2.5/forecast?q=warsaw&appid=41cd5be74dd9087720d9927e1a751837&units=metric
            //
        }

        private void btnSearch(object sender, RoutedEventArgs e)
        {
            CallApi();
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

                    imagePhase.Source = new BitmapImage(new Uri("https://openweathermap.org/img/w/" + info.list[0].weather[0].icon + ".png"));
                    labelTemperature.Content = info.list[0].main.temp + "°C";
                    labelFeltTemperature.Content = info.list[0].main.feels_like + "°C";
                    labelPressure.Content = info.list[0].main.pressure + " hPa";
                    labelHumidity.Content = info.list[0].main.humidity + "%";
                    labelWindSpeed.Content = info.list[0].wind.speed + "m/s";
                    labelPhase.Content = info.list[0].weather[0].main;
                    labelDescription.Content = info.list[0].weather[0].description;
                    labelCountry.Content = info.city.country;
                    labelCity.Content = info.city.name;
                    labelVisibility.Content = info.list[0].visibility + "m";
                    CityNameBox.Text = "";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Invalid city name, try something that exist.");
            }
        }

        private void EnterPress(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                CallApi();
            }
        }

        private void btnPrevious(object sender, RoutedEventArgs e)
        {

        }

        private void btnNext(object sender, RoutedEventArgs e)
        {

        }
    }
}
