using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using accesoDatos;
using dominio;
using negocio;

namespace negocio
{
    public class UsuarioNegocio
    {
        public bool registrarUsuario(Usuario usuario)
        {
            AccesoADatos datos = new AccesoADatos();
            datos.setearProcedimiento("SP_NuevoUsuario");
            try
            {
                //datos.ejecutarConsulta();
            }
            catch (Exception ex)
            {

            }
            return true;
        }

        public Usuario login(Usuario usuario)
        {
            try
            {
                if (usuario != null || usuario.UserName.Length > 0)
                {
                    AccesoADatos datos = new AccesoADatos();
                    datos.configurarProcedimiento("SP_Login");
                    datos.settearParametros("@Usuario", usuario.UserName);
                    datos.settearParametros("@Contrasenia", usuario.Contrasenia);
                    datos.ejecutarConsulta();
                    while (datos.lector.Read())
                    {
                        switch ((Int16)datos.lector["iDRol"])
                        {
                            case 0:
                                usuario.RolUsuario = RolUsuario.ADMIN;
                                usuario.Id = (int)datos.lector["ID"];
                                return usuario;
                                //break;
                            case 1:
                                usuario.RolUsuario = RolUsuario.PRESTADOR;
                                usuario.Id = (int)datos.lector["ID"];
                                return usuario;
                                //break;
                            case 2:
                                usuario.RolUsuario = RolUsuario.USUARIO;
                                usuario.Id = (int)datos.lector["ID"];
                                return usuario;
                                //break;
                            default:
                                return usuario;
                        }
                    }
                    //return null;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
