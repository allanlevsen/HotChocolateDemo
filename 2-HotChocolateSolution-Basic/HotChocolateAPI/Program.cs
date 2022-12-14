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
builder.Services.AddCors();

builder.Services.AddEndpointsApiExplorer();

// GraphQL 
//

// stage 1
//
//builder.Services.AddGraphQLServer()
//    .AddQueryType<Query>();

// stage 2
//
//builder.Services.AddGraphQLServer()
//    .AddQueryType<Query>()
//    .AddFiltering()
//    .AddSorting();

// stage 3
//
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors(x => x
   .AllowAnyOrigin()
   .AllowAnyMethod()
   .AllowAnyHeader());

app.MapControllers();

// GraphQL 
//
app.MapGraphQL("/graphql");

app.Run();
