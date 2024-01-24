using RegistroPrioridades.DAL;
using RegistroPrioridades.Models;
using RegistroPrioridades.Migrations;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.InteropServices;


namespace RegistroPrioridades.BLL;

public class PrioridadesBLL
{
    private readonly Contexto context;

    public PrioridadesBLL(Contexto contexto)
    {
        context = contexto;
    }

    public bool Guardar(Prioridades prioridad)
    {
        if (!Existe(prioridad.PrioridadId))
            return Insertar(prioridad);
        else
            return Modificar(prioridad);
    }

    private bool Insertar(Prioridades prioridad)
    {
        context.Prioridades.Add(prioridad);
        int cantidad = context.SaveChanges();
        return cantidad > 0;
    }

    public bool Modificar(Prioridades prioridad)
    {
        context.Update(prioridad);
        int cantidad = context.SaveChanges();
        return cantidad > 0;
    }

    public bool Existe(int PrioridadId)
    {
        return context.Prioridades.Any(p => p.PrioridadId == PrioridadId);
    }

    public bool Eliminar(Prioridades prioridad)
    {
        context.Prioridades.Remove(prioridad);
            int cantidad = context.SaveChanges();
        return cantidad > 0;   
    }

    public Prioridades? Buscar(int PrioridadId)
    {
        return context.Prioridades
            .AsNoTracking()
            .FirstOrDefault(p => p.PrioridadId == PrioridadId);
    }

    public List<Prioridades> GetList(Expression<Func<Prioridades, bool>> criterio)
    {
        return context.Prioridades.Where(criterio).ToList();
    }
        
}
