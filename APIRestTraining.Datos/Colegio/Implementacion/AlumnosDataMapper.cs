using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIRestTraining.Model.Colegio;
using APIRestTraining.Model.Conexion;
using Dapper;

namespace APIRestTraining.Datos.Colegio.Implementacion
{
    public class AlumnosDataMapper : IAlumnoDataMapper
    {
        private readonly ConexionSQL _conexionSQL;
        private IDbConnection _connection;
        public AlumnosDataMapper(ConexionSQL conexionSQL) 
        {
            _conexionSQL = conexionSQL;
            _connection = _conexionSQL.CreateConnection();


        }

        public async Task<List<Alumno>> ObtenerAlumno(Alumno alumno)
        {
            List<Alumno> listaAlumnos = new List<Alumno>();

            listaAlumnos = _connection.Query<Alumno>("Select * from [dbo].[Alumnos]").ToList();


            return listaAlumnos;
        }

        public async Task<int> AgregarAlumno(Alumno alumno)
        {
            //mandar parametros a store Procedure
            DynamicParameters dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@Nombre", alumno.Nombre);
            dynamicParameters.Add("@Apellido", alumno.apellido);
            dynamicParameters.Add("@F_Nacimiento", alumno.f_Nacimiento);
            dynamicParameters.Add("@idCarrera", alumno.IdCarrera);
            dynamicParameters.Add("@Telefono", alumno.telefono);

            int result = Convert.ToInt32(await _connection.ExecuteScalarAsync("[dbo].[Alumnos_INSERT]", dynamicParameters, commandType: CommandType.StoredProcedure));

            return result;
        }

        public async Task<List<Alumno>> ObtenerAlumnoFiltro(int? idAlumno = null, int? idCarrera = null)
        {
            List<Alumno> listaAlumnos = new List<Alumno>();

            DynamicParameters dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@idAlumno", idAlumno);
            dynamicParameters.Add("@idCarrera", idCarrera);

            var result = await _connection.QueryAsync<Alumno>("[dbo].[Alumnos_SELECT]", dynamicParameters, commandType: CommandType.StoredProcedure);

            listaAlumnos = result.ToList();

            return listaAlumnos;
        }

        public async Task<bool> ActualizarAlumno(Alumno alumno)
        {

            DynamicParameters dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@idAlumno", alumno.IdAlumno);
            dynamicParameters.Add("@Nombre", alumno.Nombre);
            dynamicParameters.Add("@Apellido", alumno.apellido);
            dynamicParameters.Add("@F_Nacimiento", alumno.f_Nacimiento);
            dynamicParameters.Add("@idCarrera", alumno.IdCarrera);
            dynamicParameters.Add("@Telefono", alumno.telefono);

            await _connection.ExecuteScalarAsync("[dbo].[Alumnos_UPDATE]", dynamicParameters, commandType: CommandType.StoredProcedure);

            return true;

        }

    }
}
