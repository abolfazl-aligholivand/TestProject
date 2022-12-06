using TestProject.Domain.DTO.UserDTO;
using TestProject.Domain.Helpers;

namespace TestProject.Services.IServices
{
    public interface IUserService
    {
        Task<ApiResponse<GetUserDTO>> GetUser(int UserId);
        Task<ApiResponse<IEnumerable<GetUserDTO>>> GetAllUsers();
        Task<ApiResponse<AddUserDTO>> AddUser(AddUserDTO user);
        Task<ApiResponse<AddUserDTO>> UpdateUser(AddUserDTO user);
        Task<ApiResponse<bool>> DeleteUser(int userId);
    }
}
