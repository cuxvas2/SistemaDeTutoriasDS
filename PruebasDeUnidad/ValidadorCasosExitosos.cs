using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SistemaDeGestionDeTutorias;
using SistemaDeGestionDeTutorias.Utilidades;
namespace PruebasDeUnidad
{
    [TestClass]
    public class ValidadorCasosExitosos
    {
        [TestMethod]
        public void ValidadorEsApellidoValidoTest()
        {
            string casoPrueba1 = "Yañez";
            string casoPrueba2 = "Vences";
            string casoPrueba3 = "Torres";
            string casoPrueba4 = "Medina";
            string casoPrueba5 = "Cabeza de vaca";
            string casoPrueba6 = "De la rosa";
            Assert.IsTrue(Validador.EsApellidoValido(casoPrueba1));
            Assert.IsTrue(Validador.EsApellidoValido(casoPrueba2));
            Assert.IsTrue(Validador.EsApellidoValido(casoPrueba3));
            Assert.IsTrue(Validador.EsApellidoValido(casoPrueba4));
            Assert.IsTrue(Validador.EsApellidoValido(casoPrueba5));
            Assert.IsTrue(Validador.EsApellidoValido(casoPrueba6));
        }
        [TestMethod]
        public void ValidadorEsPasswordValidoTest()
        {
            string casoPrueba1 = "A1G2n3i4zhircon.";
            string casoPrueba2 = "zXCxca67.@245";
            string casoPrueba3 = "Anonimous24@";
            string casoPrueba4 = "ª?aAsd*1";
            Assert.IsTrue(Validador.EsPasswordValido(casoPrueba1));
            Assert.IsTrue(Validador.EsPasswordValido(casoPrueba2));
            Assert.IsTrue(Validador.EsPasswordValido(casoPrueba3));
            Assert.IsTrue(Validador.EsPasswordValido(casoPrueba4));
        }
        [TestMethod]
        public void ValidadorEsCorreoElectronicoValidoTest()
        {
            string casoPrueba1 = "agnizahir@gmail.com";
            string casoPrueba2 = "602turo@gmail.com";
            string casoPrueba3 = "princesita23@hotmail.com";
            string casoPrueba4 = "zs20015687@estudiantes.uv.mx";
            Assert.IsTrue(Validador.EsCorreoElectronicoValido(casoPrueba1));
            Assert.IsTrue(Validador.EsCorreoElectronicoValido(casoPrueba2));
            Assert.IsTrue(Validador.EsCorreoElectronicoValido(casoPrueba3));
            Assert.IsTrue(Validador.EsCorreoElectronicoValido(casoPrueba4));
        }
        [TestMethod]
        public void ValidadorEsCorreoInstitucionalEstudianteValidoTest()
        {
            string casoPrueba1 = "zs20015687@estudiantes.uv.mx";
            string casoPrueba2 = "zs15027898@estudiantes.uv.mx";
            string casoPrueba3 = "zs21015687@estudiantes.uv.mx";
            string casoPrueba4 = "zs19015687@estudiantes.uv.mx";
            Assert.IsTrue(Validador.EsCorreoInstitucionalEstudianteValido(casoPrueba1));
            Assert.IsTrue(Validador.EsCorreoInstitucionalEstudianteValido(casoPrueba2));
            Assert.IsTrue(Validador.EsCorreoInstitucionalEstudianteValido(casoPrueba3));
            Assert.IsTrue(Validador.EsCorreoInstitucionalEstudianteValido(casoPrueba4));
        }
        [TestMethod]
        public void ValidadorEsCorreoElectronicoProfesorValidoTest()
        {
            string casoPrueba1 = "zs20015687@profesores.uv.mx";
            string casoPrueba2 = "zs15027898@profesores.uv.mx";
            string casoPrueba3 = "zs21015687@profesores.uv.mx";
            string casoPrueba4 = "zs19015687@profesores.uv.mx";
            Assert.IsTrue(Validador.EsCorreoInstitucionalProfesorValido(casoPrueba1));
            Assert.IsTrue(Validador.EsCorreoInstitucionalProfesorValido(casoPrueba2));
            Assert.IsTrue(Validador.EsCorreoInstitucionalProfesorValido(casoPrueba3));
            Assert.IsTrue(Validador.EsCorreoInstitucionalProfesorValido(casoPrueba4));
        }
    }
}
