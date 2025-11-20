using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp {
    public class Current {
        public string time {  get; set; }
        public double temperature_2m { get; set; }
        public double wind_speed_10m {  get; set; }
        public double relative_humidity_2m { get; set; }
    }
}
