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
