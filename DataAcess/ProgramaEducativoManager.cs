using DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProgramaEducativoManager
    {
        public static async Task<RespuestaConsulta<DataModel.ProgramaEducativo>> ModificarProgramaEducativoAsync(ProgramaEducativo _programaEducativo)
        {
            RespuestaConsulta<DataModel.ProgramaEducativo> respuestaConsulta = new RespuestaConsulta<DataModel.ProgramaEducativo>();
            DataModel.ProgramaEducativo profesor = null;
            using (var context = new DataModel.EntityDataModelContainer())
            {
                try
                {
                    //Falta agregar un atributo de NRC
                    ProgramaEducativo result = context.ProgramaEducativoSet.SingleOrDefault(b => b.Nombre == _programaEducativo.Nombre);
                    if (result != null)
                    {
                        result.Profesor = _programaEducativo.Profesor;
                        //Agregar los demas atributos si es que faltan
                        context.SaveChanges();

                        respuestaConsulta.Respuesta = _programaEducativo;
                        respuestaConsulta.ResultadoConsulta = ResultadoConsulta.Exitosa;
                    }
                    else
                    {
                        respuestaConsulta.ResultadoConsulta = ResultadoConsulta.EntidadNoEncontrada;
                    }
                }
                catch (InvalidOperationException)
                {
                    respuestaConsulta.ResultadoConsulta = ResultadoConsulta.OperacionInvalida;
                }
                catch (DbUpdateException)
                {
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

        public static async Task<RespuestaConsulta<DataModel.ProgramaEducativo>> AgregarProgramaEducativoAsync(ProgramaEducativo _programaEducativo)
        {
            RespuestaConsulta<DataModel.ProgramaEducativo> respuestaConsulta = new RespuestaConsulta<DataModel.ProgramaEducativo>();
            using (var context = new DataModel.EntityDataModelContainer())
            {
                try
                {
                    context.ProgramaEducativoSet.Add(_programaEducativo);
                    context.SaveChanges();
                }
                catch (InvalidOperationException)
                {
                    respuestaConsulta.ResultadoConsulta = ResultadoConsulta.OperacionInvalida;
                }
                catch (DbUpdateException)
                {
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

        public static async Task<RespuestaConsulta<DataModel.ProgramaEducativo>> EliminarProgramaEducativoAsync(ProgramaEducativo _programaEducativo)
        {
            RespuestaConsulta<DataModel.ProgramaEducativo> respuestaConsulta = new RespuestaConsulta<DataModel.ProgramaEducativo>();
            using (var context = new DataModel.EntityDataModelContainer())
            {
                try
                {
                    context.Entry(_programaEducativo).State = EntityState.Deleted;
                    await context.SaveChangesAsync();
                }
                catch (InvalidOperationException)
                {
                    respuestaConsulta.ResultadoConsulta = ResultadoConsulta.OperacionInvalida;
                }
                catch (DbUpdateException)
                {
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

        public static async Task<RespuestaConsulta<List<ExperienciaEducativa>>> RecuperarExperienciasEducativasPorLicenciaturaAsync(String _licenciatura)
        {
            RespuestaConsulta<List<ExperienciaEducativa>> respuestaConsulta = new RespuestaConsulta<List<ExperienciaEducativa>>();
            using (var context = new DataModel.EntityDataModelContainer())
            {
                try
                {
                    List<ExperienciaEducativa> programasEducativos = new List<ExperienciaEducativa>();
                    programasEducativos = await context.ExperienciaEducativaSet.
                        Where(p => p.ProgramaEducativo.Equals(_licenciatura)).ToListAsync();

                    respuestaConsulta.Respuesta = programasEducativos;
                }
                catch (InvalidOperationException)
                {
                    respuestaConsulta.ResultadoConsulta = ResultadoConsulta.OperacionInvalida;
                }
                catch (DbUpdateException)
                {
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

        public static async Task<RespuestaConsulta<List<ProgramaEducativo>>> RecuperarLicenciaturasAsync()
        {
            RespuestaConsulta<List<ProgramaEducativo>> respuestaConsulta = new RespuestaConsulta<List<ProgramaEducativo>>();
            using (var context = new DataModel.EntityDataModelContainer())
            {
                try
                {
                    List<ProgramaEducativo> programasEducativos = new List<ProgramaEducativo>();
                    programasEducativos = await context.ProgramaEducativoSet.
                        Distinct().
                        ToListAsync();

                    respuestaConsulta.Respuesta = programasEducativos;
                }
                catch (InvalidOperationException)
                {
                    respuestaConsulta.ResultadoConsulta = ResultadoConsulta.OperacionInvalida;
                }
                catch (DbUpdateException)
                {
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
