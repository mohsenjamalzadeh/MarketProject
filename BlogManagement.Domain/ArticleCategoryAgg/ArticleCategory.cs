using _01_Framework.Domain;
using BlogManagement.Domain.ArticleAgg;

namespace BlogManagement.Domain.ArticleCategoryAgg
{
    public class ArticleCategory:EntityBase
    {
        public string? Name { get;private set; }
        public string? Picture { get;private set; }
        public string? PictureAlt { get;private set; }
        public string? PictureTitle { get;private set; }
        public string? Slug { get;private set; }
        public string? KeyWords { get;private set; }
        public string? Description { get;private set; }
        public string? MetaDescription { get;private set; }
        public bool IsActive { get;private set; }

        public ICollection<Article>? Articles { get;private set; }

        public ArticleCategory(string? name, string? picture,
            string? pictureAlt, string? pictureTitle, string? keyWords,
            string? description, string? metaDescription)
        {
            Name = name;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            KeyWords = keyWords;
            Description = description;
            MetaDescription = metaDescription;
            IsActive = true;
        }

        public void Edit(string? name, string? picture,
            string? pictureAlt, string? pictureTitle, string? keyWords,
            string? description, string? metaDescription)
        {
            Name = name;
            if(!string.IsNullOrWhiteSpace(picture))
                  Picture = picture;

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            KeyWords = keyWords;
            Description = description;
            MetaDescription = metaDescription;
        }

        public void Active()
        {
            IsActive = true;
        }

        public void InActive()
        {
            IsActive = false;
        }
    }
}
