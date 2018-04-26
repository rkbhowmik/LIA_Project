using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LIA.Admin.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LIA.Admin.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly IUserInfoService _db;

        public EditModel(IUserInfoService db)
        {
            _db = db;
        }

        /*
        [BindProperty]
        public Item Item { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Item = await _db.GetUsers()
                //.Include(i => i.ItemType)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (Item == null)
            {
                return NotFound();
            }

            ViewData["ItemTypes"] = _reader.GetSelectList<ItemType>("Id", "Title");

            //ViewData["ModuleId"] = new SelectList(_context.Modules, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _writer.UpdateAsync(Item);
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;

            }

            return RedirectToPage("./Index");
        }
        public void OnGet()
        {

        }*/
    }
}