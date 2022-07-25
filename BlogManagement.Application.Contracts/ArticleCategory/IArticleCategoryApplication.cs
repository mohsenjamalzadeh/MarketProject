using _01_Framework.Application;

namespace BlogManagement.Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        Task<OperationResult> CreateArticleCategory(CreateArticleCategory command);
        Task<OperationResult> EditArticleCategory(EditArticleCategory command);
        List<ArticleCategoryViewModel> GetAll(ArticleCategorySearchModel searchModel);
        EditArticleCategory? GetDetails(long id);
        OperationResult Active(long id);
        OperationResult InActive(long id);


    }
}
