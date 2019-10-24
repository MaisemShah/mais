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
    public class DeleteModel : PageModel
    {
        private readonly Test3.Data.ApplicationDbContext _context;

        public DeleteModel(Test3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Audit Audit { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Audit = await _context.Audit.FirstOrDefaultAsync(m => m.AID == id);

            if (Audit == null)
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

            Audit = await _context.Audit.FindAsync(id);

            if (Audit != null)
            {
                _context.Audit.Remove(Audit);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
