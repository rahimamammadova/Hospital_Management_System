using HMS_BLL.Dtos;
using HMS_BLL.Services.Interfaces;
using HMS_DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalsController : ControllerBase
    {
        private readonly IGenericService<HospitalDto, Hospital> _hospitalService;
        public readonly ILogger<HospitalsController> _logger;

        public HospitalsController(IGenericService<HospitalDto, Hospital> hospitalService, ILogger<HospitalsController> logger)
        {
            _hospitalService = hospitalService;
            _logger = logger;
        }

        [HttpGet("id")]
        public ActionResult<HospitalDto> Get(int id)
        {
            var item = _hospitalService.GetByIdAsync(id);
            _logger.Log(LogLevel.Information, $"{item.Id} has been requested.");
            return Ok(item);
        }
        [HttpGet]
        public ActionResult<HospitalDto> Get()
        {
            var item = _hospitalService.GetListAsync();
            _logger.Log(LogLevel.Information, $"Requested list count is: {item}");
            return Ok(item);
        }
        [HttpPost]
        public ActionResult<HospitalDto> Save(HospitalDto hospital)
        {
            var item = _hospitalService.CreateAsync(hospital);
            _logger.Log(LogLevel.Information, $"{item} has been successfully added to the system with id: {item.Id}");
            return Ok(item); 
        }
        [HttpPut]
        public ActionResult<HospitalDto> Update(HospitalDto hospital)
        {
            var item = _hospitalService.UpdateAsync(hospital);
            _logger.Log(LogLevel.Warning, $"{item} under the id: {item.Id} has been updated.");
            return Ok(item);
        }
        [HttpDelete("id")]
        public ActionResult<HospitalDto> Delete(int id) {
            var item = _hospitalService.DeleteAsync(id);
            _logger.Log(LogLevel.Critical, $"{item} with id: {item.Id} has been deleted from the system");
            return Ok(item);
        }
    }
}
