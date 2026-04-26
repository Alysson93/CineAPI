using CineAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CineAPI.Database;

public class CineDbContext : DbContext
{
    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Sessao> Sessoes { get; set; }

    public CineDbContext(DbContextOptions<CineDbContext> options)
        : base(options) {}
}