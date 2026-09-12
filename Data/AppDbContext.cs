using Microsoft.EntityFrameworkCore;
using Trabalho1DevWebNet.Models;

namespace Trabalho1DevWebNet.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Paciente> Pacientes { get; set; }
}
