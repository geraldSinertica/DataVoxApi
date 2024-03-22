using DataVoxAPI.Models;
using Infraestructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services;
using System.Net;

namespace DataVoxAPI.Controllers
{
    [Route("api/report")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ReportController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("PersonaFisica")]
        public async Task<IActionResult> GetPersonReport(string identification,int idType)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                IServiceReport service = new ServiceReport(_configuration);

                Report report =  service.getPersonReport(identification,idType);

                if (report == null)
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Message = "Asset no encontrado, verifique el id";
                }
                else
                {
                    response.StatusCode = (int)HttpStatusCode.OK;
                    response.Message = "Reporte encontrado";
                    response.Data = report;
                }

                return Ok(response.Data);
            }
            catch (Exception e)
            {
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                response.Message = e.Message;

                return StatusCode(response.StatusCode, response);
            }
        }
    }
}
