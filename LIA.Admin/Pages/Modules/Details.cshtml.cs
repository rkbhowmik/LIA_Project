using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LIA.Data.Data;
using LIA.Data.Data.Entities;

namespace LIA.Admin.Pages.Modules
{
    public class DetailsModel : PageModel
    {
        private readonly LIA.Data.Data.CourseContext _context;

        public DetailsModel(LIA.Data.Data.CourseContext context)
        {
            _context = context;
        }

        public Module Module { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Module = await _context.Modules.SingleOrDefaultAsync(m => m.Id == id);

            if (Module == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
