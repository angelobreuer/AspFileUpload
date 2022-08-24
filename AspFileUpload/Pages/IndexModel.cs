namespace AspFileUpload.Pages;

using AspFileUpload.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

public sealed class IndexModel : PageModel
{
    private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

    public IndexModel(IDbContextFactory<AppDbContext> dbContextFactory)
    {
        ArgumentNullException.ThrowIfNull(dbContextFactory);

        _dbContextFactory = dbContextFactory;
    }

    public IFormFile? FormFile { get; set; }

    public IEnumerable<FileEntry> Entries { get; set; } = null!;

    public async Task OnGetAsync()
    {
        await using var databaseContext = await _dbContextFactory
            .CreateDbContextAsync()
            .ConfigureAwait(false);

        Entries = await databaseContext.Entries.ToArrayAsync();
    }

    public async Task<IActionResult> OnPostUploadAsync()
    {
        await using var databaseContext = await _dbContextFactory
            .CreateDbContextAsync()
            .ConfigureAwait(false);

        using var memoryStream = new MemoryStream();

        await FormFile!
            .CopyToAsync(memoryStream)
            .ConfigureAwait(false);

        var entry = new FileEntry { Content = memoryStream.ToArray(), Name = FormFile.FileName, };

        databaseContext.Add(entry);

        await databaseContext
            .SaveChangesAsync()
            .ConfigureAwait(false);

        return Redirect("/");
    }
}
