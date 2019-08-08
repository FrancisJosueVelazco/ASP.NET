using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Capa_Datos
{
    // IMPORTAR SYSTEM.CONFIGURATION Y REFERENCIAR
    public class Conexion
    {
        public SqlConnection cadena = new SqlConnection(
            ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);

    }
}
