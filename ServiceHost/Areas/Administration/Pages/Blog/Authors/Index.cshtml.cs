using BlogManagement.Application.Contracts.Author;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Blog.Authors
{
    public class IndexModel : PageModel
    {
        private readonly IAuthorApplication _authorApplication;
        public List<AuthorViewModel> Authors { get; set; }
        public AuthorSearchModel SearchModel { get; set; }

        public IndexModel(IAuthorApplication authorApplication)
        {
            _authorApplication = authorApplication;
        }

        public void OnGet(AuthorSearchModel searchModel)
        {
            Authors = _authorApplication.GetAll(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("Create", new DefinitionAuthor());
        }

        public async Task<JsonResult> OnPostCreate(DefinitionAuthor command)
        {
            var result =await _authorApplication.DefineAuthor(command);
            
            return new JsonResult(result);

        }

        public IActionResult OnGetEdit(long id)
        {
            var author = _authorApplication.GetDetails(id);
            return Partial("Edit", author);
        }

        public async Task<IActionResult> OnPostEdit(EditAuthor command)
        {
            var result =await _authorApplication.EditAuthor(command);
            return new JsonResult(result);
        }
    }
}
