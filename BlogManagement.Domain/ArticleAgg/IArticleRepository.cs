using _01_Framework.Domain;
using BlogManagement.Application.Contracts;
using BlogManagement.Application.Contracts.Article;

namespace BlogManagement.Domain.ArticleAgg
{
    public interface IArticleRepository : IRepository<long, Article>
    {
        EditArticle? GetDetails(long id);
        List<ArticleViewModel> GetAll(ArticleSearchModel searchModel);
    }
}
