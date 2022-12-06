using TestProject.Domain.Model;

namespace TestProject.Domain.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<User> GetUser(int UserId);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task<bool> DeleteUser(User user);
    }
}
