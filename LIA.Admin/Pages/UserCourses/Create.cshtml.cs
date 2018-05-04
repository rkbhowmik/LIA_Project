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


        public IActionResult OnGet()
        {
            ViewData["Users"] = _reader.GetSelectList<User>("Id", "Email");
            ViewData["Courses"] = _reader.GetSelectList<Course>("Id", "Title");
            ViewData["ErrorMessage"] = "";
            return Page();
        }

        [BindProperty]
        public UserCourse UserCourses { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            
            try
            {
                await _writer.AddAsync(UserCourses);
            }
            catch 
            {
                ViewData["Users"] = _reader.GetSelectList<User>("Id", "Email");
                ViewData["Courses"] = _reader.GetSelectList<Course>("Id", "Title");
                ViewData["ErrorMessage"] = "User has already taken this course";
                return Page();
            }
            return RedirectToPage("./Index");

        }
    }
}