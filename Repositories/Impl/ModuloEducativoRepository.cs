using PowerUp.Data;
using PowerUp.Models;
using PowerUp.Repositories.Interfaces;

namespace PowerUp.Repositories.Impl;

public class ModuloEducativoRepository : IModuloEducativoRepository
{
    private readonly AppDbContext _context;

    public ModuloEducativoRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Save(ModuloEducativoModel entity)
    {
        _context.Set<ModuloEducativoModel>().Add(entity);
        _context.SaveChanges();
    }

    public ModuloEducativoModel FindById(int id)
    {
        return _context.Set<ModuloEducativoModel>().Find(id);
    }

    public List<ModuloEducativoModel> FindAll()
    {
        return _context.Set<ModuloEducativoModel>().ToList();
    }

    public void DeleteById(int id)
    {
        var moduloEducativo = FindById(id);
        if (moduloEducativo != null)
        {
            _context.Set<ModuloEducativoModel>().Remove(moduloEducativo);
            _context.SaveChanges();
        }
    }

    public bool ExistsById(int id)
    {
        return _context.Set<ModuloEducativoModel>().Any(e => e.Id == id);
    }
}