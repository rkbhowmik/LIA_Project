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
        private object userId;
        private readonly UserManager<User> _userManager;
        public UserInfoService(CourseContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        
        public int UserCount()
        {
            return _db.Users.Count();
        }
        public IEnumerable<UserPageModel> GetUsers()
        {
            return from user in _db.Users
                   orderby user.Email
                   select new UserPageModel
                   {
                       Id = user.Id,
                       Email = user.Email,

                       // Checkbox to check if its admin or not
                       IsAdmin = _db.UserRoles.Any(ur =>
                       ur.UserId.Equals(user.Id) &&
                       ur.RoleId.Equals(1.ToString())
                       )
                   };
        }

        public UserPageModel GetUser(string userId)
        {
            return (from user in _db.Users
                   where user.Id == userId 
                   select new UserPageModel
                   {
                       // ctrl + space to get all properties
                       Id = user.Id,
                       Email = user.Email,
                       IsAdmin = _db.UserRoles.Any(ur =>
                        ur.UserId.Equals(user.Id) &&
                        ur.RoleId.Equals(1.ToString())
                        )
                   }).FirstOrDefault();
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

        public async Task<bool> UpdateUserAsync(UserPageModel user)
        {
            var dbUser = await _db.Users.FirstOrDefaultAsync(d => d.Id.Equals(user.Id));
            if (dbUser == null) return false;
            if (string.IsNullOrEmpty(user.Email)) return false;

            dbUser.Email = user.Email;

            var userRole = new IdentityUserRole<string>()
            {
                RoleId = "1",
                UserId = user.Id
        };

            // TO check if it is an admin
            // IsAdmin is checking if admin is available in database.
            // Its the combination of UserId and AdminRoleId in the Asp.Net Roles table
            var IsAdmin = await _db.UserRoles.AnyAsync(ur => ur.Equals(userRole));


            if (IsAdmin && !user.IsAdmin)
                _db.UserRoles.Remove(userRole);
            else if (!IsAdmin && user.IsAdmin)
                    await _db.UserRoles.AddAsync(userRole);

            var result = await _db.SaveChangesAsync();
            return result >= 0;
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
   