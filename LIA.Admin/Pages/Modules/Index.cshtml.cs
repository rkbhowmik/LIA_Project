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

namespace LIA.Admin.Pages.Modules
{
    public class IndexModel : PageModel
    {
        private readonly IDbReader _reader;

        public IndexModel(IDbReader reader)
        {
            _reader = reader;
        }

        public IList<Module> Module { get;set; }

        public void OnGet()
        {
            Module = _reader.GetWithIncludes<Module>().ToList();           
        }
    }
}
