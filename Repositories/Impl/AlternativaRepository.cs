using PowerUp.Data;
using PowerUp.Models;
using PowerUp.Repositories.Interfaces;

namespace PowerUp.Repositories.Impl;

public class AlternativaRepository : IAlternativaRepository
{
    private readonly AppDbContext _context;

    public AlternativaRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Save(AlternativaModel entity)
    {
        _context.Set<AlternativaModel>().Add(entity);
        _context.SaveChanges();
    }

    public AlternativaModel FindById(int id)
    {
        return _context.Set<AlternativaModel>().Find(id);
    }

    public List<AlternativaModel> FindAll()
    {
        return _context.Set<AlternativaModel>().ToList();
    }

    public void DeleteById(int id)
    {
        var alternativa = FindById(id);
        if (alternativa != null)
        {
            _context.Set<AlternativaModel>().Remove(alternativa);
            _context.SaveChanges();
        }
    }

    public bool ExistsById(int id)
    {
        return _context.Set<AlternativaModel>().Any(e => e.Id == id);
    }
}
