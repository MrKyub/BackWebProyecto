using APIRestTraining.Model.Colegio;
using APIRestTraining.Model.Generales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRestTraining.Negocio.Colegio
{
    public interface IServicioAlumno
    {
        Task<Response> ObtenerAlumnos(Alumno alumno);

        Task<Response> ObtenerAlumnosFiltro(int? idAlumno = null, int? idCarrera = null);

        Task<Response> AgregarAlumnos(Alumno alumno);

        Task<Response> ActualizarAlumno(Alumno alumno);

    }
}
