using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherAPI.Models;

namespace WeatherAPI
{
    public class WeatherRepo
    {
        public async Task<WeatherInfo> GetWeather(decimal latitude, decimal longitude)
        {
            WeatherInfo WeatherInfo = null;
            try
            {
                string apiUrl = "https://api.open-meteo.com/v1/forecast?latitude=" + latitude + "&longitude=" + longitude + "&current_weather=true";
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("");

                res.EnsureSuccessStatusCode();
                if (res.IsSuccessStatusCode)
                {
                    string weather = await res.Content.ReadAsStringAsync();
                    WeatherInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherInfo>(weather);
                }
            }
            catch (Exception)
            {
                throw new Exception("GetWeather() error");
            }
            return WeatherInfo;
        }
        public List<CityMap> LoadJson()
        {
            List<CityMap> cityMap = null;
            try
            {
                string filePath = "C:\\Users\\Lenovo\\Downloads\\WeatherAPI\\WeatherAPI\\Json\\MapInfo.json";
                using (StreamReader r = new StreamReader(filePath))
                {
                    string json = r.ReadToEnd();
                    cityMap = JsonConvert.DeserializeObject<List<CityMap>>(json);
                }
            }
            catch (Exception)
            {
                throw new Exception("Please update the filePath of MapInfo.json");
            }
            return cityMap;
        }
    }
}
