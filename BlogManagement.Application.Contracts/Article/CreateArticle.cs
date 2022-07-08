namespace BlogManagement.Application.Contracts.Article
{
    public class CreateArticle
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Picture { get; set; }
        public string PublishDate { get; set; }
        public int Studytime { get; set; }
        public string Slug { get;  set; }
        public string PictureAlt { get;  set; }
        public string PictureTitle { get;  set; }
        public string KeyWords { get;  set; }
        public string MetaDescription { get;  set; }
        public string ShortDescription { get;  set; }
        public string CanonicalAddress { get; set; }
        public long ArticleCategoryId { get; set; }
        public long AuthorId { get; set; }
    }
}
