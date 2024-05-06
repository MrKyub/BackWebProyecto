using APIRestTraining.Model.Colegio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRestTraining.Datos.Colegio
{
    public interface IAlumnoDataMapper
    {
        public Task<List<Alumno>> ObtenerAlumno(Alumno alumno);

        public Task<List<Alumno>> ObtenerAlumnoFiltro(int? idAlumno = null, int? idCarrera = null);

        Task<int> AgregarAlumno(Alumno alumno);

        Task<bool> ActualizarAlumno(Alumno alumno);
    }
}
