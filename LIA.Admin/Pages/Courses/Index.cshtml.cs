using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LIA.Data.Data.Entities;

namespace LIA.Admin.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly LIA.Data.Data.CourseContext _context;

        public IndexModel(LIA.Data.Data.CourseContext context)
        {
            _context = context;
        }

        public IList<Course> Course { get;set; }

        public async Task OnGetAsync()
        {
            Course = await _context.Courses
                .Include(c => c.Author).ToListAsync();
        }
    }
}
