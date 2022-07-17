using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Blog.ArticleCategory
{
    public class IndexModel : PageModel
    {
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public List<ArticleCategoryViewModel> ArticleCategories { get; set; }
        public ArticleCategorySearchModel SearchModel { get; set; }


        public IndexModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(ArticleCategorySearchModel searchModel)
        {
        
            ArticleCategories = _articleCategoryApplication.GetAll(searchModel);
        }
    }
}
