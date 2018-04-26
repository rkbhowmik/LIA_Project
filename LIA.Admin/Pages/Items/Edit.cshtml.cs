﻿using System;
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

namespace LIA.Admin.Pages.Items
{
    public class EditModel : PageModel
    {
        private readonly IDbWriter _writer;
        private readonly IDbReader _reader;

        public EditModel(IDbWriter writer, IDbReader reader)
        {
            _writer = writer;
            _reader = reader;

        }

        [BindProperty]
        public Item Item { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Item = await _reader.Get<Item>()
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
    }
}
