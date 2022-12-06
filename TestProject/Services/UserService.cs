using AutoMapper;
using TestProject.Domain.DTO.UserDTO;
using TestProject.Domain.Enums;
using TestProject.Domain.Helpers;
using TestProject.Domain.Model;
using TestProject.Domain.Repository.IRepository;
using TestProject.Services.IServices;

#nullable disable

namespace TestProject.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<AddUserDTO>> AddUser(AddUserDTO user)
        {
            var userDto = _mapper.Map<User>(user);
            var createdUser = await _userRepository.AddUser(userDto);
            if (createdUser is null)
                return new ApiResponse<AddUserDTO>(HttpStatusCodeEnum.BadRequest, null, "Bad Request");

            var result = _mapper.Map<AddUserDTO>(createdUser);
            return new ApiResponse<AddUserDTO>(HttpStatusCodeEnum.Success, result, "User Add Successfuly");
        }

        public async Task<ApiResponse<bool>> DeleteUser(int userId)
        {
            var user = await _userRepository.GetUser(userId);
            if (user is null)
                return new ApiResponse<bool>(HttpStatusCodeEnum.NotFound, false, "User Not Found");

            var result = await _userRepository.DeleteUser(user);
            if(!result)
                return new ApiResponse<bool>(HttpStatusCodeEnum.BadRequest, false, "Bad Request");

            return new ApiResponse<bool>(HttpStatusCodeEnum.Success, true, "User info deleted successfully");
        }

        public async Task<ApiResponse<IEnumerable<GetUserDTO>>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            var result = users.Select(s => new GetUserDTO
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Age = s.Age,
                Credit = s.Credit
            });

            return new ApiResponse<IEnumerable<GetUserDTO>>(HttpStatusCodeEnum.Success, result, null);
        }

        public async Task<ApiResponse<GetUserDTO>> GetUser(int UserId)
        {
            var user = await _userRepository.GetUser(UserId);
            if (user is null)
                return new ApiResponse<GetUserDTO>(HttpStatusCodeEnum.NotFound, null, "User Not Found");

            var result = _mapper.Map<GetUserDTO>(user);
            return new ApiResponse<GetUserDTO>(HttpStatusCodeEnum.Success, result, null);
        }

        public async Task<ApiResponse<AddUserDTO>> UpdateUser(AddUserDTO user)
        {
            var userInfo = await _userRepository.GetUser(user.Id);
            if (userInfo is null)
                return new ApiResponse<AddUserDTO>(HttpStatusCodeEnum.NotFound, null, "User Not Found");

            userInfo.FirstName = user.FirstName;
            userInfo.FirstName = user.LastName;
            userInfo.Age = user.Age;
            userInfo.Credit = user.Credit;

            var result = await _userRepository.UpdateUser(userInfo);
            if (result is null)
                return new ApiResponse<AddUserDTO>(HttpStatusCodeEnum.BadRequest, null, "Bad Request");

            return new ApiResponse<AddUserDTO>(HttpStatusCodeEnum.Success, user, "User Info Updated Suuccessfully");
        }
    }
}
