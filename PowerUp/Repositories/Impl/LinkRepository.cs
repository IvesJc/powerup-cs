using PowerUp.Data;
using PowerUp.Models;
using PowerUp.Repositories.Interfaces;

namespace PowerUp.Repositories.Impl;

public class LinkRepository : ILinkRepository
{
    private readonly AppDbContext _context;

    public LinkRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Save(LinkModel entity)
    {
        _context.Set<LinkModel>().Add(entity);
        _context.SaveChanges();
    }

    public LinkModel FindById(int id)
    {
        return _context.Set<LinkModel>().Find(id);
    }

    public List<LinkModel> FindAll()
    {
        return _context.Set<LinkModel>().ToList();
    }

    public void DeleteById(int id)
    {
        var link = FindById(id);
        if (link != null)
        {
            _context.Set<LinkModel>().Remove(link);
            _context.SaveChanges();
        }
    }

    public bool ExistsById(int id)
    {
        return _context.Set<LinkModel>().Any(e => e.Id == id);
    }
}
