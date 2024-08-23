using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using ToDo.List.DesignPattern.Core.Contexts;
using ToDo.List.DesignPattern.Core.Models;
using ToDo.List.DesignPattern.Infrastructure.Interfaces;

namespace ToDo.List.DesignPattern.Core.Repositories;

public class TodoItemNoSqlRepository(ILogger logger, TodoMongoDbContext context) : INoSqlRepository<TodoItem>
{
    private async Task SaveChangesAsync(Action action, string operationName)
    {
        try
        {
            action();
        }
        catch (Exception e)
        {
            var message = $"{nameof(TodoItemNoSqlRepository)}-{operationName}";
            logger.LogWarning(message, e);
            throw;
        }
    }

    public async Task Create(TodoItem item)
    {
        await SaveChangesAsync(() => context.TodoItems.InsertOneAsync(item), nameof(Create));
    }

    public async Task Delete(long id)
    {
        var todoItem = await Get(id);
        
        if(todoItem != null)
        {
            todoItem.IsDeleted = true;
            await Update(todoItem);
        }
    }

    public async Task<TodoItem?> Get(long id)
    {
        return await context.TodoItems.Find(item => item.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<TodoItem>> GetAllAsync()
    {
        return await context.TodoItems.Find(item => !item.IsDeleted).ToListAsync();
    }

    public async Task Update(TodoItem item)
    {
        await SaveChangesAsync(() => context.TodoItems.ReplaceOneAsync(i => i.Id == item.Id, item), nameof(Update));
    }
}