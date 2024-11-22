namespace PowerUp.Repositories;

public interface IRepositoryIdComposto<T> where T : class
{
    void Save(T entity);
    T FindById(object id);
    List<T> FindAll();
    void DeleteById(object id);
    bool ExistsById(object id);
}
