﻿using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface IServiceReport
    {
        Report getPersonReport(string user, string password, string identificacion,int idType, int queryType);
    }
}
