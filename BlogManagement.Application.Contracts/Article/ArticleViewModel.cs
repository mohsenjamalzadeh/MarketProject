namespace BlogManagement.Application.Contracts;

public class ArticleViewModel
{
    public long Id { get; set; }
    public string? Title { get; set; }
    public string? Picture { get; set; }
    public string? PublishDate { get; set; }
    public int Studytime { get; set; }
    public string? Slug { get;  set; }
    public int NumVote { get; set; }
    public int NumView { get; set; }
    public string? ShortDescription { get;  set; }
    public string? CanonicalAddress { get; set; }
    public long ArticleCategoryId { get; set; }
    public string? ArticleCategory { get; set; }
    public long AuthorId { get; set; }
    public string? Author { get; set; }
}