using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesAbstractas;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    public class Universidad
    {
        #region Atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region Propiedades
        public List<Alumno> Alumnos { get => this.alumnos; set => this.alumnos = value; }

        public List<Profesor> Instructores { get => this.profesores; set => this.profesores = value; }

        public List<Jornada> Jornadas { get => this.jornada; set => this.jornada = value; }

        public Jornada this[int i]
        {
            get
            {
                if (i >= 0 && i < this.jornada.Count)
                {
                    return this.jornada[i];
                }
                else
                {
                    return null;
                }
            }

            set => this.jornada[i] = value;
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto que inicializa las listas que tiene la clase
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo estatico que  serializa los datos del Universidad en un XML, incluyendo todos los datos de sus
        ///Profesores, Alumnos y Jornadas
        /// </summary>
        /// <param name="u">universidad a serializar</param>
        /// <returns>true si pudo serializar , false si no</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();

            return xml.Guardar((AppDomain.CurrentDomain.BaseDirectory) + "\\Universidad.xml", uni);
        }

        /// <summary>
        /// Metodo estatico
        /// </summary>
        /// <returns> retorna un Universidad con todos los datos previamente serializado</returns>
        public static Universidad Leer()
        {
            Universidad uni = new Universidad();
            Xml<Universidad> xml = new Xml<Universidad>();            

            xml.Leer((AppDomain.CurrentDomain.BaseDirectory) + "\\Universidad.xml", out uni);

            return uni;
        }

        /// <summary>
        /// Metodo estatico
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>Retorna los datos de Universiidad</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (Jornada item in uni.jornada)
            {
                stringBuilder.AppendLine(item.ToString());
                stringBuilder.AppendLine("<------------------------------------------------>");
            }            

            return stringBuilder.ToString();            
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga != compara si una universidad es distinta a un alumno si el mismo no esta inscripto en el
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="a">Alumno a compara</param>
        /// <returns>true si el alumno no esta inscripto , false si esta inscripto</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Sobrecarga == compara si una universidad es igual a un alumno si el mismo esta inscripto en el
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="a">alumno a comparar</param>
        /// <returns>true si el alumno esta inscripto , false si no </returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            if(!Object.Equals(g, null) && !Object.Equals(a, null))
            {
                if (g.alumnos.Contains(a))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// obrecarga != Comapara si una universidad es distinta a un profesor si el mismo no esta dando clase en el
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="i">Profesor a comparar</param>
        /// <returns>true si el profesor no da clases en la universidad , false si el miso da clases </returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Sobrecarga == Comapara si una universidad es igual a un profesor si el mismo esta dando clase en el
        /// </summary>
        /// <param name="g">Unviersidad a comparar</param>
        /// <param name="i">Profesor a comparar</param>
        /// <returns>true si el profesor da clases en la universidad , false si no</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            if (!Object.Equals(g, null) && !Object.Equals(i, null))
            {
                if (g.profesores.Contains(i))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Sobrecarga != entre universidad y clase dentro se utiliza la sobrecarga  == de profesor
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>retorna el primer profesor capas de no dar la clase, sino lanza una excepcion</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor retorno = new Profesor();
            bool flag = false;            

            for (int i = 0; i < u.profesores.Count; i++)
            {
                if (u.profesores[i] != clase)
                {
                    retorno = u.profesores[i];
                    flag = true;
                    break;
                }
            }
            if (flag == false)
            {
                throw new SinProfesorException();
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga == entre universidad y clase dentro se utiliza la sobrecarga  == de profesor
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>retorna el primer profesor capas de dar la clase, sino lanza una excepcion</returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            Profesor retorno = new Profesor();
            bool flag = false;

            for (int i = 0; i < g.profesores.Count; i++)
            {
                if (g.profesores[i] == clase)
                {
                    retorno = g.profesores[i];
                    flag = true;
                    break;
                }
            }
            
            if (flag == false)
            {
                throw new SinProfesorException();
            }

            return retorno;            
        }

        /// <summary>
        /// Sobrecarga + en el cual se agrega una clase a una universidad 
        /// </summary>
        /// <param name="g">Universidad </param>
        /// <param name="clase">clase a agregar en la universidad</param>
        /// <returns>Universidad con la clase agregada</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            if (!Object.Equals(g, null))
            {
                Profesor profe = (g == clase);
                Jornada jornada = new Jornada(clase, profe);

                foreach (Alumno item in g.alumnos)
                {
                    if (item == clase)
                    {
                        jornada += item;
                    }
                }

                g.Jornadas.Add(jornada);
            }            

            return g;
        }

        /// <summary>
        /// Sobrecarga + Agrega un alumno a la universidad si no estan previamente cargados
        /// </summary>
        /// <param name="g">Universidad </param>
        /// <param name="a">alumno a agregar en la universidad</param>
        /// <returns>retorna universidad con el alumno agregado , caso contrario lanza excepcion</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (!Object.Equals(u, null) && !Object.Equals(a, null))
            {
                if (u != a)
                {
                    u.Alumnos.Add(a);
                }
                else
                {
                    throw new AlumnoRepetidoException();
                }
            }

            return u;
        }

        /// <summary>
        /// Sobrecarga + Agrega un profesor a la universidad si no estan previamente cargados
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">profesor a agregar en la universidad</param>
        /// <returns>retorna universidad con el profesor agregado </returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (!Object.Equals(u, null) && !Object.Equals(i, null))
            {
                if (u != i)
                {
                    u.profesores.Add(i);
                }                
            }

            return u;
        }

        /// <summary>
        /// Sobercarga Metodo
        /// </summary>
        /// <returns>Retorna los datos de universidad de manera publica</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        #endregion

        #region Enumeradores
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion
    }
}
