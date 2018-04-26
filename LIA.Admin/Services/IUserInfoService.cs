using LIA.Admin.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIA.Admin.Services
{
    public interface IUserInfoService
    {
        IEnumerable<UserPageModel> GetUsers();
        UserPageModel GetUser(string userId);

        Task<IdentityResult> AddUserAsync(RegisterUserModel user);
        Task<bool> UpdateUserAsync(UserPageModel user);
        Task<bool> DeleteUser(string userId);
    }
}
