using PowerUp.Data;
using PowerUp.Models;
using PowerUp.Repositories.Interfaces;

namespace PowerUp.Repositories.Impl;

public class DesafioRepository : IDesafioRepository
{
    private readonly AppDbContext _context;

    public DesafioRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Save(DesafioModel entity)
    {
        _context.Set<DesafioModel>().Add(entity);
        _context.SaveChanges();
    }

    public DesafioModel FindById(int id)
    {
        return _context.Set<DesafioModel>().Find(id);
    }

    public List<DesafioModel> FindAll()
    {
        return _context.Set<DesafioModel>().ToList();
    }

    public void DeleteById(int id)
    {
        var desafio = FindById(id);
        if (desafio != null)
        {
            _context.Set<DesafioModel>().Remove(desafio);
            _context.SaveChanges();
        }
    }

    public bool ExistsById(int id)
    {
        return _context.Set<DesafioModel>().Any(e => e.Id == id);
    }
}