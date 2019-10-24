using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Test3.Data;

namespace Test3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Test3.Data.Audit> Audit { get; set; }
        public DbSet<Test3.Data.Department> Department { get; set; }
        public DbSet<Test3.Data.Employee> Employee { get; set; }
    }
}
