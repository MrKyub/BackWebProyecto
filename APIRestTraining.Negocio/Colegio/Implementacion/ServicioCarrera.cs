using APIRestTraining.Datos.Colegio;
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
    public class ServicioCarrera : IServicioCarrera
    {

        private readonly ICarreraDataMapper _carreraDataMapper;

        public ServicioCarrera(ICarreraDataMapper carreraDataMapper)
        {
            _carreraDataMapper = carreraDataMapper;
        }

        public async Task<Response> ObtenerCarrera(int? idCarrera = null)
        {
            Response response = new Response { status = false, code = (int)HttpStatusCode.InternalServerError };

            List<Carrera> listaCarreras = new List<Carrera>();

            try
            {

                listaCarreras = await _carreraDataMapper.ObtenerCarrera(idCarrera);

                if (!listaCarreras.Any())
                {

                    response.code = (int)HttpStatusCode.NoContent;
                    response.status = false;

                    return response;
                }

                response.model = listaCarreras;
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

        public async Task<Response> AgregarCarrera(Carrera carrera)
        {
            Response response = new Response { status = false, code = (int)HttpStatusCode.InternalServerError };

            List<Carrera> listaCarreras = new List<Carrera>();

            try
            {
                int resultado = await _carreraDataMapper.AgregarCarrera(carrera);

                listaCarreras = await _carreraDataMapper.ObtenerCarrera();

                response.model = listaCarreras;
                response.code = (int)HttpStatusCode.OK;
                response.status = true;

            }
            catch(Exception ex)
            {

                response.code = (int)HttpStatusCode.InternalServerError;
                response.message = ex.Message;
                response.status = false;

            }

            return response;
        }
    }
}
