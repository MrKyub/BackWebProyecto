using APIRestTraining.Model.Colegio;
using APIRestTraining.Model.Generales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRestTraining.Negocio.Colegio
{
    public interface IServicioDocente
    {
        Task<Response> ObtenerDocente(int? idDocente = null);

        Task<Response> AgregarDocente(Docente docente);
    }
}
