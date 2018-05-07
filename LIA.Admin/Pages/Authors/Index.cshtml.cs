using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LIA.Data.Data.Entities;
using LIA.Data.Services;
using System.Linq;

namespace LIA.Admin.Pages.Authors
{
    public class IndexModel : PageModel
    {
        private readonly IDbReader _reader;

        public IndexModel(IDbReader reader)
        {
            _reader = reader;
        }

        public IEnumerable<Author> Author { get;set; }

        public void OnGet()
        {
            Author =_reader.GetWithIncludes<Author>();
        }
    }
}
