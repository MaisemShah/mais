using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Test3.Data;

namespace Test3.Pages.Audits
{
    public class IndexModel : PageModel
    {
        private readonly Test3.Data.ApplicationDbContext _context;

        public IndexModel(Test3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Audit> Audit { get;set; }

        public async Task OnGetAsync()
        {
            Audit = await _context.Audit.ToListAsync();
        }
    }
}
