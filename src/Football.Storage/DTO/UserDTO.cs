using System;

namespace Storage.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password {get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public bool Disabled { get; set; }
        public bool MustChangePassword { get; set; }
        public bool HasPayed { get; set; }
    }
}
