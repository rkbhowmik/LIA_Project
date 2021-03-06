﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly LIA.Data.Data.CourseContext _context;

        public DeleteModel(LIA.Data.Data.CourseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Item Item { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Item =_context.Items.Include("ItemType").FirstOrDefault(i=>i.Id.Equals(id));
            if (Item == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Item = await _context.Items.FindAsync(id);

            if (Item != null)
            {
                _context.Items.Remove(Item);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
