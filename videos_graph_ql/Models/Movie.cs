namespace videos_graph_ql.Models;

public class Movie
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public int Year { get; set; }
    public double Rating { get; set; }
}