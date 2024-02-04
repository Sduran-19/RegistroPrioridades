using RegistroPrioridades.DAL;
using RegistroPrioridades.Models;
using RegistroPrioridades.Migrations;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.InteropServices;


namespace RegistroPrioridades.Service;

public class ClienteService
{
    private readonly Contexto _contexto;

    public ClienteService(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<bool> Insertar(Cliente clientes)
    {
        _contexto.Cliente.Add(clientes);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Cliente clientes)
    {
        _contexto.Update(clientes);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Existe(int ClienteId)
    {
        return await _contexto.Cliente.AnyAsync(t => t.ClienteId == ClienteId);
    }

    public async Task<bool> Crear(Cliente clientes)
    {
        if (!await Existe(clientes.ClienteId))
            return await Insertar(clientes);
        else
            return await Modificar(clientes);
    }

    public async Task<bool> Eliminar(Cliente clientes)
    {
        var cantidad = await _contexto.Cliente
            .Where(p => p.ClienteId == clientes.ClienteId)
            .ExecuteDeleteAsync();

        return cantidad > 0;
    }

    public async Task<Cliente?> Buscar(int ClienteId)
    {
        return await _contexto.Cliente
            .Where(t => t.ClienteId == ClienteId)
            .AsNoTracking()
            .SingleOrDefaultAsync();
    }

    public async Task<List<Cliente>> Listar(Expression<Func<Cliente, bool>> Criterio)
    {
        return await _contexto.Cliente
            .Where(Criterio)
            .AsNoTracking()
            .ToListAsync();
    }

}
