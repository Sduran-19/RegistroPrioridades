using Microsoft.EntityFrameworkCore;
using RegistroPrioridades.Models;

namespace RegistroPrioridades.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options)
        : base(options) { }
    public DbSet<Prioridades> Prioridades { get; set; } 
    public DbSet<Cliente> Cliente { get; set; }

    public DbSet<Ticket> Ticket { get; set; }

}
