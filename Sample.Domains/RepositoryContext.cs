using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;


namespace Sample.Domains
{
   
    public class RepositoryContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        public Microsoft.EntityFrameworkCore.DbSet<Employee> Employees { get; set; }
    }
}
