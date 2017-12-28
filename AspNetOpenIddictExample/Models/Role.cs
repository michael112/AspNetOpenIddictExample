using System;

namespace AspNetIdentityExample.Models
{
    public class Role
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Role()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}