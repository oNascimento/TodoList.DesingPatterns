namespace ToDo.List.DesignPattern.Infrastructure.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> Get(long id);
        Task Create(T item);
        Task Update(T item);
        Task Delete(long id);
    }
}