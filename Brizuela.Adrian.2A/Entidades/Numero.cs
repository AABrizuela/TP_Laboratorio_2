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
        public Numero()
        {
            this.SetNumero = Convert.ToString(0);
        }

        public Numero(double numero)
        {
            this.SetNumero = Convert.ToString(numero);
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        #endregion

        #region PROPIEDADES
        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }
        #endregion

        #region METODOS
        public string BinarioDecimal(string binario)
        {
            string numero = "";

            numero = Convert.ToString(Convert.ToInt32(binario, 2));

            return numero;
        }

        public string DecimalBinario(double numero)
        {
            string binario = "";

            if (numero >= 0)
            {
                if (int.TryParse(Convert.ToString(numero), out int numeroEntero))
                {
                    binario = Convert.ToString(numeroEntero, 2);
                }
                else
                {
                    binario = "Valor invalido";
                }
            }

            return binario;
        }

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
        public static double operator -(Numero n1, Numero n2)
        {
            if (n1 != null && n2 != null)
                return n1.numero - n2.numero;

            return -1;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            if (n1 != null && n2 != null)
                return n1.numero * n2.numero;

            return -1;
        }

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

        public static double operator +(Numero n1, Numero n2)
        {
            if (n1 != null && n2 != null)
                return n1.numero + n2.numero;

            return -1;
        }
        #endregion

    }
}
