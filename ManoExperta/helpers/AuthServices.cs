using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dominio;

namespace ManoExperta.helpers
{
    static public class AuthServices
    {

        static public bool estaLogueado(Usuario usuario)
        {
            if (usuario != null) {return true;}
            return false;            
        }
    }
}