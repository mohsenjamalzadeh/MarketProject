using Microsoft.AspNetCore.Http;

namespace BlogManagement.Application.Contracts.Author;

public class EditAuthor : DefinitionAuthor
{
    public long Id { get; set; }
    public new IFormFile Picture { get; set; }
}