using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherAPI;
using WeatherAPI.Models;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        WeatherRepo _repo = new WeatherRepo();

        [TestMethod]
        public void TestLoadJson()
        {
            //Arrange
            List<CityMap> arng_cityMap = new List<CityMap>()
            {
                new CityMap(){ city = "Kolkata", Latitude = "22.5411", Longitude = "88.3378"},
                new CityMap(){ city = "Mumbai", Latitude = "18.9667", Longitude = "72.8333"}
            };
            string expected_city = arng_cityMap[0].city;

            //Act
            List<CityMap> act_cityMap = _repo.LoadJson();
            string actual_city = act_cityMap[0].city;

            //assert
            Assert.AreEqual(expected_city, actual_city);
        }
        [TestMethod]
        public void TestWeatherInfo()
        {
            //Arrange
            decimal latitude = decimal.Parse("22.5411");
            decimal longitude = decimal.Parse("88.3378");
            decimal exp_elevation = 5;

            //Act
            WeatherInfo weatherInfo = ((Task<WeatherInfo>)_repo.GetWeather(Convert.ToDecimal(latitude), Convert.ToDecimal(longitude))).Result;
            decimal act_elevation = weatherInfo.elevation;

            //assert
            Assert.AreEqual(exp_elevation, act_elevation);
        }
    }
}
