using PowerUp.Data;
using PowerUp.Models;
using PowerUp.Repositories.Interfaces;

namespace PowerUp.Repositories.Impl;

public class MissaoRepository : IMissaoRepository
{
    private readonly AppDbContext _context;

    public MissaoRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Save(MissaoModel entity)
    {
        _context.Set<MissaoModel>().Add(entity);
        _context.SaveChanges();
    }

    public MissaoModel FindById(int id)
    {
        return _context.Set<MissaoModel>().Find(id);
    }

    public List<MissaoModel> FindAll()
    {
        return _context.Set<MissaoModel>().ToList();
    }

    public void DeleteById(int id)
    {
        var missao = FindById(id);
        if (missao != null)
        {
            _context.Set<MissaoModel>().Remove(missao);
            _context.SaveChanges();
        }
    }

    public bool ExistsById(int id)
    {
        return _context.Set<MissaoModel>().Any(e => e.Id == id);
    }
}