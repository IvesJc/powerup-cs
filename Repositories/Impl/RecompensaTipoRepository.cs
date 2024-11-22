using PowerUp.Data;
using PowerUp.Models;
using PowerUp.Repositories.Interfaces;

namespace PowerUp.Repositories.Impl;

public class RecompensaTipoRepository : IRecompensaTipoRepository
{
    private readonly AppDbContext _context;

    public RecompensaTipoRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Save(RecompensaTipoModel entity)
    {
        _context.Set<RecompensaTipoModel>().Add(entity);
        _context.SaveChanges();
    }

    public RecompensaTipoModel FindById(int id)
    {
        return _context.Set<RecompensaTipoModel>().Find(id);
    }

    public List<RecompensaTipoModel> FindAll()
    {
        return _context.Set<RecompensaTipoModel>().ToList();
    }

    public void DeleteById(int id)
    {
        var recompensaTipo = FindById(id);
        if (recompensaTipo != null)
        {
            _context.Set<RecompensaTipoModel>().Remove(recompensaTipo);
            _context.SaveChanges();
        }
    }

    public bool ExistsById(int id)
    {
        return _context.Set<RecompensaTipoModel>().Any(e => e.Id == id);
    }
}