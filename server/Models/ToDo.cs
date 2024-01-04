namespace newInspire.Models;
public class ToDo
{
    public int Id { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool? Completed { get; set; }
    public string CreatorId { get; set; }
    public Account Creator { get; set; }
}