using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AspNetIdentityExample.Stores.User
{
    public class UserStore : IUserStore
    {
        private ApplicationDbContext dbContext;

        public IEnumerable<AspNetIdentityExample.Models.User> ReadUserList()
        {
            return this.dbContext.Users.ToList();
        }

        public AspNetIdentityExample.Models.User FindUserById(string id)
        {
            return this.dbContext.Users.Include(u => u.RoleJoins).ThenInclude(j => j.Role).Single(u => u.Id.ToString() == id);
        }

        public AspNetIdentityExample.Models.User FindUserByUserName(string username)
        {
            return this.dbContext.Users.Include(u => u.RoleJoins).ThenInclude(j => j.Role).Single(u => u.UserName.ToString() == username);
        }

        public UserStore(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}