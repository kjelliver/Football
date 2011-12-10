﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hulen.Objects.Enum;

namespace Hulen.Storage.Interfaces
{
    public interface IUserRepository
    {
        StorageResult SaveOneUser(UserDTO user);
        UserDTO GetOneUserByUsername(string username);
        StorageResult DeleteOneUser(string username);
        IEnumerable<UserDTO> GetAllUsers();
        StorageResult UpdateOneUser(UserDTO user, bool usernameChanged);
    }
}