using APIRestTraining.Datos.Colegio;
using APIRestTraining.Datos.Colegio.Implementacion;
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
    public class ServicioDocente : IServicioDocente
    {

        private readonly IDocenteDataMapper _docenteDataMapper;

        public ServicioDocente(IDocenteDataMapper docenteDataMapper)
        {
            _docenteDataMapper = docenteDataMapper;
        }

        public async Task<Response> ObtenerDocente(int? idDocente = null)
        {
            Response response = new Response { status = false, code = (int)HttpStatusCode.InternalServerError };

            List<Docente> listaDocentes = new List<Docente>();

            try
            {

                listaDocentes = await _docenteDataMapper.ObtenerDocente(idDocente);

                if (!listaDocentes.Any())
                {

                    response.code = (int)HttpStatusCode.NoContent;
                    response.status = false;

                    return response;
                }

                response.model = listaDocentes;
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

        public async Task<Response> AgregarDocente(Docente docente)
        {
            Response response = new Response { status = false, code = (int)HttpStatusCode.InternalServerError };

            List<Docente> listaDocentes = new List<Docente>();

            try
            {
                int resultado = await _docenteDataMapper.AgregarDocente(docente);

                listaDocentes = await _docenteDataMapper.ObtenerDocente();

                response.model = listaDocentes;
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

    }
}
