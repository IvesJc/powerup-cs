using PowerUp.Data;
using PowerUp.Models;
using PowerUp.Repositories.Interfaces;

namespace PowerUp.Repositories.Impl;

public class PermissaoRepository : IPermissaoRepository
{
    private readonly AppDbContext _context;

    public PermissaoRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Save(PermissaoModel entity)
    {
        _context.Set<PermissaoModel>().Add(entity);
        _context.SaveChanges();
    }

    public PermissaoModel FindById(int id)
    {
        return _context.Set<PermissaoModel>().Find(id);
    }

    public List<PermissaoModel> FindAll()
    {
        return _context.Set<PermissaoModel>().ToList();
    }

    public void DeleteById(int id)
    {
        var permissao = FindById(id);
        if (permissao != null)
        {
            _context.Set<PermissaoModel>().Remove(permissao);
            _context.SaveChanges();
        }
    }

    public bool ExistsById(int id)
    {
        return _context.Set<PermissaoModel>().Any(e => e.Id == id);
    }
}