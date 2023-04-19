using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasDeUnidad
{
    [TestClass]
    public class MenejadorDeDocumentosCasosExitosos
    {
        [TestMethod]
        public void ExtraerEstudiantesDeDocumentoExcel()
        {
            List<DataModel.Estudiante> estudiantes = DataAccess.ManejadorDeDocumentos.ExtraerEstudiantesDesdeDocumentoExcel("c:/users/acer/documents/Estudiantes.xlsx");
            Assert.IsNotNull(estudiantes);
        }
    }
}
