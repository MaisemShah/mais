using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Test3.Data;

namespace Test3.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly Test3.Data.ApplicationDbContext _context;
        private DateTime? deadline;

        [BindProperty]
        public int OpenCount { get; set; }
        [BindProperty]

        public int ClosedCount { get; set; }
        [BindProperty(SupportsGet = true)]
        public string searchInput { get; set; }
        [BindProperty(SupportsGet = true)] 

        public string searchDate { get; set; }

        public IndexModel(Test3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; }
        public List<Employee> Employees { get; private set; }

        public async Task OnGetAsync()
        {
            var emps = from e in _context.Employee select e;
            if (User.IsInRole("admin")) 
            {
                emps = emps.Where(e => e.FN.Contains("searchInput"));
            }
            else if (User.IsInRole("slt"))
            {
                emps = emps.Where(e => e.FN.Contains("searchInput"));

            } else if (User.IsInRole("DeptHead"))
            {
                emps = emps.Where(e =>  e.FN.Contains("searchInput"));
            }
            var startdate = new System.DateTime(2019,10,10);
            var Enddate = new System.DateTime(2019, 10, 23);


            Employees = await emps.Where(e => e.ReleaseDate > startdate && e.ReleaseDate < Enddate)
                .ToListAsync();
              
               
            foreach(var item in Employees)
            {
                if (item.ApprPos == false)
                {
                    OpenCount += 1;
                }
                else if(item.ApprPos == true)
                {
                    ClosedCount += 1;
                }
                else
                {

                }
                    
            }
            System.Diagnostics.Debug.WriteLine("OpenCount: ");
            System.Diagnostics.Debug.WriteLine("ClosedCount: ");
            System.Diagnostics.Debug.WriteLine("OpenCount: ");
            System.Diagnostics.Debug.WriteLine("ClosedCount: ");



        }
    }
}
