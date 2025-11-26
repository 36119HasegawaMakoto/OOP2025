using System.Text.Json.Serialization;
namespace TenkiApp.Models {
    public class Prefecture {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class Municipality {
        public string Code { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class FavoriteLocation {
        public string PrefCode { get; set; }
        public string CityCode { get; set; }
    }

    public class JmaAreaInfo {
        public string Code { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string parent { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
    }
    public class WeatherCurrent {
        [JsonPropertyName("time")]
        public string Time { get; set; }
        [JsonPropertyName("temperature")]
        public double Temperature { get; set; }
        [JsonPropertyName("windspeed")]
        public double WindSpeed { get; set; }
        [JsonPropertyName("weathercode")]
        public int WeatherCode { get; set; }
    }
    public class OpenMeteoResponse {
        [JsonPropertyName("current_weather")]
        public WeatherCurrent Current { get; set; }
        [JsonPropertyName("daily")]
        public DailyWeather Daily { get; set; }
        [JsonPropertyName("hourly")]
        public HourlyWeather Hourly { get; set; }
    }
    public class DailyWeather {
        [JsonPropertyName("time")]
        public string[] Time { get; set; }
        [JsonPropertyName("temperature_2m_max")]
        public double[] TemperatureMax { get; set; }
        [JsonPropertyName("temperature_2m_min")]
        public double[] TemperatureMin { get; set; }
        [JsonPropertyName("weathercode")]
        public int[] WeatherCode { get; set; }
    }
    public class DayForecast {
        public string Date { get; set; }
        public string WeatherEmoji { get; set; }
        public string Description { get; set; }
        public string MaxTemp { get; set; }
        public string MinTemp { get; set; }
    }
    public class HourlyForecast {
        public string Time { get; set; }
        public string WeatherEmoji { get; set; }
        public string Temperature { get; set; }
        public string Precipitation { get; set; }
    }
    public class HourlyWeather {
        [JsonPropertyName("time")]
        public string[] Time { get; set; }
        [JsonPropertyName("temperature_2m")]
        public double[] Temperature { get; set; }
        [JsonPropertyName("precipitation")]
        public double[] Precipitation { get; set; }
        [JsonPropertyName("weathercode")]
        public int[] WeatherCode { get; set; }
    }
}