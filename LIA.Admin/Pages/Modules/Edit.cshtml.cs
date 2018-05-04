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
using LIA.Data.Services;

namespace LIA.Admin.Pages.Modules
{
    public class EditModel : PageModel
    {
        private readonly IDbReader _reader;
        private readonly IDbWriter _writer;

        public EditModel(IDbReader reader, IDbWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }

        [BindProperty]
        public Module Module { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Module = await _reader.Get<Module>((int) id);
            ViewData["Courses"] = _reader.GetSelectList<Course>("Id", "Title");

            if (Module == null)
            {
                return NotFound();
            }
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
                await _writer.UpdateAsync(Module);
            }
            catch
            {
                throw;
            }

            return RedirectToPage("./Index");
        }
    }
}
