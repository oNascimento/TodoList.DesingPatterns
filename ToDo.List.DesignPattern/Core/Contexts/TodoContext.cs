using Microsoft.EntityFrameworkCore;
using ToDo.List.DesignPattern.Core.Models;

namespace ToDo.List.DesignPattern.Core.Contexts;
public class TodoContext(DbContextOptions<TodoContext> options) : DbContext(options)
{
    public DbSet<TodoItem> TodoItems { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}