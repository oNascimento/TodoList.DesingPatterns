using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ToDo.List.DesignPattern.Core.Models;

public class TodoItem
{
    
    public long Id { get; set; }
    
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string UUId { get; set; }

    [BsonElement("Title")]
    public string? Title { get; set; }

    [BsonElement("Description")]
    public string? Description { get; set; }

    [BsonElement("IsCompleted")]
    public bool IsCompleted { get; set; }

    [BsonElement("IsDeleted")]
    public bool IsDeleted { get; set; }
    [BsonElement("DueDate")]
    public DateTime DueDate { get; set; }
}
