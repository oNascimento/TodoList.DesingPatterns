namespace ToDo.List.DesignPattern.Infrastructure.Interfaces;

public interface INoSqlRepository<T> : IRepository<T> where T : class
{
}