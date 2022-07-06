using System.Security.AccessControl;

namespace BlogManagement.Application.Contracts.Tag;

public class TagViewModel
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public bool? IsActive { get; set; }
    

}