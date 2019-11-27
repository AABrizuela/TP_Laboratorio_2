using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Fields
        private static SqlCommand comando;
        private static SqlConnection conexion;
        #endregion

        #region Methods

        static PaqueteDAO()
        {
            PaqueteDAO.conexion = new SqlConnection(Properties.Settings.Default.Conexion);
            PaqueteDAO.comando = new SqlCommand();

            PaqueteDAO.comando.CommandType = System.Data.CommandType.Text;
            PaqueteDAO.comando.Connection = PaqueteDAO.conexion;
        }

        public static bool Insertar(Paquete p)
        {            
            bool retorno = false;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("INSERT INTO dbo.Paquetes (direccionEntrega,trackingID,alumno) VALUES('{0}','{1}','{2}')", p.DireccionEntrega, p.TrackingID, "Brizuela Adrian");
            try
            {
                retorno = EjecutarNonQuery(sb.ToString());
            }
            catch (Exception e)
            {
                throw e;
            }
            return retorno;
        }

        /// <summary>
        /// Funcion que ejecuta el non query
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private static bool EjecutarNonQuery(string sql)
        {
            bool todoOk = false;
            try
            {
                // LE PASO LA INSTRUCCION SQL
                PaqueteDAO.comando.CommandText = sql;


                // ABRO LA CONEXION A LA BD
                PaqueteDAO.conexion.Open();

                // EJECUTO EL COMMAND
                PaqueteDAO.comando.ExecuteNonQuery();

                todoOk = true;
            }
            catch (Exception e)
            {
                todoOk = false;
                throw e;
            }
            finally
            {
                if (todoOk)
                    PaqueteDAO.conexion.Close();
            }
            return todoOk;
        }

        #endregion
    }
}
