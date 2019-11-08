using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Metodo que implementa el metodo Guardar de la interfaz IArchivo
        /// </summary>
        /// <param name="archivo">direccion del achivo(path)</param>
        /// <param name="datos">datos a serializar</param>
        /// <returns>true si pudo guardar , false si no pudo</returns>
        public bool Guardar(string archivo, T datos)
        { 
            bool retorno = false;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                XmlTextWriter sw = new XmlTextWriter(archivo, Encoding.UTF8);
                serializer.Serialize(sw, datos);
                sw.Close();
                retorno = true;
            }

            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retorno;

        }

        /// <summary>
        /// Metodo que implementa el metodo de la interfaz IArchivo
        /// </summary>
        /// <param name="archivo">direccion del archivo(path)</param>
        /// <param name="datos">datos a leer</param>
        /// <returns>true si pudo leer , false si no</returns>
        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                XmlTextReader sr = new XmlTextReader(archivo);
                datos = (T)serializer.Deserialize(sr);
                sr.Close();

                retorno = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
        }
    }
}

