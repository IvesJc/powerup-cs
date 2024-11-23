using PowerUp.Data;
using PowerUp.Models;
using PowerUp.Repositories.Interfaces;

namespace PowerUp.Repositories.Impl;

public class RankingRepository : IRankingRepository
{
    private readonly AppDbContext _context;

    public RankingRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Save(RankingModel entity)
    {
        _context.Set<RankingModel>().Add(entity);
        _context.SaveChanges();
    }

    public RankingModel FindById(int id)
    {
        return _context.Set<RankingModel>().Find(id);
    }

    public List<RankingModel> FindAll()
    {
        return _context.Set<RankingModel>().ToList();
    }

    public void DeleteById(int id)
    {
        var ranking = FindById(id);
        if (ranking != null)
        {
            _context.Set<RankingModel>().Remove(ranking);
            _context.SaveChanges();
        }
    }

    public bool ExistsById(int id)
    {
        return _context.Set<RankingModel>().Any(e => e.Id == id);
    }
}