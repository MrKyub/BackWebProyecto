using APIRestTraining.Model.Colegio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRestTraining.Datos.Colegio
{
    public interface IDocenteDataMapper
    {
        public Task<List<Docente>> ObtenerDocente(int? idDocente = null);

        public Task<int> AgregarDocente(Docente docente);

    }
}
