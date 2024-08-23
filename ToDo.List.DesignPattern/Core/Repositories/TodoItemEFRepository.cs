using Microsoft.EntityFrameworkCore;
using ToDo.List.DesignPattern.Core.Contexts;
using ToDo.List.DesignPattern.Core.Models;
using ToDo.List.DesignPattern.Infrastructure.Interfaces;

namespace ToDo.List.DesignPattern.Core.Repositories;

public class TodoItemEFRepository(ILogger<TodoItemEFRepository> logger, TodoContext context) : IEFRepository<TodoItem>
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
            var message = $"{nameof(TodoItemEFRepository)}-{operationName}";
            logger.LogWarning(message, e);
            throw;
        }
    }

    public async Task Create(TodoItem item)
    {
        await SaveChangesAsync(() => context.TodoItems.Add(item), nameof(Create));
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
        return await context.TodoItems.FirstOrDefaultAsync(todoItem => todoItem.Id == id);
    }

    public async Task<IEnumerable<TodoItem>> GetAllAsync()
    {
        return await context.TodoItems.Where(todoItem => !todoItem.IsDeleted).ToListAsync();
    }

    public async Task Update(TodoItem item)
    {
        context.Entry(item).State = EntityState.Modified;
        await SaveChangesAsync(() => context.TodoItems.Update(item), nameof(Update));
    }
}