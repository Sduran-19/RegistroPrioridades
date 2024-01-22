using RegistroPrioridades.DAL;
using RegistroPrioridades.Models;
using RegistroPrioridades.Migrations;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.InteropServices;


namespace RegistroPrioridades.BLL;

public class PrioridadesBLL
{
    private readonly Contexto contexto;

    public PrioridadesBLL(Contexto contexto)
    {
        contexto = contexto;
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
        contexto.Prioridades.Add(prioridad);
        int cantidad = contexto.SaveChanges();
        return cantidad > 0;
    }

    public bool Modificar(Prioridades prioridad)
    {
        contexto.Update(prioridad);
        int cantidad = contexto.SaveChanges();
        return cantidad > 0;
    }

    public bool Existe(int PrioridadId)
    {
        return  contexto.Prioridades.Any(p => p.PrioridadId == PrioridadId);
    }

    public bool Eliminar(Prioridades prioridad)
    {
        contexto.Prioridades.Remove(prioridad);
            int cantidad = contexto.SaveChanges();
        return cantidad > 0;   
    }

    public Prioridades? Buscar(int prioridadId)
    {
        return contexto.Prioridades
            .AsNoTracking()
            .FirstOrDefault(p => p.PrioridadId == prioridadId);
    }

    public List<Prioridades> GetList(Expression<Func<Prioridades, bool>> criterio)
    {
        return contexto.Prioridades.Where(criterio).ToList();
    }
        
}
