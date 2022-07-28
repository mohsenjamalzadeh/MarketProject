using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult OnGetCreate()
        {

            return Partial("Create",new CreateArticleCategory());
        }

        public async Task<JsonResult> OnPostCreate(CreateArticleCategory command)
        {
         
            var res =await _articleCategoryApplication.CreateArticleCategory(command);
            return new JsonResult(res);
        }

        public IActionResult OnGetEdit(long id)
        {
            var command = _articleCategoryApplication.GetDetails(id);
            return Partial("Edit",command);
        }

        public async Task<JsonResult> OnPostEdit(EditArticleCategory command)
        {
            var res =await _articleCategoryApplication.EditArticleCategory(command);
            return new JsonResult(res);
        }

        public IActionResult OnGetActive(long id)
        {
            _articleCategoryApplication.Active(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetInActive(long id)
        {
            _articleCategoryApplication.InActive(id);
            return RedirectToPage("./Index");
        }
    }
}
