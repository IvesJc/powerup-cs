using PowerUp.Data;
using PowerUp.Models;
using PowerUp.Repositories.Interfaces;

namespace PowerUp.Repositories.Impl;

public class RecompensaRepository : IRecompensaRepository
{
    private readonly AppDbContext _context;

    public RecompensaRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Save(RecompensaModel entity)
    {
        _context.Set<RecompensaModel>().Add(entity);
        _context.SaveChanges();
    }

    public RecompensaModel FindById(int id)
    {
        return _context.Set<RecompensaModel>().Find(id);
    }

    public List<RecompensaModel> FindAll()
    {
        return _context.Set<RecompensaModel>().ToList();
    }

    public void DeleteById(int id)
    {
        var recompensa = FindById(id);
        if (recompensa != null)
        {
            _context.Set<RecompensaModel>().Remove(recompensa);
            _context.SaveChanges();
        }
    }

    public bool ExistsById(int id)
    {
        return _context.Set<RecompensaModel>().Any(e => e.Id == id);
    }
}