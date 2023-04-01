using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SistemaDeGestionDeTutorias;
using SistemaDeGestionDeTutorias.Utilidades;
namespace PruebasDeUnidad
{
    [TestClass]
    public class ValidadorCasosFallidos
    {
        [TestMethod]
        public void ValidadorEsApellidoNoValidoTest()
        {
            string casoPrueba1 = " ";
            string casoPrueba2 = "_______";
            string casoPrueba3 = "12345";
            string casoPrueba4 = "@";
            string casoPrueba5 = ".";
            Assert.IsFalse(Validador.EsApellidoValido(casoPrueba1));
            Assert.IsFalse(Validador.EsApellidoValido(casoPrueba2));
            Assert.IsFalse(Validador.EsApellidoValido(casoPrueba3));
            Assert.IsFalse(Validador.EsApellidoValido(casoPrueba4));
            Assert.IsFalse(Validador.EsApellidoValido(casoPrueba5));
        }
        [TestMethod]
        public void ValidadorEsPasswordNoValidoTest()
        {
            string casoPrueba1 = "a1g2n3i4zhircon.";
            string casoPrueba2 = "zXCxca67245";
            string casoPrueba3 = "ANONIMOUS24@";
            string casoPrueba4 = "?asd*1";
            Assert.IsFalse(Validador.EsPasswordValido(casoPrueba1));
            Assert.IsFalse(Validador.EsPasswordValido(casoPrueba2));
            Assert.IsFalse(Validador.EsPasswordValido(casoPrueba3));
            Assert.IsFalse(Validador.EsPasswordValido(casoPrueba4));
        }

        [TestMethod]
        public void ValidadorEsCorreoElectronicoNoValidoTest()
        {
            string casoPrueba1 = "@gmail.com";
            string casoPrueba2 = "602turogmail.com";
            string casoPrueba3 = "princesita23@hotmailcom";
            string casoPrueba4 = "zs20015687@estudiantes/mx";
            Assert.IsFalse(Validador.EsCorreoElectronicoValido(casoPrueba1));
            Assert.IsFalse(Validador.EsCorreoElectronicoValido(casoPrueba2));
            Assert.IsFalse(Validador.EsCorreoElectronicoValido(casoPrueba3));
            Assert.IsFalse(Validador.EsCorreoElectronicoValido(casoPrueba4));
        }

        [TestMethod]
        public void ValidadorEsCorreoInstitucionalEstudianteNOValidoTest()
        {
            string casoPrueba1 = "zs20015687@est.uv.mx";
            string casoPrueba2 = "Agnizahir@gmail.com";
            string casoPrueba3 = "zs21015687@profesores.uv.mx";
            string casoPrueba4 = "zs19015687@hotmail.mx";
            Assert.IsFalse(Validador.EsCorreoInstitucionalEstudianteValido(casoPrueba1));
            Assert.IsFalse(Validador.EsCorreoInstitucionalEstudianteValido(casoPrueba2));
            Assert.IsFalse(Validador.EsCorreoInstitucionalEstudianteValido(casoPrueba3));
            Assert.IsFalse(Validador.EsCorreoInstitucionalEstudianteValido(casoPrueba4));
        }
        [TestMethod]
        public void ValidadorEsCorreoElectronicoProfesorNoValidoTest()
        {
            string casoPrueba1 = "zs20015687@estudiantes.uv.mx";
            string casoPrueba2 = "zs15027898@gmail.com";
            string casoPrueba3 = "zs21015687@hotmail.com";
            string casoPrueba4 = "profesores.uv.mx";
            Assert.IsFalse(Validador.EsCorreoInstitucionalProfesorValido(casoPrueba1));
            Assert.IsFalse(Validador.EsCorreoInstitucionalProfesorValido(casoPrueba2));
            Assert.IsFalse(Validador.EsCorreoInstitucionalProfesorValido(casoPrueba3));
            Assert.IsFalse(Validador.EsCorreoInstitucionalProfesorValido(casoPrueba4));
        }
    }
}
