namespace ToDo.List.DesignPattern.Core.Models;

public class User
{
    public required long Id { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? Name { get; set; }
    public bool IsDeleted { get; set; }
}