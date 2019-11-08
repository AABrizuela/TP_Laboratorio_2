using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Archivos;
using EntidadesAbstractas;
using Excepciones;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region Propiedad

        public List<Alumno> Alumnos { get => this.alumnos; set => this.alumnos = value; }

        public Universidad.EClases Clase { get => this.clase; set => this.clase = value; }

        public Profesor Instructor { get => this.instructor; set => this.instructor = value; }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor que inicializa el atributo alumnos
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// constructor parametrizado que llama al base e inicializa los demas atributos propios
        /// </summary>
        /// <param name="clase">clase de la jornada</param>
        /// <param name="instructor">instructor que da clase</param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Metodo que guarda los datos de la Jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>true si pudo guarda , false si no pudo</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto txt = new Texto();

            return txt.Guardar((AppDomain.CurrentDomain.BaseDirectory) + "\\Jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// Metodo que lee los datos de la Jornada desde un archivo de texto
        /// </summary>
        /// <returns> retornará los datos de la Jornada como texto</returns>
        public static string Leer()
        {
            string ret;
            Texto txt = new Texto();

            txt.Leer((AppDomain.CurrentDomain.BaseDirectory) + "\\Jornada", out ret);

            return ret;
        }

        /// <summary>
        /// Sobrecarga operador !=
        /// </summary>
        /// <param name="j">jornada a comparar</param>
        /// <param name="a">alumno a comparar</param>
        /// <returns>true si el alumno no participa de la clase , flase si participa</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Sobrecarga operador == 
        /// </summary>
        /// <param name="j">jornada a comparar</param>
        /// <param name="a">alumno a comparar</param>
        /// <returns>true si el alumno participa de la clase , flase si no</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            if(!Object.Equals(j, null) && !Object.Equals(a, null))
            {
                if (j.Alumnos.Contains(a))
                {
                    return true;
                }                    
            }

            return false;
        }

        /// <summary>
        /// Agrega un alumno a la jornada validando que no este previamente cargado
        /// </summary>
        /// <param name="j">jornada</param>
        /// <param name="a">alumno</param>
        /// <returns>jornada con el alumno agregado</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (!Object.Equals(j, null) && !Object.Equals(a, null))
            {
                if (j != a)
                {
                    j.Alumnos.Add(a);
                }
                else
                {
                    throw new AlumnoRepetidoException();
                }
            }

            return j;
        }

        /// <summary>
        /// Sobrecarga de metodo
        /// </summary>
        /// <returns>Retorna los datos de la jornada de manera publica</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            sb.AppendLine("CLASE DE " + this.clase + " POR " + this.instructor);
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno item in this.alumnos)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
        #endregion
    }
}
