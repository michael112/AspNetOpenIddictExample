using System;

namespace AspNetIdentityExample.Models
{
    public class UserRoleJoin
    {
        public string Id { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }

        public UserRoleJoin()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}