using Microsoft.EntityFrameworkCore;
using RegistroPrioridades.Models;

namespace RegistroPrioridades.DAL;

public class Contextos : DbContext
{
    public Contextos(DbContextOptions<Contextos> options)
        : base(options) { }
    public DbSet<Prioridades> Prioridades { get; set; } 
    public DbSet<Clientes> Cliente { get; set; }

    public DbSet<Tickets> Ticket { get; set; }

}
