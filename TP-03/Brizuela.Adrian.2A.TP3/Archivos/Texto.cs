using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Excepciones;

namespace Archivos
{
    public class Texto
    {
        #region Metodos
        /// <summary>
        /// Metodo el cual implementa el metodo Guardar de la interfaz IArchivo
        /// </summary>
        /// <param name="archivo">direccion del archivo (path)</param>
        /// <param name="datos">datos a guardar</param>
        /// <returns>true si guarda los datos , false si no</returns>
        public bool Guardar(string archivo, string datos)
        {
            bool ret = false;

            try
            {
                using (StreamWriter writer = new StreamWriter(archivo, false))
                {
                    writer.WriteLine(datos);
                    ret = true;
                }
                ret = true;
            }
            catch (Exception excep)
            {
                throw new ArchivosException(excep);
            }

            return ret;
        }

        /// <summary>
        /// Metodo que implementa el metodo Leer de la interfaz IArchivo
        /// </summary>
        /// <param name="archivo">direccion del archivo (path)</param>
        /// <param name="datos">cadena en donde se guardan los datos que se leen</param>
        /// <returns>true si pudo leer , false si no</returns>
        public bool Leer(string archivo, out string datos)
        {
            bool ret = false;
            datos = "";

            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    datos = reader.ReadToEnd();
                }
                ret = true;
            }
            catch (Exception excep)
            {
                throw new ArchivosException(excep);
            }

            return ret;
        }
        #endregion
    }
}
