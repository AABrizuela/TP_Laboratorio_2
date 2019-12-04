using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Atributos
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        #endregion

        #region Propiedades
        public List<Paquete> Paquetes
        {
            get
            { return this.paquetes; }
            set
            { this.paquetes = value; }
        }
        #endregion

        #region Constructores
        public Correo()
        {
            paquetes = new List<Paquete>();
            mockPaquetes = new List<Thread>();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que guarda en una cadena todos los paquetes de un correo
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>string con datos de los paquetes de correo</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();
            if (elementos is Correo)
            {
                foreach (Paquete aux in ((Correo)elementos).Paquetes)
                {
                    sb.AppendFormat("{0} para {1} ({2})", aux.TrackingID, aux.DireccionEntrega,
                    aux.Estado.ToString());
                    sb.AppendLine();
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Metodo que cierra todos los hilos activos
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread aux in this.mockPaquetes)
            {
                if (aux.IsAlive)
                {
                    aux.Abort();
                }
            }
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Metodo que agrega paquetes en la lista de correo
        /// </summary>
        /// <param name="c">correo</param>
        /// <param name="p">pquete</param>
        /// <returns>correo con paquete agregado o no</returns>
        public static Correo operator +(Correo c, Paquete p)
        {

            foreach (Paquete aux in c.Paquetes)
            {
                if (aux == p)
                {
                    throw new TrackingIdRepetidoException("Paquete repetido");
                }
            }
            c.Paquetes.Add(p);
            Thread hilo = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(hilo);
            hilo.Start();

            return c;
        }
        #endregion
    }
}
