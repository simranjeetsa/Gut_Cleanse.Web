using Gut_Cleanse.Model;

namespace Gut_Cleanse.Repo.User
{
    public interface IUserRepo
    {
        IQueryable<Data.Tables.User> GetUsers();
        UserModel GetUserById(int userId);
        void AddUser(UserModel model);
        void UpdateUser(UserModel model);
        void Delete(int id);
    }
}
