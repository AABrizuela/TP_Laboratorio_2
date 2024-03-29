﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        #region Propiedades
        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }
        #endregion
        
        #region Constructores
        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="patente"></param>
        /// <param name="color"></param>
        public Leche(EMarca marca, string patente, ConsoleColor color)
            : this(marca, patente, color, ETipo.Entera)
        {
            
        }

        public Leche(EMarca marca, string patente, ConsoleColor color, ETipo tipo) : base(patente, marca, color)
        {
            this.tipo = tipo;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra el contenido del producto Leche
        /// </summary>
        /// <returns>Retorna un string con los datos de Leche</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias.ToString());            
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion

        #region Enumerado
        public enum ETipo { Entera, Descremada }
        public ETipo tipo;
        #endregion
    }
}
