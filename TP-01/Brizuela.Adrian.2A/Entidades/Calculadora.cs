using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        #region METODOS
        /// <summary>
        /// Valida y realiza la operacion pedida entre ambos numeros.
        /// </summary>
        /// <param name="numero1">Primer operando.</param>
        /// <param name="numero2">Segundo operando.</param>
        /// <param name="operador">Operacion a realizar entre los operandos.</param>
        /// <returns>Retorna el resultado de la operacion, si fue correcta. Caso contrario retorna 0.</returns>
        public static double Operar(Numero numero1, Numero numero2, string operador)
        {
            double resultado = 0;

            if (ValidarOperador(operador) == "/" || ValidarOperador(operador) == "+" || ValidarOperador(operador) == "-" || ValidarOperador(operador) == "*")
            {
                switch (operador)
                {
                    case "/":
                        resultado = numero1 / numero2;
                        break;

                    case "+":
                        resultado = numero1 + numero2;
                        break;

                    case "-":
                        resultado = numero1 - numero2;
                        break;

                    case "*":
                        resultado = numero1 * numero2;
                        break;
                }
            }

            return resultado;
        }

        /// <summary>
        /// Valida el operador recibido por parametro.
        /// </summary>
        /// <param name="operador">Operador a validar.</param>
        /// <returns>Retorna el operador correspondiente en caso de ser correcto, si no se cumple retorna '+'.</returns>
        private static string ValidarOperador(string operador)
        {
            switch (operador)
            {
                case "/":
                    return operador;

                case "+":
                    return operador;

                case "-":
                    return operador;

                case "*":
                    return operador;

                default:
                    operador = "+";
                    return operador;
            }
        }
        #endregion
    }
}
