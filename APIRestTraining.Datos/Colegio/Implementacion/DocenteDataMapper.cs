using APIRestTraining.Model.Colegio;
using APIRestTraining.Model.Conexion;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRestTraining.Datos.Colegio.Implementacion
{
    public class DocenteDataMapper : IDocenteDataMapper
    {
        private readonly ConexionSQL _conexionSQL;
        private IDbConnection _connection;

        public DocenteDataMapper(ConexionSQL conexionSQL)
        {

            _conexionSQL = conexionSQL;
            _connection = _conexionSQL.CreateConnection();

        }

        public async Task<List<Docente>> ObtenerDocente(int? idDocente = null)
        {
            List<Docente> listaDocentes = new List<Docente>();

            DynamicParameters dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@idDocuentes");

            var result = await _connection.QueryAsync<Docente>("[dbo].[Docentes_SELECT]", dynamicParameters, commandType: CommandType.StoredProcedure);

            listaDocentes = result.ToList();

            return listaDocentes;

        }

        public async Task<int> AgregarDocente(Docente docente)
        {

            DynamicParameters dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@Nombre",docente.Nombre);
            dynamicParameters.Add("@Apellido", docente.Apellido);

            int result = Convert.ToInt32(await _connection.ExecuteScalarAsync("[dbo].[Docentes_INSERT]", dynamicParameters, commandType: CommandType.StoredProcedure));

            return result;

        }
    }
}
