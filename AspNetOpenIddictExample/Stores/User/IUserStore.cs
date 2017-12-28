using System.Collections.Generic;

namespace AspNetIdentityExample.Stores.User
{
    public interface IUserStore
    {
        IEnumerable<AspNetIdentityExample.Models.User> ReadUserList();
        AspNetIdentityExample.Models.User FindUserById(string id);
        AspNetIdentityExample.Models.User FindUserByUserName(string username);
        /* implementacja pozostałych metod nastąpi w terminie późniejszym:
        void CreateUser(UserJson user);
        void UpdateUser(string id, UserJson user);
        void DeleteUser(string id);
        */
    }
}