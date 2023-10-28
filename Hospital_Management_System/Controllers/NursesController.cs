using HMS_BLL.Dtos;
using HMS_BLL.Services.Interfaces;
using HMS_DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NursesController : ControllerBase
    {
        private readonly IGenericService<NurseDto, Nurse> _nurseService;
        public readonly ILogger<NursesController> _logger;

        public NursesController(IGenericService<NurseDto, Nurse> nurseService, ILogger<NursesController> logger)
        {
            _nurseService = nurseService;
            _logger = logger;
        }

        [HttpGet("id")]
        public ActionResult<NurseDto> Get(int id)
        {
            var item = _nurseService.GetByIdAsync(id);
            _logger.Log(LogLevel.Information, $"{item.Id} has been requested.");
            return Ok(item);
        }
        [HttpGet]
        public ActionResult<NurseDto> Get()
        {
            var item = _nurseService.GetListAsync();
            _logger.Log(LogLevel.Information, $"Requested list count is: {item}");
            return Ok(item);
        }
        [HttpPost]
        public ActionResult<NurseDto> Save(NurseDto nurse)
        {
            var item = _nurseService.CreateAsync(nurse);
            _logger.Log(LogLevel.Information, $"{item} has been successfully added to the system with id: {item.Id}");
            return Ok(item);
        }
        [HttpPut]
        public ActionResult<NurseDto> Update(NurseDto nurse)
        {
            var item = _nurseService.UpdateAsync(nurse);
            _logger.Log(LogLevel.Warning, $"{item} under the id: {item.Id} has been updated.");
            return Ok(item);
        }
        [HttpDelete]
        public ActionResult<NurseDto> Delete(int id)
        {
            var item = _nurseService.DeleteAsync(id);
            _logger.Log(LogLevel.Critical, $"{item} with id: {item.Id} has been deleted from the system");
            return Ok(item);
        }
    }
}
