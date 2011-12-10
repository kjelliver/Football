using System.Collections.Generic;
using Storage.DTO;

namespace Football.Storage.Interfaces
{
    public interface IUserRepository
    {
        void SaveOneUser(UserDTO user);
        UserDTO GetOneUserByUsername(string username);
        void DeleteOneUser(string username);
        IEnumerable<UserDTO> GetAllUsers();
        void UpdateOneUser(UserDTO user, bool usernameChanged);
    }
}
