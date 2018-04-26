using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LIA.Admin.Models;
using LIA.Admin.Services;
using LIA.Data.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LIA.Admin.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly IUserInfoService _db;

        public CreateModel(IUserInfoService db)
        {
            _db = db;
        }
        
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RegisterUserModel RegisterUser  { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _db.AddUserAsync(RegisterUser);

            return RedirectToPage("./Index");
        }


    }
}