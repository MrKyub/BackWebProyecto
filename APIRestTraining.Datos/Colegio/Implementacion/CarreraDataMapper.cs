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
    public class CarreraDataMapper : ICarreraDataMapper
    {

        private readonly ConexionSQL _conexionSQL;
        private IDbConnection _connection;

        public CarreraDataMapper(ConexionSQL conexionSQL)
        {

            _conexionSQL = conexionSQL;
            _connection = _conexionSQL.CreateConnection();

        }

        public async Task<List<Carrera>> ObtenerCarrera(int? idCarrera = null)
        {
            List<Carrera> listaCarreras = new List<Carrera>();

            DynamicParameters dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@idCarrera", idCarrera);

            var result = await _connection.QueryAsync<Carrera>("[dbo].[Carrera_SELECT]", dynamicParameters, commandType: CommandType.StoredProcedure);

            listaCarreras = result.ToList();

            return listaCarreras;

        }

        public async Task<int> AgregarCarrera(Carrera carrera)
        {

            DynamicParameters dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@Nombre", carrera.Nombre);

            int result = Convert.ToInt32(await _connection.ExecuteScalarAsync("[dbo].[Carrera_INSERT]", dynamicParameters, commandType: CommandType.StoredProcedure));

            return result;

        }

    }
}
