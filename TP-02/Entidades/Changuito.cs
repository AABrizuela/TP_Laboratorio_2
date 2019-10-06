using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Changuito
    {
        #region Atributos
        private List<Producto> productos;
        private int espacioDisponible;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor privado que instacia la lista del atributo productos
        /// </summary>
        private Changuito()
        {
            this.productos = new List<Producto>();
        }
        /// <summary>
        /// Constructor que inicializa el espacio disponible
        /// </summary>
        /// <param name="espacioDisponible">Atributo de espacio disponible</param>
        public Changuito(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el Changuito y TODOS los Productos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Changuito.Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Mostrar(Changuito c, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", c.productos.Count, c.espacioDisponible);
            sb.AppendLine("");
            foreach (Producto prod in c.productos)
            {
                switch (tipo)
                {
                    case ETipo.Snacks:
                        if(prod is Snacks)
                        sb.AppendLine(prod.Mostrar());
                        break;
                    case ETipo.Dulce:
                        if(prod is Dulce)
                        sb.AppendLine(prod.Mostrar());
                        break;
                    case ETipo.Leche:
                        if(prod is Leche)
                        sb.AppendLine(prod.Mostrar());
                        break;
                    default:
                        sb.AppendLine(prod.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Changuito operator +(Changuito c, Producto p)
        {
            bool flag = false;
            if(!Object.Equals(c, null) && !Object.Equals(p, null))
            {
                foreach (Producto v in c.productos)
                {
                    if (v == p)
                    {
                        flag = true;
                    }
                }

                if (flag == false && c.productos.Count + 1 <= c.espacioDisponible)
                {
                    c.productos.Add(p);
                }
            }            
            
            return c;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Changuito operator -(Changuito c, Producto p)
        {
            foreach (Producto v in c.productos)
            {
                if (v == p)
                {
                    c.productos.Remove(p);
                    break;
                }
            }

            return c;
        }
        #endregion

        #region Enumeradores
        public enum ETipo
        {
            Dulce, Leche, Snacks, Todos
        }
        #endregion
    }
}
