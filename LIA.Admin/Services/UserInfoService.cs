using LIA.Admin.Models;
using LIA.Data.Data;
using LIA.Data.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIA.Admin.Services
{
    public class UserInfoService : IUserInfoService
    {
        private CourseContext _db;
        private readonly UserManager<User> _userManager;
        public UserInfoService(CourseContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IEnumerable<UserPageModel> GetUsers()
        {
            throw new NotImplementedException();
        }

        public UserPageModel GetUser(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> AddUserAsync(RegisterUserModel user)
        {
            var dbUser = new User
            {
                UserName = user.Email,
                Email = user.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(dbUser, user.Password);
            return result;
        }

        public Task<bool> UpdateUserAsync(UserPageModel user)
        {
            throw new NotImplementedException();
        }

        public  async Task<bool> DeleteUser(string userId)
        {
            try
            {
                var dbUser = await _db.Users.FirstOrDefaultAsync(d => d.Id.Equals(userId));
                if (dbUser == null) return false;

                var userRoles = _db.UserRoles.Where(ur => ur.UserId.Equals(dbUser.Id));

                _db.UserRoles.RemoveRange(userRoles);
                _db.Users.Remove(dbUser);

                var result = await _db.SaveChangesAsync();
                if (result < 0) return false;
            }

            catch (Exception)
            {

                return false;
            }
            return true;
        }
    }
}
   