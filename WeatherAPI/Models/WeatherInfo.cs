using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPI.Models
{
    public class WeatherInfo
    {
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public double generationtime_ms { get; set; }
        public double utc_offset_seconds { get; set; }
        public string timezone { get; set; }
        public string timezone_abbreviation { get; set; }
        public decimal elevation { get; set; }
        public CurrentWeather current_weather { get; set; }
    }
}
