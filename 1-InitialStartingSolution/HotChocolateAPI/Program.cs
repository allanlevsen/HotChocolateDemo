using Data;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContextFactory<ApiDataContext>(
    options => options.UseSqlServer(connectionString)
);
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
builder.Services.AddCors(option =>
{
    option.AddPolicy(name: "originPolicy", builder =>
    {
        builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// if environment is development and the database if empty -> seed data
//
if (app.Environment.IsDevelopment())
{
    await ApiDataContext.CheckAndSeedDatabaseAsync(
        app.Services
        .GetRequiredService<IDbContextFactory<ApiDataContext>>()
        .CreateDbContext()
    );
}

app.UseHttpsRedirection();
app.UseCors("originPolicy");

app.MapControllers();
app.Run();
