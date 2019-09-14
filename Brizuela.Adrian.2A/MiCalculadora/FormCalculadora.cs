using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
        }

        #region BOTONES
        /// <summary>
        /// Realiza la operacion deseada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = FormCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
        }
        
        /// <summary>
        /// Convierte el numero a binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero ConvertirABinario = new Numero();

            this.lblResultado.Text = ConvertirABinario.DecimalBinario(Convert.ToDouble(this.lblResultado.Text));
        }

        /// <summary>
        /// Convierte el numero a decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero ConvertirADecimal = new Numero();

            this.lblResultado.Text = ConvertirADecimal.BinarioDecimal(this.lblResultado.Text);
        }        

        /// <summary>
        /// Limpia todos los datos de la aplicacion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
        
        /// <summary>
        /// Cierra la aplicacion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Realiza la operacion deseada.
        /// </summary>
        /// <param name="numero1">Primer operando.</param>
        /// <param name="numero2">Segundo operando.</param>
        /// <param name="operador">Operador del calculo a realizar.</param>
        /// <returns>Retorna el resultado de la operacion en formato string.</returns>
        private static string Operar(string numero1, string numero2, string operador)
        {
            Numero numeroUno = new Numero(numero1);
            Numero numeroDos = new Numero(numero2);

            string resultado = Calculadora.Operar(numeroUno, numeroDos, operador).ToString();

            return resultado;
        }

        /// <summary>
        /// Borra todos los datos que posee cada elemento.
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperador.Text = "";
            this.lblResultado.Text = "";
        }
        #endregion       
    }
}
