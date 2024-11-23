using PowerUp.Data;
using PowerUp.Models;
using PowerUp.Repositories.Interfaces;

namespace PowerUp.Repositories.Impl;

public class MissaoConfigRepository : IMissaoConfigRepository
{
    private readonly AppDbContext _context;

    public MissaoConfigRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Save(MissaoConfigModel entity)
    {
        _context.Set<MissaoConfigModel>().Add(entity);
        _context.SaveChanges();
    }

    public MissaoConfigModel FindById(int id)
    {
        return _context.Set<MissaoConfigModel>().Find(id);
    }

    public List<MissaoConfigModel> FindAll()
    {
        return _context.Set<MissaoConfigModel>().ToList();
    }

    public void DeleteById(int id)
    {
        var missaoConfig = FindById(id);
        if (missaoConfig != null)
        {
            _context.Set<MissaoConfigModel>().Remove(missaoConfig);
            _context.SaveChanges();
        }
    }

    public bool ExistsById(int id)
    {
        return _context.Set<MissaoConfigModel>().Any(e => e.Id == id);
    }
}