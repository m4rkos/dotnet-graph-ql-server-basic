using videos_graph_ql.Data;
using videos_graph_ql.GraphQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using videos_graph_ql.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("catalog"));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddFiltering()
    .AddSorting()
    //.AddApolloTracing()        // diagnóstico útil em dev
    .ModifyRequestOptions(o => o.IncludeExceptionDetails = true); // exibir erros em dev

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (!db.Movies.Any())
    {
        db.Movies.AddRange(
            new Movie { Title = "Blade Runner 2049", Year = 2017, Rating = 8.0 },
            new Movie { Title = "Dune: Part Two",   Year = 2024, Rating = 8.6 },
            new Movie { Title = "The Matrix",       Year = 1999, Rating = 8.7 },
            new Movie { Title = "Arrival",          Year = 2016, Rating = 7.9 }
        );
        await db.SaveChangesAsync();
    }
}

app.MapGraphQL("/graphql");
app.MapGet("/", () => "GraphQL up. Vá para /graphql");

app.Run();