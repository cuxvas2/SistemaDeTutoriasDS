using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeGestionDeTutorias.Utilidades
{
    public class ManejadorDeExcepcionesEntity
    {
        //NOTA: No encontrar una entidad no esta considerada como una excepcion
        public static bool HayExcepcionesEntity<T>(DataAccess.RespuestaConsulta<T> _respuestaConsulta)
        {
            bool hayExcepciones = true;
            switch (_respuestaConsulta.ResultadoConsulta)
            {
                case DataAccess.ResultadoConsulta.ErrorConexion:
                    Utilidades.MensajeUsuario.MostrarErrorConexionBD();
                    break;
                case DataAccess.ResultadoConsulta.OperacionInvalida:
                    Utilidades.MensajeUsuario.MostrarOperacionNoValidaBD();
                    break;
                case DataAccess.ResultadoConsulta.ErrorDeEscrituraLectura:
                    Utilidades.MensajeUsuario.MostrarErrorEscrituraLecturaBD();
                    break;
                case DataAccess.ResultadoConsulta.ErrorDesconocido:
                    Utilidades.MensajeUsuario.MostrarErrorDesconocidoBD(_respuestaConsulta.MensajeExcepcion);
                    break;
                default:
                    hayExcepciones = false;
                    break;
            }
            return hayExcepciones;
        } 
    }
}
