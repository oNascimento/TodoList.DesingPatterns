using MongoDB.Driver;
using ToDo.List.DesignPattern.Core.Models;

namespace ToDo.List.DesignPattern.Core.Contexts;

public class TodoMongoDbContext
{
    private readonly IMongoDatabase _database;

    public TodoMongoDbContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetConnectionString("MongoDbConnection"));
        _database = client.GetDatabase(configuration["MongoDbSettings:DatabaseName"]);
    }

    public IMongoCollection<TodoItem> TodoItems => _database.GetCollection<TodoItem>("TodoItems");
}