using System;
using System.Collections.Generic;
using Storage.DTO;

namespace Football.Storage.Interfaces
{
    public interface IRoleRepository
    {
        IEnumerable<RoleDTO> GetAll();
        void SaveOne(RoleDTO role);
        void UpdateOne(RoleDTO role);
        RoleDTO GetOne(Guid id);
    }
}