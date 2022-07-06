using _01_Framework.Domain;
using BlogManagement.Domain.ArticleAgg;

namespace BlogManagement.Domain.AuthorAgg
{
    public class Author:EntityBase
    {
        public string? Name { get;private set; }
        public string? Picture { get;private set; }
        public string? PictureAlt { get;private set; }
        public string? PictureTitle { get;private set; }
        public string? Description { get;private set; }
        

        public ICollection<Article>? Articles { get;private set; }

        public Author(string? name, string? picture, string? pictureAlt, string? pictureTitle, string? description)
        {
            Name = name;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Description = description;
        }

        public void Edit(string? name, string? picture, string? pictureAlt, string? pictureTitle, string? description)
        {
            Name = name;
            if(!string.IsNullOrWhiteSpace(picture))
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Description = description;
        }

    }
}
