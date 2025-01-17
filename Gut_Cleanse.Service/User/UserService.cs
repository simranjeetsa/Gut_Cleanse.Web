using Gut_Cleanse.Model;
using Gut_Cleanse.Repo.User;

namespace Gut_Cleanse.Service.User
{
    public class UserService : IUserService
    {
        readonly IUserRepo userRepo;
        public UserService(IUserRepo _userRepo)
        {
            userRepo = _userRepo;
        }
        public List<UserModel> GetUsers()
        {
            return userRepo.GetUsers();
        }

        public UserModel GetUserById(int userId)
        {
            return userRepo.GetUserById(userId);
        }

        public void AddUser(UserModel model)
        {
            userRepo.AddUser(model);
        }

        public void UpdateUser(UserModel model)
        {
            userRepo.UpdateUser(model);
        }
        public void Delete(int id)
        {
            userRepo.Delete(id);
        }
    }
}
