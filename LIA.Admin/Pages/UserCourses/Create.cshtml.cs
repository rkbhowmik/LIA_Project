using System.Collections.Generic;
using System.Threading.Tasks;
using LIA.Data.Data.Entities;
using LIA.Data.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LIA.Admin.Pages.UserCourses
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly IDbWriter _writer;
        private readonly IDbReader _reader;

        public CreateModel(IDbWriter writer, IDbReader reader)
        {
            _writer = writer;
            _reader = reader;
        }


        public void OnGet()
        {
            ViewData["Users"] = _reader.GetSelectList<User>("Id", "Email");
            ViewData["Courses"] = _reader.GetSelectList<Course>("Id", "Title");
        }

        [BindProperty]
        public UserCourse   UserCourses { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var success = await _writer.AddAsync(UserCourses); //LÄGG TILL I SERVICEN

                if (success)
                {
                    return RedirectToPage("./Index"); // Kan även läggas till i catch blocket nedan
                }
            }
            catch { }
            ViewData["Users"] = _reader.GetSelectList<User>("Id", "Email");
            ViewData["Courses"] = _reader.GetSelectList<Course>("Id", "Name");

            return Page();
        }
    }
}