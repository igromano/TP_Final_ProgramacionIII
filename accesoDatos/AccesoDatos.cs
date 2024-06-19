using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace accesoDatos
{
    public class AccesoADatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        public SqlDataReader lector;

        public AccesoADatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=ManoExperta; integrated security=true");
            comando = new SqlCommand();
        }

        public void configurarConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void configurarProcedimiento(string sp)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;
        }

        public void ejecutarConsulta()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setearProcedimiento(string sp)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;
        }

        //Retorna 
        public int ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                return (int)comando.ExecuteScalar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void settearParametros(string nombre, object valor)
            {
                comando.Parameters.AddWithValue(nombre, valor);
            }
        public void cerrarConexion()
        {
            if(lector != null)
            {
                lector.Close();
            }
            conexion.Close();
        }
    }
}
