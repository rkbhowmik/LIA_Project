using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LIA.Admin.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LIA.Admin.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly IUserInfoService _db;

        public EditModel(IUserInfoService db)
        {
            _db = db;
        }

       
        [BindProperty]
        public UserPageModel UserPageModel { get; set; }

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserPageModel = _db.GetUser(id);
               

            if (UserPageModel == null)
            {
                return NotFound();
            }

             return Page();
        }

       public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _db.UpdateUserAsync(UserPageModel);
            }
            catch
            {

                throw;

            }

            return RedirectToPage("./Index");
        }
    }
}