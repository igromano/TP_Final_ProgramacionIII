using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dominio;

namespace negocio.Utils
{
    public static class Utils
    {
        public static List<Estado> estados = new List<Estado>();
        public static List<Locacion> locaciones = new List<Locacion>();
        public static List<Especialidad> especialidades = new List<Especialidad>();
        public static List<Estado> getEstados()
        {
            if (estados.Count == 0)
            {
                ServicioNegocio negocio = new ServicioNegocio();
                estados = negocio.getEstados();

                return estados;
            }
            return estados;
        }

        public static List<Locacion> getLocaciones()
        {
            if (locaciones.Count == 0)
            {
                ServicioNegocio servicioNegocio = new ServicioNegocio();
                locaciones = servicioNegocio.getLocaciones();

                return locaciones;
            }
            return locaciones;
        }

        public static List<Especialidad> getEspecialidades()
        {
            if (especialidades.Count == 0)
            {
                ServicioNegocio servicioNegocio = new ServicioNegocio();
                especialidades = servicioNegocio.getEspecialidades();

                return especialidades;
            }
            return especialidades;
        }
    }
}
