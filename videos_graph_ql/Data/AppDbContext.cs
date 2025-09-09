using Microsoft.EntityFrameworkCore;
using videos_graph_ql.Models;

namespace videos_graph_ql.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies => Set<Movie>();
}