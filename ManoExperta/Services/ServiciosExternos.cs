using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;
using Newtonsoft.Json;
using dominio;
using Newtonsoft.Json.Linq;

namespace ManoExperta.Services
{
    public class ServiciosExternos
    {

        public async Task<Locacion> getLocacion()
        {
            HttpClient client = new HttpClient();
            Locacion locacion = new Locacion();
            try
            {
                client.DefaultRequestHeaders.Add("X-Api-Key", "/e7DiKKU7/15e6/OTK+yWA==xYJzl1BLbeghcIAJ");
                //HttpResponseMessage response = await client.GetAsync("https://apis.datos.gob.ar/georef/api/provincias");
                HttpResponseMessage response = await client.GetAsync("https://api.api-ninjas.com/v1/iplookup?address=73.9.149.180");
                response.EnsureSuccessStatusCode();
                string body = await response.Content.ReadAsStringAsync();
                //string body = @"{cantidad:77,inicio:25}";
                JObject json = JObject.Parse(body);
                locacion.Ciudad = json["cantidad"]?.ToString();
                locacion.Provincia = json["inicio"]?.ToString();
                //locacion.Ciudad = json["city"]?.ToString();
                //locacion.Provincia = json["region"]?.ToString();
                //locacion.DireccionIp = json["ip"]?.ToString();
                //locacion.Version = json["version"]?.ToString();
                //locacion.Pais = json["country_name"]?.ToString();
                //locacion.Capital = json["country_capital"]?.ToString();
                //locacion.CodPostal = json["postal"]?.ToString();
                //locacion.Latitud = double.Parse(json["latitude"]?.ToString());
                //locacion.Longitud = double.Parse(json["longitude"]?.ToString());
                return locacion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}