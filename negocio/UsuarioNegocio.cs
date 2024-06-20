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
                datos.settearParametros("@Usuario", usuario.UserName);
                datos.settearParametros("@Contrasenia", usuario.Contrasenia);
                datos.settearParametros("@IdRol", usuario.RolUsuario);
                datos.settearParametros("@Email", usuario.Email);
                datos.ejecutarConsulta();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                datos.cerrarConexion();
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
                            case 1:
                                usuario.RolUsuario = RolUsuario.PRESTADOR;
                                usuario.Id = (int)datos.lector["ID"];
                                return usuario;
                            case 2:
                                usuario.RolUsuario = RolUsuario.USUARIO;
                                usuario.Id = (int)datos.lector["ID"];
                                return usuario;
                            default:
                                return usuario;
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateUsuario(Usuario usuario)
        {

            if (usuario == null || usuario.Id == null || usuario.Id < 0)
            {
                throw new Exception("El usuario provisto no es valido");
            }
            bool persona = false;
            AccesoADatos datos = new AccesoADatos();
            if (usuario.IdPersona != null || usuario.IdPersona > 0)
            {
                persona = true;
            }
            try
            {
                datos.configurarProcedimiento("SP_UpdateUser");
                datos.settearParametros("@Id", usuario.Id);
                datos.settearParametros("@Usuario", usuario.UserName);
                datos.settearParametros("@Contrasenia", usuario.Contrasenia);
                datos.settearParametros("@Email", usuario.Email);
                datos.settearParametros("@Persona", persona);
                datos.settearParametros("@IdPersona", usuario.IdPersona);
                datos.settearParametros("@Nombre", usuario.Nombre);
                datos.settearParametros("@Apellido", usuario.Apellido);
                datos.settearParametros("@Sexo", usuario.Sexo);
                datos.settearParametros("@FechaNacimiento", usuario.FechaNacimiento);
                datos.settearParametros("@IDLocalidad", usuario.IdLocalidad);

                datos.ejecutarConsulta();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
