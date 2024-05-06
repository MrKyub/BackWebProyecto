using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRestTraining.Model.Conexion
{
    public class ConexionSQL
    {
        private ConnectionString conenctionString;

        public ConexionSQL(IOptionsMonitor<ConnectionString> optionsMonitor)
        {
            conenctionString = optionsMonitor.CurrentValue;
        }

        public IDbConnection CreateConnection() => new SqlConnection(conenctionString.sqlConnection);
        /*{
            var coneccion = new SqlConnection(conenctionString.sqlConnection);
            return coneccion;
        }*/
    }
}
