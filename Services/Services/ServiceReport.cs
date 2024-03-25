using Infraestructure.Models;
using Infraestructure.Repositorys;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ServiceReport : IServiceReport
    {
        private IRepositoryrReport repository;
        
        public ServiceReport(IConfiguration configuration) { 
            repository= new RepositoryReport(configuration);
        }  
        public Report getPersonReport(string user, string password, string identificacion, int idType, int queryType)
        {
           return repository.getPersonReport(user, password,identificacion, idType, queryType);
        }
    }
}
