using ToDo.List.DesignPattern.Core.Models;

namespace ToDo.List.DesignPattern.Infrastructure.Interfaces;

public interface IEFUserRepository : IEFRepository<User>
{
    Task<bool> IsValidUserPassword(string user, string password);
}