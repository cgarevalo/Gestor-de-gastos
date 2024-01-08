using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Datos
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesoDatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=GASTOS_DB; integrated security=true");
            comando = new SqlCommand();
        }

        // Limpia los parámetros después de ejecutar una consulta
        private void LimpiarParametros()
        {
            comando.Parameters.Clear();
        }

        // Cierra la conexión a la base de datos y el lector de datos
        public void CerrarConexion()
        {
            if (lector != null)
            {
                lector.Close();
            }

            conexion.Close();
        }

        // Establece la consulta SQL a ejecutar en la base de datos
        public void SetearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        // Ejecuta la consulta en la base de datos
        public void EjecutarConsulta()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar la consulta: " + ex.Message, ex);
            }
            finally
            {
                LimpiarParametros();
            }
        }

        // Ejecuta una acción (como una inserción, actualización o eliminación) en la base de datos
        public void EjecutarAccion()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar la acción: " + ex.Message, ex);
            }
            finally
            {
                LimpiarParametros();
            }
        }

        // Agrega un parámetro a la consulta SQL, para hacer una consulta más fácil 
        public void SetearParametro(string consulta, object valor)
        {
            comando.Parameters.AddWithValue(consulta, valor);
        }

        // Ejecuta una lectura de datos en la base de datos
        public void EjecutarLectura()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al setear parámetros: " + ex.Message, ex);
            }
            finally
            {
                LimpiarParametros();
            }
        }
    }
}
