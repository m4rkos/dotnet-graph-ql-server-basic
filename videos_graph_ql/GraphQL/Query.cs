using videos_graph_ql.Data;
using videos_graph_ql.Models;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;

namespace videos_graph_ql.GraphQL;

public class Query
{
    // IQueryable para habilitar filtering/sorting do HotChocolate
    [UsePaging(IncludeTotalCount = true)]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Movie> GetMovies(AppDbContext db) => db.Movies;

    public async Task<Movie?> GetMovieById(int id, AppDbContext db) =>
        await db.Movies.Where(m => m.Id == id).FirstOrDefaultAsync();
}