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
        public async Task<IActionResult> GetPersonReport(string username, string password, string identification, int idType, int queryType)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                IServiceReport service = new ServiceReport(_configuration);

                var watch = System.Diagnostics.Stopwatch.StartNew();
                Report report = service.getPersonReport(username, password, identification, idType, queryType);
                watch.Stop();

                if (report == null)
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Message = "Asset no encontrado, verifique el id. Duración del procesamiento: " + watch.ElapsedMilliseconds + "ms";
                }
                else
                {
                    response.StatusCode = (int)HttpStatusCode.OK;
                    response.Message = "Reporte encontrado. Duración del procesamiento: " + watch.ElapsedMilliseconds + "ms";
                    response.Data = report;
                }

                return Ok(response);
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