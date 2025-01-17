using Gut_Cleanse.Common;
using Gut_Cleanse.Data;
using Gut_Cleanse.Model;
using Microsoft.EntityFrameworkCore;

namespace Gut_Cleanse.Repo.User
{
    public class UserRepo : IUserRepo
    {
        readonly ApplicationDbContext context;
        public UserRepo(ApplicationDbContext _context)
        {
            context = _context;
        }
        public List<UserModel> GetUsers()
        {
            return context.Users.Where(x => !x.IsDeleted).Select(x => x.AutoMap<UserModel>()).ToList();
        }

        public UserModel GetUserById(int userId)
        {
            UserModel result = new UserModel();

            var user = context.Users.Include(x => x.City).ThenInclude(x => x.State).FirstOrDefault(x => x.Id == userId);
            if (user != null)
            {
                result = user.AutoMap<UserModel>();
                result.StateId = user.City.StateId;
                result.CountryId = user.City.State.CountryId;
            }


            return result;
        }

        public void AddUser(UserModel model)
        {
            context.Users.Add(model.AutoMap<Data.Tables.User>());
            context.SaveChanges();

        }

        public void UpdateUser(UserModel model)
        {
            var user = context.Users.FirstOrDefault(s => s.Id == model.Id);
            if (user != null)
            {
                user.DOB = model.DOB;
                user.CityId = model.CityId;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.MiddleName = model.MiddleName;
                user.ContactNumber = model.ContactNumber;
                user.ZipCode = model.ZipCode;
                user.Gender = model.Gender;
                user.ProfilePicture = model.ProfilePicture;
            }
            context.SaveChanges();

        }

        public void Delete(int id)
        {
            var user = context.Users.FirstOrDefault(s => s.Id == id);
            if (user != null)
                user.IsDeleted = true;
            context.SaveChanges();

        }
    }
}
