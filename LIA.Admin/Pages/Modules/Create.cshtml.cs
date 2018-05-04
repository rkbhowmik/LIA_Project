using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LIA.Data.Data;
using LIA.Data.Data.Entities;
using LIA.Data.Services;

namespace LIA.Admin.Pages.Modules
{
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
            ViewData["Courses"] = _reader.GetSelectList<Course>("Id", "Title");
            return Page();
        }

        [BindProperty]
        public Module Module { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _writer.AddAsync(Module);

            return RedirectToPage("./Index");
        }
    }
}