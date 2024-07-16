using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using accesoDatos;
using dominio;
using negocio.Utils;


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
                datos.settearParametros("@IDPersona", usuario.IdPersona);
                datos.settearParametros("@Nombre", usuario.Nombre);
                datos.settearParametros("@Apellido", usuario.Apellido);

                datos.ejecutarConsulta();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear usuario en DB - Error: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
            return true;
        }

        public Usuario login(Usuario usuario)
        {
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
                        string pass = (datos.lector["Contrasenia"] is DBNull) ?
                             "" :
                             datos.lector["Contrasenia"].ToString();
                        if (pass.Length > 0 && pass.Equals(usuario.Contrasenia))
                        {
                            return getUsuario(int.Parse(datos.lector["ID"].ToString()));
                        }
                    }
                }

                datos.cerrarConexion();

                return null;
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
            if (idUsuario < 0)
            {
                return null;
            }
            AccesoADatos datos = new AccesoADatos();
            Usuario usuario = new Usuario();
            try
            {
                datos.configurarConsulta("SELECT * FROM Personas p " +
                    "LEFT JOIN Especialidad_x_Prestador ep ON p.IDPersona = ep.ID_Persona " +
                    "where p.ID = @idUsuario");
                datos.settearParametros("@idUsuario", idUsuario);
                datos.ejecutarConsulta();
                while (datos.lector.Read())
                {
                    usuario.Id = int.Parse(datos.lector["ID"].ToString());
                    usuario.UserName = datos.lector["Usuario"].ToString();
                    usuario.Contrasenia = datos.lector["Contrasenia"].ToString();
                    usuario.RolUsuario = (RolUsuario)(Int16)datos.lector["iDRol"];
                    usuario.FechaAlta = DateTime.Parse(datos.lector["FechaAlta"].ToString());
                    usuario.Email = datos.lector["Email"].ToString();
                    usuario.IdPersona = datos.lector["IDPersona"].ToString();
                    usuario.Nombre = datos.lector["Nombre"].ToString();
                    usuario.Apellido = datos.lector["Apellido"].ToString();

                    usuario.Sexo = (datos.lector["Sexo"] is DBNull) ? char.Parse("") : char.Parse(datos.lector["Sexo"].ToString());

                    usuario.FechaNacimiento = datos.lector["FechaNacimiento"] is DBNull
                        ? DateTime.Parse("1900-01-01")
                        : DateTime.Parse(datos.lector["FechaNacimiento"].ToString());

                    usuario.Domicilio = datos.lector["Domicilio"] is DBNull
                        ? ""
                        : datos.lector["Domicilio"].ToString();

                    usuario.IdLocalidad = (datos.lector["IDLocalidad"] is DBNull) ? 0 : int.Parse(datos.lector["IDLocalidad"].ToString());
                    usuario.Telefono = (datos.lector["Telefono"]) is DBNull ? "" : datos.lector["Telefono"].ToString();

                    Especialidad especialidad = new Especialidad();
                    especialidad.Id = datos.lector["ID_Especialidad"] is DBNull ? 0
                        : int.Parse(datos.lector["ID_Especialidad"].ToString());
                    usuario.Especialidad = especialidad;
                    if (usuario.Especialidad.Id != 0)
                    {
                        usuario.Especialidad.Nombre = Utils.Utils.getEspecialidades().Find(e => e.Id == usuario.Especialidad.Id).Nombre;
                    }
                    else
                    {
                        usuario.Especialidad.Nombre = "SIN ESPECIALIDAD";
                    }
                    usuario.Activo = bool.Parse(datos.lector["Activo"].ToString());
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
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.configurarProcedimiento("SP_UpdateUser");
                datos.settearParametros("@Id", usuario.Id);
                datos.settearParametros("@Usuario", usuario.UserName);
                datos.settearParametros("@Contrasenia", usuario.Contrasenia);
                datos.settearParametros("@Email", usuario.Email);
                datos.settearParametros("@IdPersona", usuario.IdPersona);
                datos.settearParametros("@Nombre", usuario.Nombre);
                datos.settearParametros("@Apellido", usuario.Apellido);
                datos.settearParametros("@Sexo", usuario.Sexo);
                datos.settearParametros("@FechaNacimiento", usuario.FechaNacimiento);
                datos.settearParametros("@IDLocalidad", usuario.IdLocalidad);
                datos.settearParametros("@Telefono", usuario.Telefono);
                datos.settearParametros("@Domicilio", usuario.Domicilio);
                datos.settearParametros("@Activo", usuario.Activo);

                if (usuario.RolUsuario == RolUsuario.PRESTADOR)
                {
                    datos.settearParametros("@IDEspecialidad", usuario.Especialidad.Id);
                }

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

        public List<Usuario> getUsuariosPorRol(RolUsuario rol)
        {
            AccesoADatos datos = new AccesoADatos();
            List<Usuario> listaUsuarios = new List<Usuario>();
            try
            {
                switch (rol)
                {
                    case RolUsuario.PRESTADOR:
                        datos.configurarConsulta("SELECT (SELECT avg(re.Calificacion) from Ticket t inner join Resenias re on t.ID = re.IDTicket where t.IDPrestador = p.IDPersona) AS 'Calificacion', * FROM Personas p inner join Especialidad_x_Prestador epp ON p.IDPersona = epp.ID_Persona WHERE iDRol = @IdRol");
                        break;
                    case RolUsuario.USUARIO:
                        datos.configurarConsulta("SELECT * FROM Personas WHERE iDRol = @IdRol");
                        break;
                }

                datos.settearParametros("@IdRol", rol);
                datos.ejecutarConsulta();

                while (datos.lector.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.Id = int.Parse(datos.lector["ID"].ToString());
                    usuario.UserName = datos.lector["Usuario"].ToString();
                    usuario.Contrasenia = datos.lector["Contrasenia"].ToString();
                    usuario.RolUsuario = (RolUsuario)(Int16)datos.lector["iDRol"];
                    usuario.FechaAlta = DateTime.Parse(datos.lector["FechaAlta"].ToString());
                    usuario.Email = datos.lector["Email"].ToString();
                    usuario.IdPersona = datos.lector["IDPersona"].ToString();
                    usuario.Nombre = datos.lector["Nombre"].ToString();
                    usuario.Apellido = datos.lector["Apellido"].ToString();
                    usuario.FechaNacimiento = DateTime.Parse(datos.lector["FechaNacimiento"].ToString());

                    if (!(datos.lector["Sexo"].ToString()).Equals("X"))
                    {
                        Especialidad especialidad = new Especialidad();
                        usuario.Sexo = char.Parse(datos.lector["Sexo"].ToString());
                        usuario.Domicilio = datos.lector["Domicilio"].ToString();
                        usuario.IdLocalidad = int.Parse(datos.lector["IDLocalidad"].ToString());
                        especialidad.Id = int.Parse(datos.lector["ID_Especialidad"].ToString());
                        especialidad.Nombre = Utils.Utils.getEspecialidades().Find(e => e.Id == especialidad.Id).Nombre;
                        usuario.Especialidad = especialidad;

                        if (rol == RolUsuario.PRESTADOR && !(datos.lector["Calificacion"] is DBNull))
                        {
                            usuario.Calificacion = int.Parse(datos.lector["Calificacion"].ToString());
                        }
                        listaUsuarios.Add(usuario);
                    }
                }

                return listaUsuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
