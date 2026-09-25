using Microsoft.EntityFrameworkCore;
using PhcheabApi.Modules.Items;

namespace PhcheabApi.Data;

public class MyDbContext(DbContextOptions<MyDbContext> options) : DbContext(options)
{
    public DbSet<Item> Items => Set<Item>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(entity =>
        {
            entity.Property(i => i.Name).IsRequired().HasMaxLength(200);
            entity.Property(i => i.Description).HasMaxLength(1000);
        });
    }
}
