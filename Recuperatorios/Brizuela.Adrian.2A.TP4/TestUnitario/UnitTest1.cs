using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Entidades;

namespace TestUnitario
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ListaCorreoInstanciada()
        {
            Correo c = new Correo();
            Assert.IsNotNull(c.Paquetes);
        }

        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void PaqueteRepetido()
        {
            Correo c = new Correo();

            c += new Paquete("Calle 405 numero 2567", "222-888-4444");
            c += new Paquete("Calle 304 numero 358", "222-888-4444");
        }
    }
}
