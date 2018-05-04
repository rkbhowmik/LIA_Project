using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LIA.Data.Data.Entities;
using LIA.Data.Services;

namespace LIA.Admin.Pages.Items
{
    public class IndexModel : PageModel
    {
        private readonly IDbReader _reader;
        public IndexModel(IDbReader reader)
        {
            _reader = reader;
        }
        public IEnumerable<Item> Item { get; set; }

        public void OnGet()
        {
            Item = _reader.GetWithIncludes<Item>();
        }
    }
}
