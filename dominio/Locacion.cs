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
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int IdProvincia { get; set; }

        public string NombreProvincia { get; set; }
    }
}