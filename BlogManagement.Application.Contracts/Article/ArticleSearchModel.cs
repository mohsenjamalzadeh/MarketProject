namespace BlogManagement.Application.Contracts.Article;

public class ArticleSearchModel
{
    public string? Title { get; set; }
    public string? PublishDate { get; set; }
    public int? ArticleCategory { get; set; }
    public long? AuthorId { get; set; }
    public bool IsActive { get; set; }
}