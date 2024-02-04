using RegistroPrioridades.DAL;
using RegistroPrioridades.Models;
using RegistroPrioridades.Migrations;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.InteropServices;


namespace RegistroPrioridades.Service;

public class ClientesService
{
    private readonly Contextos _contexto;

    public ClientesService(Contextos contexto)
    {
        _contexto = contexto;
    }

    public async Task<bool> Insertar(Clientes clientes)
    {
        _contexto.Cliente.Add(clientes);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Clientes clientes)
    {
        _contexto.Update(clientes);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Existe(int ClienteId)
    {
        return await _contexto.Cliente.AnyAsync(t => t.ClienteId == ClienteId);
    }

    public async Task<bool> Crear(Clientes clientes)
    {
        if (!await Existe(clientes.ClienteId))
            return await Insertar(clientes);
        else
            return await Modificar(clientes);
    }

    public async Task<bool> Eliminar(Clientes clientes)
    {
        var cantidad = await _contexto.Cliente
            .Where(p => p.ClienteId == clientes.ClienteId)
            .ExecuteDeleteAsync();

        return cantidad > 0;
    }

    public async Task<Clientes?> Buscar(int ClienteId)
    {
        return await _contexto.Cliente
            .Where(t => t.ClienteId == ClienteId)
            .AsNoTracking()
            .SingleOrDefaultAsync();
    }

    public async Task<List<Clientes>> Listar(Expression<Func<Clientes, bool>> Criterio)
    {
        return await _contexto.Cliente
            .Where(Criterio)
            .AsNoTracking()
            .ToListAsync();
    }

}
