using PowerUp.Data;
using PowerUp.Models;
using PowerUp.Repositories.Interfaces;

namespace PowerUp.Repositories.Impl;

public class EmblemaConfigRepository : IEmblemaConfigRepository
{
    private readonly AppDbContext _context;

    public EmblemaConfigRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Save(EmblemaConfigModel entity)
    {
        _context.Set<EmblemaConfigModel>().Add(entity);
        _context.SaveChanges();
    }

    public EmblemaConfigModel FindById(int id)
    {
        return _context.Set<EmblemaConfigModel>().Find(id);
    }

    public List<EmblemaConfigModel> FindAll()
    {
        return _context.Set<EmblemaConfigModel>().ToList();
    }

    public void DeleteById(int id)
    {
        var emblemaConfig = FindById(id);
        if (emblemaConfig != null)
        {
            _context.Set<EmblemaConfigModel>().Remove(emblemaConfig);
            _context.SaveChanges();
        }
    }

    public bool ExistsById(int id)
    {
        return _context.Set<EmblemaConfigModel>().Any(e => e.Id == id);
    }
}