using APIRestTraining.Model.Colegio;
using APIRestTraining.Model.Generales;
using APIRestTraining.Negocio.Colegio;
using Microsoft.AspNetCore.Mvc;

namespace APIRestTraining.API.Controllers
{
    [ApiController]
    [Route("Colegio/api/Alumno")]
    public class AlumnoController : ControllerBase
    {
        private readonly IServicioAlumno _servicioAlumno;

        public AlumnoController(IServicioAlumno servicioAlumno) 
        {
            _servicioAlumno = servicioAlumno;
        }

        [HttpPost, Route("ObtenerAlumnos")]
        public async Task<Response> ObrenerAlumno(Alumno alumno)
        {
            Response response = await _servicioAlumno.ObtenerAlumnos(alumno);

            return response;
        }

        [HttpPost, Route("AgregarAlumnos")]
        public async Task<Response> AgregarAlumno(Alumno alumno)
        {
            Response response = await _servicioAlumno.AgregarAlumnos(alumno);

            return response;
        }

        [HttpGet, Route("ObtenerAlumnosFiltro")]
        public async Task<Response> ObrenerAlumnoFiltro(int? idAlumno = null, int? idCarrera = null)
        {
            Response response = await _servicioAlumno.ObtenerAlumnosFiltro(idCarrera);

            return response;
        }

        [HttpPut, Route("ActualizarAlumnosFiltro")]
        public async Task<Response> ActualizarAlumnoFiltro(Alumno alumno)
        {
            Response response = await _servicioAlumno.ActualizarAlumno(alumno);

            return response;
        }

    }
}
