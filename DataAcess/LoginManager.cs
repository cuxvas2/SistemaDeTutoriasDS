using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity.Core;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;

namespace DataAccess
{
    public class LoginManager
    {
        public static async Task< RespuestaConsulta<DataModel.Administrador>> BuscarAministradorPorUsuarioAsync(string _usuario)
        {
            RespuestaConsulta<DataModel.Administrador> respuestaConsulta = new RespuestaConsulta<DataModel.Administrador>();
            DataModel.Administrador administrador = null;
            using (var context = new DataModel.EntityDataModelContainer())
            {
                try
                {
                    administrador = await context.AdministradorSet
                        .Where(r => r.Usuario.Equals(_usuario))
                        .FirstOrDefaultAsync();
                    if (administrador == null) 
                    {
                        respuestaConsulta.ResultadoConsulta = ResultadoConsulta.EntidadNoEncontrada;
                    }
                    else
                    {
                        respuestaConsulta.Respuesta = administrador;
                        respuestaConsulta.ResultadoConsulta = ResultadoConsulta.Exitosa;
                    }   
                }
                catch (InvalidOperationException)
                {
                    respuestaConsulta.ResultadoConsulta = ResultadoConsulta.OperacionInvalida;
                }
                catch (DbUpdateException)
                {
                    // Error al actualizar la entidad en la base de datos
                    respuestaConsulta.ResultadoConsulta = ResultadoConsulta.ErrorDeEscrituraLectura;
                }
                catch (EntityException)
                {
                    respuestaConsulta.ResultadoConsulta = ResultadoConsulta.ErrorConexion;
                }
                catch (Exception ex)
                {
                    respuestaConsulta.ResultadoConsulta = ResultadoConsulta.ErrorDesconocido;
                    respuestaConsulta.MensajeExcepcion = ex.Message;
                }
            }
            return respuestaConsulta;
        }
    }
}
