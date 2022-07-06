using System.Security.AccessControl;

namespace BlogManagement.Application.Contracts.Author
{
    public class DefinitionAuthor
    {
        public string? Name { get; set; }
        public string? Picture { get; set; }
        public string? PictureAlt { get; set; }
        public string? PictureTitle { get; set; }
        public string? Description { get; set; }

    }
}
