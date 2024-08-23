namespace ToDo.List.DesignPattern.Core.Models.DTOs;
public class TodoItemDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime DueDate { get; set; }
}