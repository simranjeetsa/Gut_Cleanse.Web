using Gut_Cleanse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gut_Cleanse.Service.User
{
    public interface IUserService
    {
        List<UserModel> GetUsers();
        UserModel GetUserById(int userId);
        void AddUser(UserModel model);
        void UpdateUser(UserModel model);
        void Delete(int id);
        UserModel GetUserByUserId(string userId);
        UserModel GetUserByEmail(string email);
    }
}
