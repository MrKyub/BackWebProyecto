using APIRestTraining.Model.Colegio;
using APIRestTraining.Model.Generales;
using APIRestTraining.Negocio.Colegio;
using Microsoft.AspNetCore.Mvc;

namespace APIRestTraining.API.Controllers
{

    [ApiController]
    [Route("Colegio/api/Carrera")]
    public class CarreraController : ControllerBase
    {

        private readonly IServicioCarrera _servicioCarrera;

        public CarreraController(IServicioCarrera servicioCarrera)
        {
            _servicioCarrera = servicioCarrera;
        }

        [HttpGet, Route("ObtenerCarreras")]
        public async Task<Response> ObtenerCarrera(int? idCarrera = null)
        {
            Response response = await _servicioCarrera.ObtenerCarrera(idCarrera);

            return response;
        }

        [HttpPost, Route("AgregarCarrera")]
        public async Task<Response> AgregarCarrera(Carrera carrera)
        {
            Response response = await _servicioCarrera.AgregarCarrera(carrera);

            return response;
        }

    }
}
