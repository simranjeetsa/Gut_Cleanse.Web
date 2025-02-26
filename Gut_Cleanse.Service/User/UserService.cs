using Gut_Cleanse.Common;
using Gut_Cleanse.Data.Tables;
using Gut_Cleanse.Model;
using Gut_Cleanse.Repo.User;
using Gut_Cleanse.Service.CommonService;
using Microsoft.EntityFrameworkCore;

namespace Gut_Cleanse.Service.User
{
    public class UserService : IUserService
    {
        readonly IUserRepo userRepo;
        readonly ICommonService commonService;
        public UserService(IUserRepo _userRepo, ICommonService _commonService)
        {
            userRepo = _userRepo;
            commonService = _commonService;
        }
        public List<UserModel> GetUsers()
        {
            return userRepo.GetUsers().Where(x => x.Id != commonService.GetCurrentUserInfo().Id).ToList();
        }

        public UserModel GetUserByUserId(string userId)
        {
            UserModel model = new UserModel();
            var user = userRepo.GetUsers().FirstOrDefault(x => x.AspNetUserId == userId);
            if (user != null)
                model = user.AutoMap<UserModel>();
            return model;
        }

        public UserModel GetUserByEmail(string email)
        {
            UserModel model = new UserModel();
            var user = userRepo.GetUsers().FirstOrDefault(x => x.Email == email);
            if (user != null)
                model = user.AutoMap<UserModel>();
            return model;
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
