using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAPI.Models;

namespace WeatherAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                WeatherRepo _repo = new WeatherRepo();
                List<CityMap> cityMap = _repo.LoadJson();
                if (cityMap != null && cityMap.Count > 0)
                {
                    Console.WriteLine("Please enter a city name: ");
                    string city = Console.ReadLine();
                    CityMap obj = cityMap.Where(x => string.Equals(x.city, city, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                    if (obj != null)
                    {
                        WeatherInfo weatherInfo = ((Task<WeatherInfo>)_repo.GetWeather(Convert.ToDecimal(obj.Latitude), Convert.ToDecimal(obj.Longitude))).Result;
                        Console.WriteLine("-------------- Weather report for city : " + city + " --------------");
                        Console.WriteLine("Latitude: " + weatherInfo.latitude);
                        Console.WriteLine("Longitude: " + weatherInfo.longitude);
                        Console.WriteLine("Timezone: " + weatherInfo.timezone);
                        Console.WriteLine("Temperature: " + weatherInfo.current_weather.temperature);
                        Console.WriteLine("Windspeed: " + weatherInfo.current_weather.windspeed);
                        Console.WriteLine("Winddirection: " + weatherInfo.current_weather.winddirection);
                        Console.WriteLine("Time: " + weatherInfo.current_weather.time);
                    }
                    else
                    {
                        Console.WriteLine("City not found in MapInfo.json");
                    }
                }
                Console.ReadLine();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error occured. Please try again");
            }
        }
    }
}
