using PowerUp.Data;
using PowerUp.Models;
using PowerUp.Repositories.Interfaces;

namespace PowerUp.Repositories.Impl;

public class MissaoArtigoRepository : IMissaoArtigoRepository
{
    private readonly AppDbContext _context;

    public MissaoArtigoRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Save(MissaoArtigoModel entity)
    {
        _context.Set<MissaoArtigoModel>().Add(entity);
        _context.SaveChanges();
    }

    public MissaoArtigoModel FindById(object id)
    {
        if (id is MissaoArtigoIdModel missaoArtigoId)
        {
            return _context.Set<MissaoArtigoModel>()
                .Find(id);
        }
        throw new ArgumentException("ID type is invalid", nameof(id));
    }

    public List<MissaoArtigoModel> FindAll()
    {
        return _context.Set<MissaoArtigoModel>().ToList();
    }

    public void DeleteById(object id)
    {
        if (id is MissaoArtigoIdModel missaoArtigoId)
        {
            var entity = _context.Set<MissaoArtigoModel>()
                .Find(id);
            if (entity != null)
            {
                _context.Set<MissaoArtigoModel>().Remove(entity);
                _context.SaveChanges();
            }
        }
        else
        {
            throw new ArgumentException("ID type is invalid", nameof(id));
        }
    }

    public bool ExistsById(object id)
    {
        if (id is MissaoArtigoIdModel missaoArtigoId)
        {
            return _context.Set<MissaoArtigoModel>()
                .Any(e => e.MissaoId == missaoArtigoId.MissaoId && e.ArtigoId == missaoArtigoId.ArtigoId);
        }
        throw new ArgumentException("ID type is invalid", nameof(id));
    }
}
