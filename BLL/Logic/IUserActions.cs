using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Logic
{
    public interface IUserActions
    {
        ICollection<UserDto> GetUsers();

        UserDto GetUserByID(int id);

        void AddUser(UserDto userDto);

        void RemoveUserByID(int id);

        void Updateuser(int id, UserDto userDto);
    }
}
