using PowerUp.Data;
using PowerUp.Models;
using PowerUp.Repositories.Interfaces;

namespace PowerUp.Repositories.Impl;

public class RecompensaConfigRepository : IRecompensaConfigRepository
{
    private readonly AppDbContext _context;

    public RecompensaConfigRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Save(RecompensaConfigModel entity)
    {
        _context.Set<RecompensaConfigModel>().Add(entity);
        _context.SaveChanges();
    }

    public RecompensaConfigModel FindById(int id)
    {
        return _context.Set<RecompensaConfigModel>().Find(id);
    }

    public List<RecompensaConfigModel> FindAll()
    {
        return _context.Set<RecompensaConfigModel>().ToList();
    }

    public void DeleteById(int id)
    {
        var recompensaConfig = FindById(id);
        if (recompensaConfig != null)
        {
            _context.Set<RecompensaConfigModel>().Remove(recompensaConfig);
            _context.SaveChanges();
        }
    }

    public bool ExistsById(int id)
    {
        return _context.Set<RecompensaConfigModel>().Any(e => e.Id == id);
    }
}