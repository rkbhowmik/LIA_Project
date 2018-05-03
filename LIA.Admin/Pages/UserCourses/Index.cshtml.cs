using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LIA.Data.Data.Entities;
using LIA.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LIA.Admin.Pages.UserCourses
{
    public class IndexModel : PageModel
    {
        IDbReader _db;

        public IList<UserCourse> UserCourses { get; set; }

        public IndexModel(IDbReader db)
        {
            _db = db;
        }
        public void OnGet()
        {
            UserCourses = _db.GetWithIncludes<UserCourse>().ToList();
        }
    }
}