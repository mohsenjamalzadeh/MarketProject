using BlogManagement.Application.Contracts.Article;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Blog.Articles
{
    
    
    public class IndexModel : PageModel
    {
        private readonly IArticleApplication _articleApplication;
        public List<ArticleViewModel> Articles { get; set; }
        public ArticleSearchModel SearchModel { get; set; }

        public IndexModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }

        public void OnGet(ArticleSearchModel searchModel)
        {
            Articles = _articleApplication.GetAll(searchModel);
        }
    }
}
