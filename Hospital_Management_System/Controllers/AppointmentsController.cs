using HMS_BLL.Dtos;
using HMS_BLL.Services.Interfaces;
using HMS_DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IGenericService<AppointmentDto, Appointment> _appointmentService;
        public readonly ILogger<AppointmentsController> _logger;

        public AppointmentsController(IGenericService<AppointmentDto, Appointment> appointmentService, ILogger<AppointmentsController> logger)
        {
            _appointmentService = appointmentService;
            _logger = logger;
        }

        [HttpGet("id")]
        public ActionResult<AppointmentDto> Get(int id)
        {
            var item = _appointmentService.GetByIdAsync(id);
            _logger.Log(LogLevel.Information, $"{item.Id} has been requested.");
            return Ok(item);
        }
        [HttpGet]
        public ActionResult<AppointmentDto> Get()
        {
            var item = _appointmentService.GetListAsync();
            _logger.Log(LogLevel.Information, $"List is requested.");
            return Ok(item);
        }
        [HttpPost]
        public ActionResult<AppointmentDto> Save(AppointmentDto appointment)
        {
            var item = _appointmentService.UpdateAsync(appointment);
            _logger.Log(LogLevel.Information, $"{item} has been successfully added to the system with id: {item.Id}");
            return Ok(item);
        }
        [HttpPut]
        public ActionResult<AppointmentDto> Update(AppointmentDto appointment)
        {

            var item = _appointmentService.UpdateAsync(appointment);
            _logger.Log(LogLevel.Warning, $"{item} under the id: {item.Id} has been updated.");
            return Ok(item);
        }
        [HttpDelete("id")]
        public ActionResult<AppointmentDto> Delete(int id)
        {
            var item = _appointmentService.DeleteAsync(id);
            _logger.Log(LogLevel.Critical, $"{item} with id: {item.Id} has been deleted from the system");
            return Ok(item);
        }
    }
}
