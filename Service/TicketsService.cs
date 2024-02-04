using RegistroPrioridades.DAL;
using RegistroPrioridades.Models;
using RegistroPrioridades.Migrations;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.InteropServices;



namespace RegistroPrioridades.Service;

public class TicketsService
{
    private readonly Contexto contexto;

    public TicketsService(Contexto contexto)
    {
        contexto = contexto;
    }

    public async Task<bool> Insertar(Ticket tickets)
    {
        contexto.Ticket.Add(tickets);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Ticket tickets)
    {
        contexto.Update(tickets);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Existe(int TicketId)
    {
        return await contexto.Ticket.AnyAsync(t => t.TicketId == TicketId);
    }

    public async Task<bool> Crear(Ticket tickets)
    {
        if (!await Existe(tickets.TicketId))
            return await Insertar(tickets);
        else
            return await Modificar(tickets);
    }

    public async Task<bool> Eliminar(Ticket tickets)
    {
        var cantidad = await contexto.Ticket
            .Where(p => p.TicketId == tickets.TicketId)
            .ExecuteDeleteAsync();

        return cantidad > 0;
    }

    public async Task<Ticket?> Buscar(int TicketId)
    {
        return await contexto.Ticket
            .Where(t => t.TicketId == TicketId)
            .AsNoTracking()
            .SingleOrDefaultAsync();
    }

    public async Task<List<Ticket>> Listar(Expression<Func<Ticket, bool>> Criterio)
    {
        return await contexto.Ticket
            .Where(Criterio)
            .AsNoTracking()
            .ToListAsync();
    }

}
