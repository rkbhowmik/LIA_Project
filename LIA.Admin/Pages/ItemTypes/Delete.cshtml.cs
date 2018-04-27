using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LIA.Data.Data;
using LIA.Data.Data.Entities;
using LIA.Data.Services;

namespace LIA.Admin.Pages.ItemTypes
{
    public class DeleteModel : PageModel
    {
        private readonly IDbWriter _writer;
        private readonly IDbReader _reader;


        public DeleteModel(IDbWriter writer, IDbReader reader)
        {
            _writer = writer;
            _reader = reader;
        }

        [BindProperty]
        public ItemType ItemType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ItemType = await _reader.Get<ItemType>((int)id);

            if (ItemType == null)
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
                await _writer.Remove<ItemType>(ItemType);
            }
            catch
            {
               
            }

            return RedirectToPage("./Index");
        }
    }
}
