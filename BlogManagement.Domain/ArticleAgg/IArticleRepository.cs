using _01_Framework.Domain;
using BlogManagement.Application.Contracts;

namespace BlogManagement.Domain.ArticleAgg
{
    public interface IArticleRepository : IRepository<long, Article>
    {
        EditArticle? GetDetails(long id);
        List<ArticleViewModel> GetAll(ArticleSearchModel searchModel);
    }
}
