using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using static System.Net.WebRequestMethods;

namespace APIsAndJSON
{
    public class OpenWeatherMapAPI
    {
        public static void CurrentWeather()
        {

            //Show all files in sln explorer, go to bin>debug>net6.0 right click, add item, json configuration file and name it appsettings.json


            //to get the api key from the appsettings file
            //Get all text in the file
            string key = System.IO.File.ReadAllText("appsettings.json");
            //Parse the key
            string APIkey = JObject.Parse(key).GetValue("DefaultKey").ToString();


            Console.WriteLine("Enter your zip code");
            var zipCode = int.Parse(Console.ReadLine());

            var client = new HttpClient();
            var owmURL = $"https://api.openweathermap.org/data/2.5/weather?zip={zipCode}&units=imperial&,&appid={APIkey}";
            var response = client.GetStringAsync(owmURL).Result;

            //parsing openweathermaps json
            var city = JObject.Parse(response)["name"].ToString();
            var temp = double.Parse(JObject.Parse(response)["main"]["temp"].ToString());
            var feelsLike = double.Parse(JObject.Parse(response)["main"]["feels_like"].ToString());
            Console.WriteLine($"Here is your current weather for {city}");
            Console.WriteLine($"The tempurature is {temp} degrees");
            Console.WriteLine($"It feels like {temp} degrees");
        }
    }
}
