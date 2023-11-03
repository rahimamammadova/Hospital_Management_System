using HMS_BLL.Dtos;
using HMS_BLL.Services.Interfaces;
using HMS_DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IGenericService<UserDto, User> _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IGenericService<UserDto, User> userservice, ILogger<UsersController> logger)
        {

            _userService = userservice;
            _logger = logger;
        }
        [HttpGet("id")]
        public ActionResult<UserDto> GetById(int id)
        {
            var item = _userService.GetByIdAsync(id);
            _logger.Log(LogLevel.Information, $"{item.Id} has been requested.");
            return Ok(item);
        }
        [HttpGet]
        public ActionResult<UserDto> Get()
        {
            var item = _userService.GetListAsync();
            _logger.Log(LogLevel.Information, $"Requested list count is: {item}");
            return Ok(item);
        }
        [HttpPost]
        public ActionResult<UserDto> Save(UserDto user)
        {
            var item = _userService.CreateAsync(user);
            _logger.Log(LogLevel.Information, $"{item} has been successfully added to the system with id: {item.Id}");
            return Ok(item);
        }
        [HttpPut]
        public ActionResult<UserDto> Update(UserDto user)
        {

            var item = _userService.UpdateAsync(user);
            _logger.Log(LogLevel.Warning, $"{item} under the id: {item.Id} has been updated.");
            return Ok(item);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var item = _userService.DeleteAsync(id);
            _logger.Log(LogLevel.Critical, $"{item} with id: {item.Id} has been deleted from the system");
            return Ok(item);
        }
    }
}
