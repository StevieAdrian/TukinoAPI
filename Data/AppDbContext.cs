
using Microsoft.EntityFrameworkCore;
using TukinoAPI.Model;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

  public DbSet<Anime> Animes { get; set; }
}