using PowerUp.Data;
using PowerUp.Models;
using PowerUp.Repositories.Interfaces;

namespace PowerUp.Repositories.Impl;

public class EmblemaTipoRepository : IEmblemaTipoRepository
{
    private readonly AppDbContext _context;

    public EmblemaTipoRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Save(EmblemaTipoModel entity)
    {
        _context.Set<EmblemaTipoModel>().Add(entity);
        _context.SaveChanges();
    }

    public EmblemaTipoModel FindById(int id)
    {
        return _context.Set<EmblemaTipoModel>().Find(id);
    }

    public List<EmblemaTipoModel> FindAll()
    {
        return _context.Set<EmblemaTipoModel>().ToList();
    }

    public void DeleteById(int id)
    {
        var emblemaTipo = FindById(id);
        if (emblemaTipo != null)
        {
            _context.Set<EmblemaTipoModel>().Remove(emblemaTipo);
            _context.SaveChanges();
        }
    }

    public bool ExistsById(int id)
    {
        return _context.Set<EmblemaTipoModel>().Any(e => e.Id == id);
    }
}
