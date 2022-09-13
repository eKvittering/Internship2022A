using Microsoft.EntityFrameworkCore;

namespace CuSubs
{
    public class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Customers> Customers { get; set; }
        public DbSet<Subscriptions> Subscriptions { get; set; }
    }
}