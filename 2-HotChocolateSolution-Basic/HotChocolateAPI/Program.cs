using Data;
using Data.GraphQL;
using Domain;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// allows GraphQL to use the Pooled dbContext so that we can
// run multiple queries in parallel - thank you Ef Core 5 :)
//
builder.Services.AddPooledDbContextFactory<ApiDataContext>(
    options => options.UseSqlServer(connectionString)
);
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
builder.Services.AddCors(option =>
{
    option.AddPolicy(name: "originPolicy", builder =>
    {
        builder.SetIsOriginAllowed(origin => 
            new Uri(origin).Host == "localhost"
        );
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();

// GraphQL 
//
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

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

// GraphQL 
//
app.MapGraphQL("/graphql");

app.Run();
