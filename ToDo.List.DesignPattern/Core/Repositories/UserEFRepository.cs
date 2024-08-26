using Microsoft.EntityFrameworkCore;
using ToDo.List.DesignPattern.Core.Contexts;
using ToDo.List.DesignPattern.Core.Models;
using ToDo.List.DesignPattern.Infrastructure.Interfaces;

namespace ToDo.List.DesignPattern.Core.Repositories;

public class UserEFRepository(ILogger<TodoItemEFRepository> logger, TodoContext context) : IEFRepository<User>
{
    private async Task SaveChangesAsync(Action action, string operationName)
    {
        try
        {
            action();
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            var message = $"{nameof(TodoItemEFRepository)}-{operationName}-error";
            logger.LogWarning(message, e);
            throw;
        }
    }

    public async Task Create(User item)
    {
        await SaveChangesAsync(() => context.Add(item), nameof(Create));
    }

    public Task Delete(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> Get(long id)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await context.Users.Where(u => !u.IsDeleted).ToListAsync();
    }

    public async Task Update(User item)
    {
        await SaveChangesAsync(() =>
        {
            context.Entry(item).State = EntityState.Modified;
            context.Update(item);
        }, nameof(Update));
    }
}