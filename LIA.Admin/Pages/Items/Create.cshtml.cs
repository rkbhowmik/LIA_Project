using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LIA.Data.Data;
using LIA.Data.Data.Entities;

namespace LIA.Admin.Pages.Items
{
    public class CreateModel : PageModel
    {
        private readonly LIA.Data.Data.CourseContext _context;

        public CreateModel(LIA.Data.Data.CourseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ItemTypeId"] = new SelectList(_context.ItemTypes, "Id", "Id");
        ViewData["ModuleId"] = new SelectList(_context.Modules, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Item Item { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Items.Add(Item);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}