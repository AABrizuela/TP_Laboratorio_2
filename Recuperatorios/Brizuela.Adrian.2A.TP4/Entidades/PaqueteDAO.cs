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
        #region Atributos
        private static SqlCommand comando;
        private static SqlConnection conexion;
        #endregion

        #region Constructores
        static PaqueteDAO()
        {
            PaqueteDAO.conexion = new SqlConnection(Properties.Settings.Default.Conexion);
            PaqueteDAO.comando = new SqlCommand();

            PaqueteDAO.comando.CommandType = System.Data.CommandType.Text;
            PaqueteDAO.comando.Connection = PaqueteDAO.conexion;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que inserta un "paquete" en la base de datos correo-sp-2017
        /// </summary>
        /// <param name="p">Objeto a insertar</param>
        /// <returns>true si pudo insertar el objeto , false si no</returns>
        public static bool Insertar(Paquete p)
        {            
            bool retorno = false;
            StringBuilder sb = new StringBuilder();
            
            try
            {
                sb.AppendFormat("INSERT INTO dbo.Paquetes (direccionEntrega,trackingID,alumno) VALUES('{0}','{1}','{2}')", p.DireccionEntrega, p.TrackingID, "Brizuela Adrian");
                comando.CommandText = sb.ToString();
                conexion.Open();
                if (comando.ExecuteNonQuery() > 0)
                {
                    retorno = true;
                }
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorno;
        }
        #endregion
    }
}
