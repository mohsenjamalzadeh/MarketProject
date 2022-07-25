using _01_Framework.Application;
using Microsoft.AspNetCore.Http;

namespace BlogManagement.Application.Contracts.ArticleCategory;

public class EditArticleCategory:CreateArticleCategory
{
    public long Id { get; set; }

    [FileExtension(new string[] {"jpeg","jpg","png"})]
    [MaxFileSize( 3 * 1024 * 1024)]
    public new IFormFile? Picture { get; set; }
}