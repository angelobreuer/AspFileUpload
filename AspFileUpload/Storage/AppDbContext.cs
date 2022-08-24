namespace AspFileUpload.Storage;

using Microsoft.EntityFrameworkCore;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<FileEntry> Entries { get; set; } = null!;
}
