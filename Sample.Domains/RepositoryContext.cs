
using Microsoft.EntityFrameworkCore;

namespace Sample.Domains
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }


    }
}
