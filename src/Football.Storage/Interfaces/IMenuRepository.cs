using System;
using System.Collections.Generic;
using Storage.DTO;

namespace Football.Storage.Interfaces
{
    public interface IMenuRepository
    {
        IEnumerable<MenuItemDTO> GetAllItems();
        void SaveOne(MenuItemDTO item);
        MenuItemDTO GetOneById(Guid id);
        void UpdateOne(MenuItemDTO menuItem);
        void DeleteOne(MenuItemDTO menuItem);
    }
}
