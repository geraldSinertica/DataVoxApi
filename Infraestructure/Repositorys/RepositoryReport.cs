using Infraestructure.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositorys
{
    public class RepositoryReport : IRepositoryrReport
    {
        IConfiguration Configuration { get; }
         private string dsd { get; }
        public RepositoryReport(IConfiguration configuration)
        {
            Configuration = configuration;
            dsd = configuration.GetConnectionString("DataVoxConnection");
        }
        public Report getPersonReport(string username, string password, string identificacion, int idType, int queryType)
        {
            try
            {
                Report Persona = null;

               
                string cadena = Configuration.GetConnectionString("DataVoxConnection");
                using (SqlConnection connection = new SqlConnection(cadena))
                {
                    connection.Open();

                    using (var command = new SqlCommand("[dbo].[ConsultaPersonaFisica]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@Usuario", username));
                        command.Parameters.Add(new SqlParameter("@Password", password));
                        command.Parameters.Add(new SqlParameter("@Identificacion", identificacion));
                        command.Parameters.Add(new SqlParameter("@TipoIdentificacion", idType));
                        command.Parameters.Add(new SqlParameter("@TipoQuery", queryType));
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Persona = new Report
                                {
                                    Reporte = reader.GetString(0)

                                };
                               
                            }
                        }
                    }
                }

                return Persona;

            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
