using PowerUp.Data;
using PowerUp.Models;
using PowerUp.Repositories.Interfaces;

namespace PowerUp.Repositories.Impl;

public class UsuarioPermissaoRepository : IUsuarioPermissaoRepository
{
    private readonly AppDbContext _context;

    public UsuarioPermissaoRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Save(UsuarioPermissaoModel entity)
    {
        _context.Set<UsuarioPermissaoModel>().Add(entity);
        _context.SaveChanges();
    }

    public UsuarioPermissaoModel FindById(object id)
    {
        if (id is UsuarioPermissaoIdModel usuarioPermissaoId)
        {
            return _context.Set<UsuarioPermissaoModel>()
                .FirstOrDefault(e => e.Id.UsuarioId == usuarioPermissaoId.UsuarioId && e.Id.PermissaoId == usuarioPermissaoId.PermissaoId);
        }
        throw new ArgumentException("ID type is invalid", nameof(id));
    }

    public List<UsuarioPermissaoModel> FindAll()
    {
        return _context.Set<UsuarioPermissaoModel>().ToList();
    }

    public void DeleteById(object id)
    {
        if (id is UsuarioPermissaoIdModel usuarioPermissaoId)
        {
            var entity = _context.Set<UsuarioPermissaoModel>()
                .FirstOrDefault(e => e.Id.UsuarioId == usuarioPermissaoId.UsuarioId && e.Id.PermissaoId == usuarioPermissaoId.PermissaoId);

            if (entity != null)
            {
                _context.Set<UsuarioPermissaoModel>().Remove(entity);
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
        if (id is UsuarioPermissaoIdModel usuarioPermissaoId)
        {
            return _context.Set<UsuarioPermissaoModel>()
                .Any(e => e.Id.UsuarioId == usuarioPermissaoId.UsuarioId && e.Id.PermissaoId == usuarioPermissaoId.PermissaoId);
        }
        throw new ArgumentException("ID type is invalid", nameof(id));
    }
}