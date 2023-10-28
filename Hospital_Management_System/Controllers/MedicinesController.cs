using HMS_BLL.Dtos;
using HMS_BLL.Services.Interfaces;
using HMS_DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : ControllerBase
    {
        private readonly IGenericService<MedicineDto, Medicine> _medicineService;
        public readonly ILogger<MedicinesController> _logger;

        public MedicinesController(IGenericService<MedicineDto, Medicine> medicineService, ILogger<MedicinesController> logger)
        {
            _medicineService = medicineService;
            _logger = logger;
        }

        [HttpGet("id")]
        public ActionResult<MedicineDto> Get(int id)
        {
            var item = _medicineService.GetByIdAsync(id);
            _logger.Log(LogLevel.Information, $"{item.Id} has been requested.");
            return Ok(item);

        }
        [HttpGet]
        public ActionResult<MedicineDto> Get()
        {
            var item = _medicineService.GetListAsync();
            _logger.Log(LogLevel.Information, $"Requested list count is: {item}");
            return Ok(item);
        }
        [HttpPost]
        public ActionResult<MedicineDto> Save(MedicineDto medicine) {
            var item = _medicineService.CreateAsync(medicine);
            _logger.Log(LogLevel.Information, $"{item} has been successfully added to the system with id: {item.Id}");
            return Ok(item);
        }
        [HttpPut]
        public ActionResult<MedicineDto> Update(MedicineDto medicine) {
            var item = _medicineService.UpdateAsync(medicine);
            _logger.Log(LogLevel.Warning, $"{item} under the id: {item.Id} has been updated.");
            return Ok(item);
        }
        [HttpDelete]
        public ActionResult<MedicineDto> Delete(int id) {
            var item = _medicineService.DeleteAsync(id);
            _logger.Log(LogLevel.Critical, $"{item} with id: {item.Id} has been deleted from the system");
            return Ok(item);
        }
    }
}
