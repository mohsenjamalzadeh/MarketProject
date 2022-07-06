using _01_Framework.Domain;
using BlogManagement.Domain.ArticleCategoryAgg;
using BlogManagement.Domain.AuthorAgg;
using BlogManagement.Domain.TagAgg;

namespace BlogManagement.Domain.ArticleAgg
{
    public class Article:EntityBase
    {
        public string? Title { get;private set; }
        public string? Content { get;private set; }
        public string? Picture { get;private set; }
        public DateTime? PublishDate { get;private set; }
        public int NumView { get;private set; }
        public int NumVote{ get;private set; }
        public bool IsActive { get;private set; }
        public int Studytime { get;private set; }
        public string? Slug { get; private set; }
        public string? PictureAlt { get; private set; }
        public string? PictureTitle { get; private set; }
        public string? KeyWords { get; private set; }
        public string? MetaDescription { get; private set; }
        public string? ShortDescription { get; private set; }
        public string? CanonicalAddress { get;private set; }
        public long ArticleCategoryId { get;private set; }
        public long AuthorId { get;private set; }

        public ICollection<Tag> Tags { get;private set; }
        public ArticleCategory ArticleCategory { get;private set; }
        public Author Author { get;private set; }


        public Article(string? title, string? content, string? picture,
            DateTime? publishDate, int studytime, string? slug, string? pictureAlt,
            string? pictureTitle, string? keyWords, string? metaDescription, string? canonicalAddress,long articleCategoryId,long authorId,string shortDescription)
        {
            Title = title;
            Content = content;
            Picture = picture;
            PublishDate = publishDate;
            Studytime = studytime;
            Slug = slug;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            IsActive = true;
            ArticleCategoryId = articleCategoryId;
            AuthorId=authorId;
            ShortDescription= shortDescription;
            NumView = 0;
            NumVote = 0;
        }

        public void Edit(string? title, string? content, string? picture,
            DateTime? publishDate, int studytime, string? slug, string? pictureAlt,
            string? pictureTitle, string? keyWords, string? metaDescription, string? canonicalAddress,
            long articleCategoryId,long authorId,string shortDescription)
        {
            Title = title;
            Content = content;
            if(!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            PublishDate = publishDate;
            Studytime = studytime;
            Slug = slug;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            ArticleCategoryId = articleCategoryId;
            AuthorId = authorId;
            ShortDescription= shortDescription;
        }

        public void Active()
        {
            IsActive = true;
        }

        public void InActive()
        {
            IsActive = false;
        }

        public void AddView()
        {
            NumView = NumView + 1;
        }

        public void AddVote()
        {
            NumVote = NumVote
                      + 1;
        }
       
    }
}
