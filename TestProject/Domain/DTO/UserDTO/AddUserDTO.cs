using TestProject.Domain.Mappings;
using TestProject.Domain.Model;

namespace TestProject.Domain.DTO.UserDTO
{
    public class AddUserDTO : IMapFrom<User>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public long Credit { get; set; }
    }
}
