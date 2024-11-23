using PowerUp.Data;
using PowerUp.Models;
using PowerUp.Repositories.Interfaces;

namespace PowerUp.Repositories.Impl;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;

    public UsuarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Save(UsuarioModel entity)
    {
        _context.Set<UsuarioModel>().Add(entity);
        _context.SaveChanges();
    }

    public UsuarioModel FindById(int id)
    {
        return _context.Set<UsuarioModel>().Find(id);
    }

    public List<UsuarioModel> FindAll()
    {
        return _context.Set<UsuarioModel>().ToList();
    }

    public void DeleteById(int id)
    {
        var usuario = FindById(id);
        if (usuario != null)
        {
            _context.Set<UsuarioModel>().Remove(usuario);
            _context.SaveChanges();
        }
    }

    public bool ExistsById(int id)
    {
        return _context.Set<UsuarioModel>().Any(e => e.Id == id);
    }
}