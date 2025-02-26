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
        public IQueryable<UserModel> GetUsers()
        {
            return (from x in context.Users.Where(x => !x.IsDeleted)
                    join userRole in context.UserRoles on x.AspNetUserId equals userRole.UserId into _userRole
                    from userRole in _userRole.DefaultIfEmpty().Take(1)
                    join role in context.Roles on userRole.RoleId equals role.Id
                    select new UserModel
                    {
                        Id = x.Id,
                        AspNetUserId = x.AspNetUserId,
                        FirstName = x.FirstName ?? string.Empty,
                        LastName = x.LastName ?? string.Empty,
                        Email = x.Email,
                        ContactNumber = x.ContactNumber ?? string.Empty,
                        RoleName = role.Name ?? string.Empty,
                        ProfilePicture = x.ProfilePicture ?? string.Empty,
                        IsDeleted = x.IsDeleted,
                        IsLocked = x.IsLocked,
                        DOB = x.DOB,
                        MiddleName = x.MiddleName ?? string.Empty,
                        ZipCode = x.ZipCode ?? string.Empty,
                    });
        }

        public UserModel GetUserById(int userId)
        {
            UserModel result = new UserModel();

            var user = context.Users.Include(x => x.City).ThenInclude(x => x.State).FirstOrDefault(x => x.Id == userId);
            if (user != null)
            {
                result = user.AutoMap<UserModel>();
                result.StateId = user.City?.StateId;
                result.CountryId = user.City?.State.CountryId;
            }


            return result;
        }

        public void AddUser(UserModel model)
        {
            var entity = model.AutoMap<Data.Tables.User>();
            context.Users.Add(entity);
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
