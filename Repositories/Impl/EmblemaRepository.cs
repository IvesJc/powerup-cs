using PowerUp.Data;
using PowerUp.Models;
using PowerUp.Repositories.Interfaces;

namespace PowerUp.Repositories.Impl;

public class EmblemaRepository : IEmblemaRepository
{
    private readonly AppDbContext _context;

    public EmblemaRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Save(EmblemaModel entity)
    {
        _context.Set<EmblemaModel>().Add(entity);
        _context.SaveChanges();
    }

    public EmblemaModel FindById(int id)
    {
        return _context.Set<EmblemaModel>().Find(id);
    }

    public List<EmblemaModel> FindAll()
    {
        return _context.Set<EmblemaModel>().ToList();
    }

    public void DeleteById(int id)
    {
        var emblema = FindById(id);
        if (emblema != null)
        {
            _context.Set<EmblemaModel>().Remove(emblema);
            _context.SaveChanges();
        }
    }

    public bool ExistsById(int id)
    {
        return _context.Set<EmblemaModel>().Any(e => e.Id == id);
    }
}