using _01_Framework.Domain;
using BlogManagement.Application.Contracts.ArticleCategory;

namespace BlogManagement.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository:IRepository<long,ArticleCategory>
    {
        List<ArticleCategoryViewModel> GetAll(ArticleCategorySearchModel searchModel);
        EditArticleCategory GetDetails(long id);
    }
}
