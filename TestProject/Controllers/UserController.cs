using Microsoft.AspNetCore.Mvc;
using TestProject.Domain.DTO.UserDTO;
using TestProject.Domain.Helpers;
using TestProject.Services.IServices;

namespace TestProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("Get")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<GetUserDTO>))]
        public async Task<IActionResult> GetUser(int userId)
        {
            var result = await _userService.GetUser(userId);
            return new Response<GetUserDTO>().ResponseSending(result);
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<IEnumerable<GetUserDTO>>))]
        public async Task<IActionResult> GetAllUser()
        {
            var result = await _userService.GetAllUsers();
            return new Response<IEnumerable<GetUserDTO>>().ResponseSending(result);
        }

        [HttpPost("AddUser")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<AddUserDTO>))]
        public async Task<IActionResult> AddUser([FromBody] AddUserDTO user)
        {
            var result = await _userService.AddUser(user);
            return new Response<AddUserDTO>().ResponseSending(result);
        }

        [HttpPut("UpdateUser")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<AddUserDTO>))]
        public async Task<IActionResult> UpdateUser([FromBody] AddUserDTO user)
        {
            var result = await _userService.UpdateUser(user);
            return new Response<AddUserDTO>().ResponseSending(result);
        }

        [HttpDelete("DeleteUser")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<bool>))]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var result = await _userService.DeleteUser(userId);
            return new Response<bool>().ResponseSending(result);
        }
    }
}
