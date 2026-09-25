using Microsoft.EntityFrameworkCore;
using RiebreabApi.Modules.Items;
using RiebreabApi.Modules.News;
using RiebreabApi.Modules.Quotes;
using RiebreabApi.Modules.CultureTopics;
using RiebreabApi.Modules.HeritageSites;
using RiebreabApi.Modules.GalleryImages;
using RiebreabApi.Modules.Videos;
using RiebreabApi.Modules.Events;

namespace RiebreabApi.Data;

public class MyDbContext(DbContextOptions<MyDbContext> options) : DbContext(options)
{
    public DbSet<Item> Items => Set<Item>();
    public DbSet<News> News => Set<News>();
    public DbSet<Quote> Quotes => Set<Quote>();
    public DbSet<CultureTopic> CultureTopics => Set<CultureTopic>();
    public DbSet<HeritageSite> HeritageSites => Set<HeritageSite>();
    public DbSet<GalleryImage> GalleryImages => Set<GalleryImage>();
    public DbSet<Video> Videos => Set<Video>();
    public DbSet<Event> Events => Set<Event>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(entity =>
        {
            entity.Property(i => i.Name).IsRequired().HasMaxLength(200);
            entity.Property(i => i.Description).HasMaxLength(1000);
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.Property(n => n.Category).IsRequired().HasMaxLength(100);
            entity.Property(n => n.Date).IsRequired().HasMaxLength(50);
            entity.Property(n => n.Title).IsRequired().HasMaxLength(300);
            entity.Property(n => n.Excerpt).IsRequired().HasMaxLength(2000);
            entity.Property(n => n.ImgLabel).IsRequired().HasMaxLength(300);
        });

        modelBuilder.Entity<Quote>(entity =>
        {
            entity.Property(q => q.Category).IsRequired().HasMaxLength(100);
            entity.Property(q => q.Kh).IsRequired().HasMaxLength(1000);
            entity.Property(q => q.Romanized).IsRequired().HasMaxLength(500);
            entity.Property(q => q.En).IsRequired().HasMaxLength(500);
            entity.Property(q => q.Meaning).IsRequired().HasMaxLength(1000);
        });

        modelBuilder.Entity<CultureTopic>(entity =>
        {
            entity.Property(c => c.Title).IsRequired().HasMaxLength(300);
            entity.Property(c => c.Body).IsRequired().HasMaxLength(3000);
            entity.Property(c => c.ImgLabel).IsRequired().HasMaxLength(300);
        });

        modelBuilder.Entity<HeritageSite>(entity =>
        {
            entity.Property(h => h.Year).IsRequired().HasMaxLength(20);
            entity.Property(h => h.Title).IsRequired().HasMaxLength(300);
            entity.Property(h => h.TitleKh).IsRequired().HasMaxLength(300);
            entity.Property(h => h.Desc).IsRequired().HasMaxLength(2000);
            entity.Property(h => h.ImgLabel).IsRequired().HasMaxLength(300);
        });

        modelBuilder.Entity<GalleryImage>(entity =>
        {
            entity.Property(g => g.ImgLabel).IsRequired().HasMaxLength(300);
        });

        modelBuilder.Entity<Video>(entity =>
        {
            entity.Property(v => v.Title).IsRequired().HasMaxLength(300);
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.Property(e => e.When).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(300);
            entity.Property(e => e.TitleKh).IsRequired().HasMaxLength(300);
            entity.Property(e => e.Desc).IsRequired().HasMaxLength(2000);
        });
    }
}
