using _01_Framework.Application;

namespace BlogManagement.Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        OperationResult CreateArticleCategory(CreateArticleCategory command);
        OperationResult EditArticleCategory(EditArticleCategory command);
        List<ArticleCategoryViewModel> GetAll(ArticleCategorySearchModel searchModel);
        EditArticleCategory? GetDetails(long id);
        OperationResult Active(long id);
        OperationResult InActive(long id);


    }
}
