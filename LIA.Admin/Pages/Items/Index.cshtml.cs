using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LIA.Data.Data;
using LIA.Data.Data.Entities;

namespace LIA.Admin.Pages.Items
{
    public class IndexModel : PageModel
    {
        private readonly LIA.Data.Data.CourseContext _context;

        public IndexModel(LIA.Data.Data.CourseContext context)
        {
            _context = context;
        }

        public IList<Item> Item { get;set; }

        public async Task OnGetAsync()
        {
            Item = await _context.Items
                .Include(i => i.ItemType)
                .Include(i => i.Module).ToListAsync();
        }
    }
}
