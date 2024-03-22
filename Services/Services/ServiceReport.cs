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
        public Report getPersonReport(string identificacion, int idType)
        {
           return repository.getPersonReport(identificacion, idType);
        }
    }
}
