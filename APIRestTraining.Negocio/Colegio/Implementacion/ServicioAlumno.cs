using APIRestTraining.Datos.Colegio;
using APIRestTraining.Datos.Colegio.Implementacion;
using APIRestTraining.Model.Colegio;
using APIRestTraining.Model.Generales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APIRestTraining.Negocio.Colegio.Implementacion
{
    public class ServicioAlumno : IServicioAlumno
    {
        private readonly IAlumnoDataMapper _alumnoDataMapper;
        public ServicioAlumno(IAlumnoDataMapper alumnoDataMapper)
        { 
            _alumnoDataMapper = alumnoDataMapper;
        }

        public async Task<Response> ObtenerAlumnos(Alumno alumno)
        {
            Response response = new Response {status = false, code =(int) HttpStatusCode.InternalServerError };

            List<Alumno> listaAlumnos = new List<Alumno>();

            try
            {
                listaAlumnos = await _alumnoDataMapper.ObtenerAlumno(alumno);

                if (!listaAlumnos.Any())
                {
                    response.code = (int)HttpStatusCode.NoContent;
                    response.status = false;

                    return response;
                }

                response.model = listaAlumnos;
                response.code = (int)HttpStatusCode.OK;
                response.status = true;
            }
            catch (Exception ex)
            {
                response.code = (int)HttpStatusCode.InternalServerError;
                response.message = ex.Message;
                response.status = false;
            }
            return response;
        }

        public async Task<Response> AgregarAlumnos(Alumno alumno)
        {
            Response response = new Response { status = false, code = (int)HttpStatusCode.InternalServerError };

            List<Alumno> listaAlumnos = new List<Alumno>();

            try
            {
               int Resultado = await _alumnoDataMapper.AgregarAlumno(alumno);

               listaAlumnos = await _alumnoDataMapper.ObtenerAlumnoFiltro();

                response.model = listaAlumnos;
                response.code = (int)HttpStatusCode.OK;
                response.status = true;
            }
            catch (Exception ex)
            {
                response.code = (int)HttpStatusCode.InternalServerError;
                response.message = ex.Message;
                response.status = false;
            }
            return response;
        }

        public async Task<Response> ObtenerAlumnosFiltro(int? idAlumno = null, int? idCarrera = null)
        {
            Response response = new Response { status = false, code = (int)HttpStatusCode.InternalServerError };

            List<Alumno> listaAlumnos = new List<Alumno>();

            try
            {
                listaAlumnos = await _alumnoDataMapper.ObtenerAlumnoFiltro(idAlumno ,idCarrera);



                if (!listaAlumnos.Any())
                {
                    response.code = (int)HttpStatusCode.NoContent;
                    response.status = false;

                    return response;
                }

                response.model = listaAlumnos;
                response.code = (int)HttpStatusCode.OK;
                response.status = true;
            }
            catch (Exception ex)
            {
                response.code = (int)HttpStatusCode.InternalServerError;
                response.message = ex.Message;
                response.status = false;
            }
            return response;
        }

        public async Task<Response> ActualizarAlumno(Alumno alumno)
        {
            Response response = new Response { status = false, code = (int)HttpStatusCode.InternalServerError };

            List<Alumno> listaAlumnos = new List<Alumno>();

            try
            {

                await _alumnoDataMapper.ActualizarAlumno(alumno);

                listaAlumnos = await _alumnoDataMapper.ObtenerAlumnoFiltro();

                if (!listaAlumnos.Any())
                {
                    response.code = (int)HttpStatusCode.NoContent;
                    response.status = false;

                    return response;
                }

                response.model = listaAlumnos;
                response.code = (int)HttpStatusCode.OK;
                response.status = true;

            }
            catch (Exception ex)
            {
                response.code = (int)HttpStatusCode.InternalServerError;
                response.message = ex.Message;
                response.status = false;
            }
            return response;
        }
    }
}
