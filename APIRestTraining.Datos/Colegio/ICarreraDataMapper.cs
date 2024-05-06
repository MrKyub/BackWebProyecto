using APIRestTraining.Model.Colegio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRestTraining.Datos.Colegio
{
    public interface ICarreraDataMapper
    {

        public Task<List<Carrera>> ObtenerCarrera(int? idCarrera = null);

        public Task<int> AgregarCarrera(Carrera carrera);

    }
}
