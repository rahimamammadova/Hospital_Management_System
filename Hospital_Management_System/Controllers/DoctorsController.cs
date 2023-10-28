using HMS_BLL.Dtos;
using HMS_BLL.Services.Interfaces;
using HMS_DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IGenericService<DoctorDto, Doctor> _doctorService;
        public readonly ILogger<DoctorsController> _logger;

        public DoctorsController(IGenericService<DoctorDto, Doctor> doctorService, ILogger<DoctorsController> logger)
        {
            _doctorService = doctorService;
            _logger = logger;
        }

        [HttpGet("id")]
        public ActionResult<DoctorDto> GetById(int id)
        {
            var item = _doctorService.GetByIdAsync(id);
            _logger.Log(LogLevel.Information, $"{item.Id} has been requested.");
            return Ok(item);
        }
        [HttpGet]
        public ActionResult<DoctorDto> Get()
        {
            var item = _doctorService.GetListAsync();
            _logger.Log(LogLevel.Information, $"List is requested.");
            return Ok(item);
        }
        [HttpPost]
        public ActionResult<DoctorDto> Save(DoctorDto doctor)
        {
            var item = _doctorService.CreateAsync(doctor);
            _logger.Log(LogLevel.Information, $"{item} has been successfully added to the system with id: {item.Id}");
            return Ok(item);
        }
        [HttpPut]
        public ActionResult<DoctorDto> Update(DoctorDto doctor)
        {
            var item = _doctorService.UpdateAsync(doctor);
            _logger.Log(LogLevel.Warning, $"{item} under the id: {item.Id} has been updated.");
            return Ok(item);
        }
        [HttpDelete("id")]
        public ActionResult<DoctorDto> Delete(int id)
        {
            var item = _doctorService.DeleteAsync(id);
            _logger.Log(LogLevel.Critical, $"{item} with id: {item.Id} has been deleted from the system");
            return Ok(item);

        }
    }
}
