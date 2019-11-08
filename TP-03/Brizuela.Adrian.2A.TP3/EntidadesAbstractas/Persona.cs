using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Excepciones;
using EntidadesAbstractas;

namespace EntidadesAbstractas
{
    public class Persona
    {
        #region Atributos
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region Propiedades
        /// <summary>
        /// get y set del atributo apellido con la validacion de apellido correcto en el set
        /// </summary>
        public string Apellido
        {
            get => this.apellido;
            set => this.apellido = ValidarNombreApellido(value);
        }

        /// <summary>
        /// set y get para el atributo dni en con la validacion de que ingrese un dni correcto
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        /// <summary>
        /// gey y set del atributo nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get => this.nacionalidad;
            set => this.nacionalidad = value;
        }

        /// <summary>
        /// get y set del atributo nombre con la validacion de nombre correcto en el set
        /// </summary>
        public string Nombre
        {
            get => this.nombre;
            set => this.nombre = ValidarNombreApellido(value);
        }

        /// <summary>
        /// set para el atributo dni en  con la validacion de que ingrese un dni correcto
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }
        #endregion

        #region Constructores        
        /// <summary>
        /// constructor por defecto
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// constructor con 3 parametros
        /// </summary>
        /// <param name="nombre">nombre de persona</param>
        /// <param name="apellido">apellido de persona</param>
        /// <param name="nacionalidad">nacionalidad de persona</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        /// <summary>
        /// constructor parametrizado el cual llama al constructor de 3 parametros
        /// </summary>
        /// <param name="nombre">nombre de persona</param>
        /// <param name="apellido">apellido de persona</param>
        /// <param name="dni">dni de persona</param>
        /// <param name="nacionalidad">nacionalidad de persona</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// constructor parametrizado el cual llama al constructor de 3 parametros
        /// </summary>
        /// <param name="nombre">nombre de persona</param>
        /// <param name="apellido">apellido de persona</param>
        /// <param name="dni">dni de persona</param>
        /// <param name="nacionalidad">nacionalidad de persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion


        #region Metodos
        /// <summary>
        /// Valida el formato del dni y que sea correcto dependiendo la nacionalidad de cada persona, reutiliza al ValidarDni (string)
        /// </summary>
        /// <param name="nacionalidad">nacionalidad de persona</param>
        /// <param name="dato">dni de persona</param>
        /// <returns>retorna el dni de la persona</returns>
        public int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            return this.ValidarDni(nacionalidad, dato.ToString());
        }

        /// <summary>
        /// Valida el formato del dni y que sea correcto dependiendo la nacionalidad de cada persona
        /// </summary>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        /// <param name="dato">dni a validar</param>
        /// <returns>retorna el dni  de la persona</returns>
        public int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int retorno = -1;
            if (dato.Length <= 8 && Int32.TryParse(dato, out dni))
            {
                int dni = Int32.Parse(dato);
                switch (nacionalidad)
                {
                    case ENacionalidad.Argentino:


                        if (dni > 0 && dni < 90000000)
                        {
                            retorno = dni;
                        }
                        else
                        {
                            throw new NacionalidadInvalidaException("La Nacionalidad no se coincide con el numero de DNI");
                        }

                        break;

                    case ENacionalidad.Extranjero:


                        if (dni > 89999999 && dni <= 99999999)
                        {
                            retorno = dni;
                        }
                        else
                        {
                            throw new NacionalidadInvalidaException("La Nacionalidad no se coincide con el numero de DNI");
                        }

                        break;

                    default:
                        break;
                }
            }
            else
            {
                throw new DniInvalidoException("Dni formato incorrecto");
            }
            return retorno;
        }

        /// <summary>
        /// Valida que los nombres sean cadenas con caracteres válidos para nombre
        /// </summary>
        /// <param name="dato">nombre de persona</param>
        /// <returns>retorna cadena que puede ser nombre u apellido de persona</returns>
        public string ValidarNombreApellido(string dato)
        {
            bool validar = true;

            foreach (char item in dato)
            {
                if (!(char.IsLetter(item)))
                {
                    validar = false;
                    break;
                }
            }

            if (validar != true)
            {
                //Caso contrario, no se cargará
                //no sabia si dejar una cadena vacia en el atributo , pero como dice no se cargar decidi enviar una excepcion
                throw new Exception("no se pudo cargar ,error en el nombre");
            }

            return dato;
        }
        #endregion

        #region Sobreescritura
        /// <summary>
        /// Sobrecarga de metodo
        /// </summary>
        /// <returns>Retorna todos los datos de persona</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.apellido, this.nombre);
            stringBuilder.AppendFormat("NACIONALIDAD: {0}\n", this.nacionalidad);

            return stringBuilder.ToString();
        }
        #endregion

        #region Enumerador
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion
    }
}
