using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;

namespace DataAccess
{
    public class EstudianteManager
    {
       
        // Agregar un nuevo estudiante a la base de datos   
        public static async Task<RespuestaConsulta<Estudiante>> AgregarEstudianteAsync(Estudiante estudiante)
        {
            RespuestaConsulta<Estudiante> respuestaConsulta = new RespuestaConsulta<Estudiante>();
            using (var context = new DataModel.EntityDataModelContainer())
            {                
                try
                {

                    int idProgramaEducativo = 1;
                    Profesor profesor = await ProfesorManager.BuscarProfesorPorNumeroDePersonalAsync("0000");
                    int idTutor = profesor.Id;
                    estudiante.ProgramaEducativo = context.ProgramaEducativoSet.Find(idProgramaEducativo);
                    estudiante.Tutor = context.ProfesorSet.Find(idTutor);
                    context.EstudianteSet.Add(estudiante);
                    await context.SaveChangesAsync();
                    respuestaConsulta.ResultadoConsulta = ResultadoConsulta.Exitosa;
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
                return respuestaConsulta;
            }
        }

        // Modificar un estudiante existente en la base de datos
        public static async Task ModificarEstudianteAsync(string matricula,string nombre, string apellidoPaterno,string apellidoMaterno,string correoPersonal, string correoInstitucional)
        {
            using (var context = new DataModel.EntityDataModelContainer())
            {
                
                var estudiante = await context.EstudianteSet
                        .Where(r => r.Matricula.Equals(matricula))
                        .FirstOrDefaultAsync();
                estudiante.Nombres = nombre;
                estudiante.ApellidoPaterno = apellidoPaterno;
                estudiante.ApellidoMaterno = apellidoMaterno;
                estudiante.CorreoPersonal = correoPersonal;
                estudiante.CorreoInstitucional = correoInstitucional;
                await context.SaveChangesAsync();
            }
        }

        // Eliminar un estudiante existente de la base de datos
        public static async Task<RespuestaConsulta<Estudiante>> EliminarEstudianteAsync(string matricula)
        {
            RespuestaConsulta<Estudiante> respuestaConsulta = new RespuestaConsulta<Estudiante>();
            using (var context = new DataModel.EntityDataModelContainer())
            {
                
                try
                {
                    var estudiante = await context.EstudianteSet
                        .Where(r => r.Matricula.Equals(matricula))
                        .FirstOrDefaultAsync();

                    if (estudiante != null)
                    {
                        context.EstudianteSet.Remove(estudiante);
                        await context.SaveChangesAsync();
                    }
                    respuestaConsulta.ResultadoConsulta = ResultadoConsulta.Exitosa;
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
                return respuestaConsulta;
            }
        }

        // Buscar un estudiante por matrícula
        public static async Task<Estudiante> BuscarEstudiantePorMatriculaAsync(string matricula)
        {
            using (var context = new DataModel.EntityDataModelContainer())
            {
                DataModel.Estudiante estudiante = null;
                estudiante = await context.EstudianteSet
                        .Where(r => r.Matricula.Equals(matricula))
                        .FirstOrDefaultAsync();
                return estudiante;   
            }
           
        }

        // Buscar todos los estudiantes
        public static async Task<List<Estudiante>> BuscarTodosLosEstudiantesAsync()
        {
            using (var context = new DataModel.EntityDataModelContainer())
            {
                return await context.EstudianteSet.ToListAsync();
            }
        }

        // Buscar estudiantes por programa educativo
        public static async Task<List<Estudiante>> BuscarEstudiantesPorProgramaEducativoAsync(string programaEducativo)
        {
            using (var context = new DataModel.EntityDataModelContainer())
            {
                return await context.EstudianteSet.Where(e => e.ProgramaEducativo.Nombre == programaEducativo).ToListAsync();
            }
        }
    }  
}

