﻿using RegistroPrioridades.DAL;
using RegistroPrioridades.Models;
using RegistroPrioridades.Migrations;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.InteropServices;


namespace RegistroPrioridades.Service;

public class PrioridadesService
{
    private readonly Contextos context;


    public PrioridadesService(Contextos contexto)
    {
        context = contexto;
    }

    public async Task<bool> Insertar(Prioridades clientes)
    {
        context.Prioridades.Add(clientes);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Prioridades clientes)
    {
        context.Update(clientes);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Existe(int ClienteId)
    {
        return await context.Prioridades.AnyAsync(t => t.PrioridadId == ClienteId);
    }

    public async Task<bool> Crear(Prioridades prioridades)
    {
        if (!await Existe(prioridades.PrioridadId))
        {
            return await Insertar(prioridades);
        }
        else
        {
            return await Modificar(prioridades);
        }
    }

    public async Task<bool> Eliminar(Prioridades clientes)
    {
        var cantidad = await context.Prioridades
            .Where(p => p.PrioridadId == clientes.PrioridadId)
            .ExecuteDeleteAsync();

        return cantidad > 0;
    }

    public async Task<Prioridades?> Buscar(int PrioridadId)
    {
        return await context.Prioridades
            .Where(t => t.PrioridadId == PrioridadId)
            .AsNoTracking()
            .SingleOrDefaultAsync();
    }

    public async Task<List<Prioridades>> Listar(Expression<Func<Prioridades, bool>> Criterio)
    {
        return await context.Prioridades
            .Where(Criterio)
            .AsNoTracking()
            .ToListAsync();
    }

}
