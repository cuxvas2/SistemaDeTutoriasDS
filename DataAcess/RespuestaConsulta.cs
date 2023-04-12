using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public enum ResultadoConsulta
    {
        Exitosa,
        EntidadNoEncontrada,
        ErrorDeEscrituraLectura,
        ErrorConexion,
        OperacionInvalida,
        ErrorDesconocido
    }
    public class RespuestaConsulta<T>
    {
        public ResultadoConsulta ResultadoConsulta { get; set; }
        public T Respuesta { get; set; }
        public string MensajeExcepcion { get; set; }
    }
}
