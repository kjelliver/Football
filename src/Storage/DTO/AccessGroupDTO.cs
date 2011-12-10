using System;

namespace Storage.DTO
{
    public class AccessGroupDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string RolesThatHaveAccess { get; set; }
    }
}
