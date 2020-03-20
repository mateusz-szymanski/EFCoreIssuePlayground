using Microsoft.EntityFrameworkCore;

namespace EFCoreIssues
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Root> Root { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<A>(builder =>
            {
                builder.OwnsOne(x => x.Sub);
            });

            modelBuilder.Entity<Root>(builder =>
            {
                builder.OwnsOne(x => x.B);
            });
        }
    }
}
