using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                datos.settearParametros("@Activo", usuario.Activo);
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
            int idUsuario = -1;
            AccesoADatos datos = new AccesoADatos();
            try
            {
                if (usuario != null || usuario.UserName.Length > 0)
                {
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
                                //usuario.Id = (int)datos.lector["ID"];
                                idUsuario = (int)datos.lector["ID"];
                                //return usuario;
                                break;
                            case 1:
                                usuario.RolUsuario = RolUsuario.PRESTADOR;
                                //usuario.Id = (int)datos.lector["ID"];
                                idUsuario = (int)datos.lector["ID"];
                                //return usuario;
                                break;
                            case 2:
                                usuario.RolUsuario = RolUsuario.USUARIO;
                                //usuario.Id = (int)datos.lector["ID"];
                                idUsuario = (int)datos.lector["ID"];
                                //return usuario;
                                break;
                            default:
                                return usuario;
                        }
                    }
                }
                //return null;
                datos.cerrarConexion();
                return getUsuario(idUsuario);
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

        public Usuario getUsuario(int idUsuario)
        {
            if(idUsuario < 0)
            {
                throw new Exception("Usuario inexistente");
            }
            AccesoADatos datos = new AccesoADatos();
            Usuario usuario = new Usuario();
            try
            {
                datos.configurarConsulta("SELECT * FROM Personas where ID = @idUsuario");
                datos.settearParametros("@idUsuario", idUsuario);
                datos.ejecutarConsulta();
                while (datos.lector.Read())
                {
                    usuario.Id = int.Parse(datos.lector["ID"].ToString());
                    usuario.UserName = datos.lector["ID"].ToString();
                    usuario.Contrasenia = datos.lector["Contrasenia"].ToString();
                    usuario.RolUsuario = (RolUsuario)(Int16)datos.lector["iDRol"];
                    usuario.FechaAlta = datos.lector.GetDateTime(3); //3 o 4
                    usuario.Email = datos.lector["Email"].ToString();
                    usuario.IdPersona = datos.lector["IDPersona"].ToString();
                    usuario.Nombre = datos.lector["Nombre"].ToString();
                    usuario.Apellido = datos.lector["Apellido"].ToString();
                    usuario.Sexo = char.Parse(datos.lector["Sexo"].ToString());
                    usuario.FechaNacimiento = datos.lector.GetDateTime(9); //9 o 10
                    usuario.Domicilio = datos.lector["Domicilio"].ToString();
                    usuario.IdLocalidad = int.Parse(datos.lector["IDLocalidad"].ToString());
                }
                return usuario;
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

        public void updateUsuario(Usuario usuario)
        {

            if (usuario == null || usuario.Id == null || usuario.Id < 0)
            {
                throw new Exception("El usuario provisto no es valido");
            }
            bool persona = false;
            AccesoADatos datos = new AccesoADatos();
            if (usuario.IdPersona != null || usuario.IdPersona.Length > 0)
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
