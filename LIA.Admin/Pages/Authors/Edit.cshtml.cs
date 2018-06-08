using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LIA.Data.Data.Entities;
using LIA.Data.Services;

namespace LIA.Admin.Pages.Authors
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
        public Author Author { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Author = await _reader.Get<Author>()
                .SingleOrDefaultAsync(m => m.Id == id);

            if (Author == null)
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

            //_context.Attach(Author).State = EntityState.Modified;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _writer.UpdateAsync(Author);
            }
            catch
            {

                throw;

            }

            return RedirectToPage("./Index");
        }

        //private bool AuthorExists(int id)
        //{
        //    return _context.Authors.Any(e => e.Id == id);
        //}
    }
}
