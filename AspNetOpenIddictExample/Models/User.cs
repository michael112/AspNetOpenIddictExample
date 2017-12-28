using System;
using System.Collections.Generic;

namespace AspNetIdentityExample.Models
{
    public class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public IEnumerable<UserRoleJoin> RoleJoins { get; set; }

        public User()
        {
            Id = Guid.NewGuid().ToString();
        }
        public User(string userName) : this()
        {
            UserName = userName;
        }
    }
}