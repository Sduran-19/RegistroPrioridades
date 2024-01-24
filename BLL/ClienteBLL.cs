using RegistroPrioridades.DAL;
using RegistroPrioridades.Models;
using RegistroPrioridades.Migrations;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.InteropServices;


namespace RegistroPrioridades.BLL;

public class ClienteBLL
{
    private readonly Contexto _contexto;

    public ClienteBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public bool Guardar(Cliente cliente)
    {
        if (!Existe(cliente.ClienteId))
            return Insertar(cliente);
        else
            return Modificar(cliente);
    }

    private bool Insertar(Cliente cliente)
    {
        _contexto.Cliente.Add(cliente);
        int cantidad = _contexto.SaveChanges();
        return cantidad > 0;
    }

    public bool Modificar(Cliente cliente)
    {
        _contexto.Update(cliente);
        int cantidad = _contexto.SaveChanges();
        return cantidad > 0;
    }

    public bool Existe(int ClienteId)
    {
        return  _contexto.Cliente.Any(p => p.ClienteId == ClienteId);
    }

    public bool Eliminar(Cliente prioridad)
    {
        _contexto.Cliente.Remove(prioridad);
            int cantidad = _contexto.SaveChanges();
        return cantidad > 0;   
    }

    public Cliente? Buscar(int ClienteId)
    {
        return _contexto.Cliente
            .AsNoTracking()
            .FirstOrDefault(p => p.ClienteId == ClienteId);
    }

    public List<Cliente> GetList(Expression<Func<Cliente, bool>> criterio)
    {
        return _contexto.Cliente.Where(criterio).ToList();
    }
        
}
