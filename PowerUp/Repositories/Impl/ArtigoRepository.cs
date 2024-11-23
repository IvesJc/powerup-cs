using PowerUp.Data;
using PowerUp.Models;
using PowerUp.Repositories.Interfaces;

namespace PowerUp.Repositories.Impl;

public class ArtigoRepository : IArtigoRepository
{
    private readonly AppDbContext _context;

    public ArtigoRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Save(ArtigoModel entity)
    {
        _context.Set<ArtigoModel>().Add(entity);
        _context.SaveChanges();
    }

    public ArtigoModel FindById(int id)
    {
        return _context.Set<ArtigoModel>().Find(id);
    }

    public List<ArtigoModel> FindAll()
    {
        return _context.Set<ArtigoModel>().ToList();
    }

    public void DeleteById(int id)
    {
        var artigo = FindById(id);
        if (artigo != null)
        {
            _context.Set<ArtigoModel>().Remove(artigo);
            _context.SaveChanges();
        }
    }

    public bool ExistsById(int id)
    {
        return _context.Set<ArtigoModel>().Any(e => e.Id == id);
    }
}
