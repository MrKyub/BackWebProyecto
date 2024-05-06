using APIRestTraining.Model.Colegio;
using APIRestTraining.Model.Generales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRestTraining.Negocio.Colegio
{
    public interface IServicioCarrera
    {

        Task<Response> ObtenerCarrera(int? idCarrera = null);

        Task<Response> AgregarCarrera(Carrera carrera);

    }
}
