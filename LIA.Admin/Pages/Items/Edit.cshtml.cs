using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LIA.Data.Data;
using LIA.Data.Data.Entities;

namespace LIA.Admin.Pages.Items
{
    public class EditModel : PageModel
    {
        private readonly LIA.Data.Data.CourseContext _context;

        public EditModel(LIA.Data.Data.CourseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Item Item { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Item = await _context.Items
                .Include(i => i.ItemType)
                .Include(i => i.Module).SingleOrDefaultAsync(m => m.Id == id);

            if (Item == null)
            {
                return NotFound();
            }
           ViewData["ItemTypeId"] = new SelectList(_context.ItemTypes, "Id", "Id");
           ViewData["ModuleId"] = new SelectList(_context.Modules, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(Item.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
    }
}
