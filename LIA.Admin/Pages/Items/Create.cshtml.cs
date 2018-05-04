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

namespace LIA.Admin.Pages.Items
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
            ViewData["ItemType"] = _reader.GetSelectList<ItemType>("Id", "Title");
            ViewData["Modules"] = _reader.GetSelectList<Module>("Id", "Title");
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

            await _writer.AddAsync(Item);

            return RedirectToPage("./Index");
        }
    }
}