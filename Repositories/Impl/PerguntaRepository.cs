using PowerUp.Data;
using PowerUp.Models;
using PowerUp.Repositories.Interfaces;

namespace PowerUp.Repositories.Impl;

public class PerguntaRepository : IPerguntaRepository
{
    private readonly AppDbContext _context;

    public PerguntaRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Save(PerguntaModel entity)
    {
        _context.Set<PerguntaModel>().Add(entity);
        _context.SaveChanges();
    }

    public PerguntaModel FindById(int id)
    {
        return _context.Set<PerguntaModel>().Find(id);
    }

    public List<PerguntaModel> FindAll()
    {
        return _context.Set<PerguntaModel>().ToList();
    }

    public void DeleteById(int id)
    {
        var pergunta = FindById(id);
        if (pergunta != null)
        {
            _context.Set<PerguntaModel>().Remove(pergunta);
            _context.SaveChanges();
        }
    }

    public bool ExistsById(int id)
    {
        return _context.Set<PerguntaModel>().Any(e => e.Id == id);
    }
}