using HMS_BLL.Dtos;
using HMS_BLL.Services.Interfaces;
using HMS_DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IGenericService<PatientDto, Patient> _patientService;
        public readonly ILogger<PatientsController> _logger;

        public PatientsController(IGenericService<PatientDto, Patient> patientService, ILogger<PatientsController> logger)
        {
            _patientService = patientService;
            _logger = logger;
        }
        [HttpGet("id")]
        public ActionResult<PatientDto> GetById(int id)
        {
            var item = _patientService.GetByIdAsync(id);
            _logger.Log(LogLevel.Information, $"{item} has been requested.");
            return Ok(item);
        }
        [HttpGet]
        public ActionResult<PatientDto> Get()
        {
            var item = _patientService.GetListAsync();
            _logger.Log(LogLevel.Information, $"Requested list count is: {item}");
            return Ok(item);
        }
        [HttpPost]
        public ActionResult<PatientDto> Save(PatientDto patient)
        {
            var item = _patientService.CreateAsync(patient);
            _logger.Log(LogLevel.Information, $"{item} has been successfully added to the system with id: {item.Id}");
            return Ok(item);
        }
        [HttpPut]
        public ActionResult<PatientDto> Update(PatientDto patient)
        {
            var item = _patientService.UpdateAsync(patient);
            _logger.Log(LogLevel.Warning, $"{item} under the id: {item.Id} has been updated.");
            return Ok(item);
        }
        [HttpDelete]
        public ActionResult<PatientDto> Delete(int id)
        {

            var item = _patientService.DeleteAsync(id);
            _logger.Log(LogLevel.Critical, $"{item} with id: {item.Id} has been deleted from the system");
            return Ok(item);
        }
    }
}
