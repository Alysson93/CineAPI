using CineAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CineAPI.Database;

public class CineDbContext : DbContext
{
    public DbSet<Filme> Filmes { get; set; }

    public CineDbContext(DbContextOptions<CineDbContext> options)
        : base(options) {}
}