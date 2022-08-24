using AspFileUpload.Storage;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContextFactory<AppDbContext>(x => x.UseSqlite("Data Source=app.db"));

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});

app.Run();
