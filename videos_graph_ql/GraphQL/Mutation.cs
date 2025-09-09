using videos_graph_ql.Data;
using videos_graph_ql.Models;
using Microsoft.EntityFrameworkCore;

namespace videos_graph_ql.GraphQL;

public class Mutation
{
    public async Task<Movie> AddMovie(string title, int year, double rating, AppDbContext db)
    {
        var movie = new Movie { Title = title, Year = year, Rating = rating };
        db.Movies.Add(movie);
        await db.SaveChangesAsync();
        return movie;
    }

    public async Task<Movie?> UpdateMovie(int id, string? title, int? year, double? rating, AppDbContext db)
    {
        var m = await db.Movies.FirstOrDefaultAsync(x => x.Id == id);
        if (m is null) return null;

        if (!string.IsNullOrWhiteSpace(title)) m.Title = title;
        if (year.HasValue) m.Year = year.Value;
        if (rating.HasValue) m.Rating = rating.Value;

        await db.SaveChangesAsync();
        return m;
    }

    public async Task<bool> DeleteMovie(int id, AppDbContext db)
    {
        var m = await db.Movies.FirstOrDefaultAsync(x => x.Id == id);
        if (m is null) return false;
        db.Remove(m);
        await db.SaveChangesAsync();
        return true;
    }
}