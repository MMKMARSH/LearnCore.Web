using Microsoft.EntityFrameworkCore;

namespace LearnCore.Web.Data
{
    public class LearnCoreDbContext : DbContext
    {
        public LearnCoreDbContext(DbContextOptions<LearnCoreDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Customer> Customers { get; set; }
    }
}
