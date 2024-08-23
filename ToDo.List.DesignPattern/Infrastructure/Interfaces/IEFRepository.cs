namespace ToDo.List.DesignPattern.Infrastructure.Interfaces;

public interface IEFRepository<T> : IRepository<T> where T : class
{
}