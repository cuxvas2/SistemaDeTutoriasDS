﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProfesorManager
    {

        // Agregar un nuevo Profesor a la base de datos   
        public static async Task<RespuestaConsulta<Profesor>> AgregarProfesorAsync(Profesor profesor)
        {
            RespuestaConsulta<Profesor> respuestaConsulta = new RespuestaConsulta<Profesor>();
            using (var context = new DataModel.EntityDataModelContainer())
            {
                try
                {
                    int idExperiencia = 3;
                    profesor.ExperienciaEducativa = context.ExperienciaEducativaSet.Find(idExperiencia);
                    profesor.Password = "password";
                    context.ProfesorSet.Add(profesor);
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

        // Modificar un Profesor existente en la base de datos
        public static async Task ModificarProfesorAsync(string numeroDePersonal, string nombre, string apellidoPaterno, string apellidoMaterno, string correoPersonal, string correoInstitucional, string esTutor, string esCoordinador, bool esJefe)
        {
            using (var context = new DataModel.EntityDataModelContainer())
            {

                var Profesor = await context.ProfesorSet
                        .Where(r => r.NumeroDePersonal.Equals(numeroDePersonal))
                        .FirstOrDefaultAsync();
                Profesor.Nombres = nombre;
                Profesor.ApellidoPaterno = apellidoPaterno;
                Profesor.ApellidoMaterno = apellidoMaterno;
                Profesor.CorreoPersonal = correoPersonal;
                Profesor.CorreoInstitucional = correoInstitucional;
                Profesor.EsTutor = esTutor;
                Profesor.EsCoordinador = esCoordinador;
                Profesor.EsJefeCarrera = esJefe;
                await context.SaveChangesAsync();
            }
        }

        // Eliminar un Profesor existente de la base de datos
        public static async Task<RespuestaConsulta<Profesor>> EliminarProfesorAsync(string numeroDePersonal)
        {
            RespuestaConsulta<Profesor> respuestaConsulta = new RespuestaConsulta<Profesor>();
            using (var context = new DataModel.EntityDataModelContainer())
            {

                try
                {
                    var Profesor = await context.ProfesorSet
                        .Where(r => r.NumeroDePersonal.Equals(numeroDePersonal))
                        .FirstOrDefaultAsync();

                    if (Profesor != null)
                    {
                        context.ProfesorSet.Remove(Profesor);
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

        // Buscar un Profesor por numero de personal
        public static async Task<Profesor> BuscarProfesorPorNumeroDePersonalAsync(string numeroDePersonal)
        {
            using (var context = new DataModel.EntityDataModelContainer())
            {
                DataModel.Profesor Profesor = null;
                Profesor = await context.ProfesorSet
                        .Where(r => r.NumeroDePersonal.Equals(numeroDePersonal))
                        .FirstOrDefaultAsync();
                return Profesor;
            }

        }

        // Buscar todos los Profesors
        public static async Task<List<Profesor>> BuscarTodosLosProfesorsAsync()
        {
            using (var context = new DataModel.EntityDataModelContainer())
            {
                return await context.ProfesorSet.Where(p => p.NumeroDePersonal != "0000").ToListAsync();
            }
        }

        // Buscar un Profesor por si es tutor
        public static async Task<List<Profesor>> BuscarProfesorPorSiEsTutorAsync()
        {
            using (var context = new DataModel.EntityDataModelContainer())
            {
                return await context.ProfesorSet.Where(p => p.NumeroDePersonal != "0000" && p.EsTutor.Equals("true")).ToListAsync();
            }

        }

    }
}
