using System;
using System.Collections.Generic;
using Storage.DTO;

namespace Football.Storage.Interfaces
{
    public interface IAccessGroupRepository
    {
        IEnumerable<AccessGroupDTO> GetAll();
        void SaveOne(AccessGroupDTO acc);
        AccessGroupDTO GetOne(Guid id);
        void UpdateOne(AccessGroupDTO acc);
        void DeleteOne(AccessGroupDTO acc);
        IEnumerable<AccessGroupDTO> GetAllByType(string type);
        AccessGroupDTO GetOneByName(string name);
    }
}
