using APIRestTraining.Model.Colegio;
using APIRestTraining.Model.Generales;
using APIRestTraining.Negocio.Colegio;
using Microsoft.AspNetCore.Mvc;

namespace APIRestTraining.API.Controllers
{

    [ApiController]
    [Route("Colegio/api/Docente")]
    public class DocenteController
    {

        private readonly IServicioDocente _servicioDocente;

        public DocenteController(IServicioDocente servicioDocente)
        {
            _servicioDocente = servicioDocente;
        }

        [HttpGet, Route("ObtenerDocentes")]
        public async Task<Response> ObtenerDocente(int? idDocente = null)
        {
            Response response = await _servicioDocente.ObtenerDocente(idDocente);

            return response;
        }

        [HttpPost, Route("AgregarDocente")]
        public async Task<Response> AgregarDocente(Docente docente)
        {
            Response response = await _servicioDocente.AgregarDocente(docente);

            return response;
        }

    }
}
