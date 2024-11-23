using PowerUp.Data;
using PowerUp.Models;
using PowerUp.Repositories.Interfaces;

namespace PowerUp.Repositories.Impl;

public class QuizRepository : IQuizRepository
{
    private readonly AppDbContext _context;

    public QuizRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Save(QuizModel entity)
    {
        _context.Set<QuizModel>().Add(entity);
        _context.SaveChanges();
    }

    public QuizModel FindById(int id)
    {
        return _context.Set<QuizModel>().Find(id);
    }

    public List<QuizModel> FindAll()
    {
        return _context.Set<QuizModel>().ToList();
    }

    public void DeleteById(int id)
    {
        var quiz = FindById(id);
        if (quiz != null)
        {
            _context.Set<QuizModel>().Remove(quiz);
            _context.SaveChanges();
        }
    }

    public bool ExistsById(int id)
    {
        return _context.Set<QuizModel>().Any(e => e.Id == id);
    }
}