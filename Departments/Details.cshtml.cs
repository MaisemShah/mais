using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Test3.Data;

namespace Test3.Pages.Departments
{
    public class DetailsModel : PageModel
    {
        private readonly Test3.Data.ApplicationDbContext _context;

        public DetailsModel(Test3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Department Department { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Department = await _context.Department.FirstOrDefaultAsync(m => m.DID == id);

            if (Department == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
