using MiWebApi.Models;
using System.Data;
using System.Data.SqlClient;
namespace MiWebApi.Data
{
    public class EmpleadoData
    {
        private readonly string conexion;

        public EmpleadoData(IConfiguration configuration)
        {
            conexion = configuration.GetConnectionString("CadenaSQL")!;
        }
    }
}
