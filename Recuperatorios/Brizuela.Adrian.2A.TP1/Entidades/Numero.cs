using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor por defecto. Incializa el campo numero de la clase con el valor 0.
        /// </summary>
        public Numero()
        {
            this.SetNumero = Convert.ToString(0);
        }

        /// <summary>
        /// Constructor que recibe un dato de tipo double. Inicializa el atributo 'numero' de la clase con el valor que recibe por parametro.
        /// </summary>
        /// <param name="numero">Variable cuyo numero sera asignado al atributo de la clase.</param>
        public Numero(double numero)
        {
            this.SetNumero = Convert.ToString(numero);
        }

        /// <summary>
        /// Constructor que recibe un dato de tipo string. Inicializa el atributo 'numero' de la clase con el valor que recibe por parametro.
        /// </summary>
        /// <param name="strNumero">Variable cuyo numero sera asignado al atributo de la clase.</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        #endregion

        #region PROPIEDADES
        /// <summary>
        /// Propiedad de escritura. Asignara un valor al atributo 'numero', previa validacion.
        /// </summary>
        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Convierte un numero binario a decimal.
        /// </summary>
        /// <param name="binario">Numero binario a convertir.</param>
        /// <returns>Retorna un numero decimal, en caso de ser posible. Caso contrario retorna 'Valor invalido'.</returns>
        public string BinarioDecimal(string binario)
        {
            string decimalNum = "Valor Invalido";

            if (binario == double.MinValue.ToString())
            {
                decimalNum = binario;
            }
            else if (binario != decimalNum && binario != "")
            {
                char[] arrayString = binario.ToCharArray();

                for (int i = 0; i < arrayString.Length; i++)
                {
                    if (arrayString[i] == '1' || arrayString[i] == '0')
                    {
                        decimalNum += arrayString[i];
                    }
                    else
                    {
                        decimalNum = "Valor Invalido";
                        break;
                    }
                }

                if (decimalNum != "Valor Invalido")
                {
                    decimalNum = Convert.ToInt32(binario, 2).ToString();
                }
            }

            return decimalNum;
        }

        /// <summary>
        /// Convierte un numero positivo y entero a binario.
        /// </summary>
        /// <param name="numero">Numero a convertir.</param>
        /// <returns>Retorna el numero expresado en binario, de ser posible. Caso contrario retorna 'Valor Invalido'</returns>
        public string DecimalBinario(double numero)
        {
            string binario = "Valor Invalido";

            if (numero >= 0)
            {
                if (int.TryParse(Convert.ToString(numero), out int numeroEntero))
                {
                    binario = Convert.ToString(numeroEntero, 2);
                }
                else
                {
                    binario = "Valor Invalido";
                }
            }

            return binario;
        }

        /// <summary>
        /// Convierte un numero positivo y entero a binario.
        /// </summary>
        /// <param name="numero">Numero a convertir.</param>
        /// <returns>Retorna el numero expresado en binario, de ser posible. Caso contrario retorna 'Valor Invalido'</returns>
        public string DecimalBinario(string numero)
        {
            string binario = "";

            if (double.TryParse(numero, out double doubleNumero))
            {
                binario = DecimalBinario(doubleNumero);
            }
            else
            {
                binario = "Valor invalido";
            }

            return binario;
        }

        /// <summary>
        /// Comprueba que el valor recibido sea numerico.
        /// </summary>
        /// <param name="strNumero">Numero a validar.</param>
        /// <returns>Si el numero es correcto lo retorna en tipo double. De caso contrario retorna 0.</returns>
        private double ValidarNumero(string strNumero)
        {
            if (double.TryParse(strNumero, out double resultado))
            {
                return resultado;
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region SOBRECARGA DE OPERADORES
        /// <summary>
        /// Sobrecarga el operador '-' para poder restar las clases sin la necesidad de acceder a sus campos.
        /// </summary>
        /// <param name="n1">Primera clase.</param>
        /// <param name="n2">Segunda clase.</param>
        /// <returns>Retorna la resta entre las 2 clases. De caso contrario retorna -1.</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            if (n1 != null && n2 != null)
                return n1.numero - n2.numero;

            return -1;
        }

        /// <summary>
        /// Sobrecarga el operador '*' para poder multiplicar las clases sin la necesidad de acceder a sus campos.
        /// </summary>
        /// <param name="n1">Primera clase.</param>
        /// <param name="n2">Segunda clase.</param>
        /// <returns>Retorna la multiplicacion entre las 2 clases. De caso contrario retorna -1.</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            if (n1 != null && n2 != null)
                return n1.numero * n2.numero;

            return -1;
        }

        /// <summary>
        /// Sobrecarga el operador '/' para poder dividir las clases sin la necesidad de acceder a sus campos.
        /// </summary>
        /// <param name="n1">Primera clase.</param>
        /// <param name="n2">Segunda clase.</param>
        /// <returns>Retorna el resultado de la division entre las 2 clases. Si el divisor es 0 retorna el double.MinValue.</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n1 != null && n2 != null)
            {
                if (n2.numero == 0)
                {
                    return double.MinValue;
                }
                else
                {
                    return n1.numero / n2.numero;
                }
            }

            return -1;
        }

        /// <summary>
        /// Sobrecarga el operador '+' para poder sumar las clases sin la necesidad de acceder a sus campos.
        /// </summary>
        /// <param name="n1">Primera clase.</param>
        /// <param name="n2">Segunda clase.</param>
        /// <returns>Retorna la suma entre las 2 clases. De caso contrario retorna -1.</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            if (n1 != null && n2 != null)
                return n1.numero + n2.numero;

            return -1;
        }
        #endregion

    }
}
