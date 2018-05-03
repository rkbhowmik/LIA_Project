using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LIA.Admin.Services;
using LIA.Data.Data.Entities;
using LIA.Data.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LIA.Admin.Pages.UserCourses
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly IDbWriter _writer;
        private readonly IDbReader _reader;
        private readonly IUserInfoService _db;

        public DeleteModel(IDbWriter writer, IDbReader reader, IUserInfoService db)
        {
            _writer = writer;
            _reader = reader;
            _db = db;
        }

        [BindProperty]
        public UserCourse UserCourse { get; set; }

        public IActionResult OnGet(string userid, int courseid)
        {
            UserCourse = _reader.Get<UserCourse>(userid, courseid);
            ViewData["Email"] = _db.GetUser(userid).Email;
            ViewData["CourseTitle"] = _reader.Get<Course>(courseid).Result.Title;
            return Page();

        }

        public async Task<IActionResult> OnPostAsync(string userid, int? courseid)
        {
            if(userid == null || courseid == null)
            {
                return NotFound();
            }

            UserCourse = _reader.Get<UserCourse>(userid, (int)courseid);

            if (UserCourse != null)
            {
                await _writer.Remove<UserCourse>(UserCourse);
            }

            return RedirectToPage("./Index");
        }
    }
}