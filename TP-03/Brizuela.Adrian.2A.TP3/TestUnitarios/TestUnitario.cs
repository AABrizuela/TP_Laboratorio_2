using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Excepciones;
using EntidadesInstanciables;
using EntidadesAbstractas;

namespace TestUnitario
{
    [TestClass]
    public class TestUnitario
    {
        [TestMethod]
        public void ValidarNacionalidadInvalidaExcepcion()
        {
            try
            { 
                Alumno a1 = new Alumno(2, "lucas", "villalba", "23456578", Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion);//le ingreso un dni por debajo de la nacionalidad que tiene
                Assert.Fail("Deberia avisar que el dni es incorrecto de acuerdo a la nacionalidad");
                
            }
            catch(NacionalidadInvalidaException e)
            {
                Assert.IsTrue(true);
            }

        }

        [TestMethod]
         public void ValidarDniInvalidoExcepcion()
        {
            try
            {
                Alumno a1 = new Alumno(2, "lucas", "villalba", "asd", Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion);//le ingreso un dni con otro formato
                Assert.Fail("Deberia avisar que el dni es incorrecto de acuerdo al formato");
            }
            catch(DniInvalidoException e)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void ValidarNulidadenAtributos()
        {
            Universidad u1 = new Universidad();
            Alumno a1 = new Alumno(2, "lucas", "villalba", "91111111", Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion);
            Profesor p1 = new Profesor(5, "lopez", "gomez", "16353423", Persona.ENacionalidad.Argentino);

            Assert.IsNotNull(u1.Alumnos);
            Assert.IsNotNull(u1.Instructores);
            Assert.IsNotNull(u1.Jornadas);
            Assert.IsNotNull(a1);
            Assert.IsNotNull(p1);

        }

        [TestMethod]
        public void ValidarSiSeRepiteAlumno()
        {
            Universidad u = new Universidad();
            Alumno a1 = new Alumno(2, "jorge", "dominguez", "12345678", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno a2 = new Alumno(2, "jorge", "dominguez", "87654321", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            try
            {
                u += a1;
                u += a2;
                Assert.Fail("Tiene que indicar error ya que tienen el mismo legajo y son del mismo tipo");
            }
            catch(AlumnoRepetidoException e)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void ValidarValorNumerico()
        {
            Profesor p1 = new Profesor(5, "lopez", "gomez", "16353423", Persona.ENacionalidad.Argentino);
            Assert.IsInstanceOfType(p1.DNI, typeof(int));
        }

    }
}
