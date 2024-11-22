namespace PowerUp.Repositories;

public interface IRepository<T> where T : class
{
    void Save(T entity);
    T FindById(int id);
    List<T> FindAll();
    void DeleteById(int id);
    bool ExistsById(int id);
}
