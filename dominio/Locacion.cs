using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace dominio
{


    public partial class Locacion
    {
        [JsonProperty("ip")]
        public string DireccionIp { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("city")]
        public string Ciudad { get; set; }

        [JsonProperty("region")]
        public string Provincia { get; set; }

        [JsonProperty("country_name")]
        public string Pais { get; set; }

        [JsonProperty("country_capital")]
        public string Capital { get; set; }

        [JsonProperty("postal")]
        public string CodPostal { get; set; }

        [JsonProperty("latitude")]
        public double Latitud { get; set; }

        [JsonProperty("longitude")]
        public double Longitud { get; set; }
    }
}