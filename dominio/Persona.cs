﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Persona
    {
        public int IdPersona { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public char Sexo { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Domicilio { get; set; }

        public int IdLocalidad { get; set; }
    }
}
