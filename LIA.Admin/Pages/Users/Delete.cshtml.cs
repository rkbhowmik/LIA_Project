using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LIA.Admin.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LIA.Admin.Pages.Users
{
    public class DeleteModel : PageModel
    {
        private readonly IUserInfoService _db;

        public DeleteModel(IUserInfoService db)
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

        public async Task<IActionResult> OnPostAsync(string Id)
        {
            if (Id==null)
            {
                return Page();
            }

            try
            {
                await _db.DeleteUser(Id);
            }
            catch
            {

                throw;

            }

            return RedirectToPage("./Index");
        }

    }
}