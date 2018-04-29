using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LIA.Admin.Services;
using LIA.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LIA.Admin.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly IUserInfoService _db;

        public IndexModel(IUserInfoService db)
        {
            _db = db;
        }

        public IEnumerable<UserPageModel> Users { get; set; }

       public void OnGet()
        {
            Users = _db.GetUsers();           
        }
    }
}