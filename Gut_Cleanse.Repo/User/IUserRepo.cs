using Gut_Cleanse.Model;

namespace Gut_Cleanse.Repo.User
{
    public interface IUserRepo
    {
        List<UserModel> GetUsers();
        UserModel GetUserById(int userId);
        void AddUser(UserModel model);
        void UpdateUser(UserModel model);
        void Delete(int id);
    }
}
