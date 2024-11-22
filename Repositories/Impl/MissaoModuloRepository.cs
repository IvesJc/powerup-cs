using PowerUp.Data;
using PowerUp.Models;
using PowerUp.Repositories.Interfaces;

namespace PowerUp.Repositories.Impl;

public class MissaoModuloRepository : IMissaoModuloRepository
{
    private readonly AppDbContext _context;

    public MissaoModuloRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Save(MissaoModuloModel entity)
    {
        _context.Set<MissaoModuloModel>().Add(entity);
        _context.SaveChanges();
    }

    public MissaoModuloModel FindById(object id)
    {
        if (id is MissaoModuloIdModel missaoModuloId)
        {
            return _context.Set<MissaoModuloModel>()
                .FirstOrDefault(e => e.Id.MissaoId == missaoModuloId.MissaoId && e.Id.ModuloEducativoId == missaoModuloId.ModuloEducativoId);
        }
        throw new ArgumentException("ID type is invalid", nameof(id));
    }

    public List<MissaoModuloModel> FindAll()
    {
        return _context.Set<MissaoModuloModel>().ToList();
    }

    public void DeleteById(object id)
    {
        if (id is MissaoModuloIdModel missaoModuloId)
        {
            var entity = _context.Set<MissaoModuloModel>()
                .FirstOrDefault(e => e.Id.MissaoId == missaoModuloId.MissaoId && e.Id.ModuloEducativoId == missaoModuloId.ModuloEducativoId);

            if (entity != null)
            {
                _context.Set<MissaoModuloModel>().Remove(entity);
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
        if (id is MissaoModuloIdModel missaoModuloId)
        {
            return _context.Set<MissaoModuloModel>()
                .Any(e => e.Id.MissaoId == missaoModuloId.MissaoId && e.Id.ModuloEducativoId == missaoModuloId.ModuloEducativoId);
        }
        throw new ArgumentException("ID type is invalid", nameof(id));
    }
}