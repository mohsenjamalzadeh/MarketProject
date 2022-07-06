namespace BlogManagement.Application.Contracts.Author;

public class AuthorViewModel
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Picture { get; set; }
    public string? Description { get; set; }
}