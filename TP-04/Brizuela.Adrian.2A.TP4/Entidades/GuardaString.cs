using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        #region Metodos
        /// <summary>
        /// Guarda un archivo de texto en el escritorio de la maquina
        /// </summary>
        /// <param name="texto">texto a guardar</param>
        /// <param name="archivo">path</param>
        /// <returns>true si pudo guardar ,false si no</returns>
        public static bool Guardar(this string texto, string archivo)
        {
            try
            {

                using (StreamWriter guardar = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + archivo + ".txt", true))
                {
                    guardar.WriteLine(texto);
                    guardar.Close();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}
