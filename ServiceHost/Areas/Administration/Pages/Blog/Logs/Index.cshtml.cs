using System.Threading;
using BlogManagement.Application.Contracts.Log;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Blog.Logs
{
    public class IndexModel : PageModel
    {

        public List<BlogManagementLogViewModel> BlogManagementLogs { get; set; }
        
        public void OnGet()
        {

        }


        public IActionResult OnGetLogsBlog([FromHeader]int pageNumber,[FromHeader] int pageSize, [FromServices] IBlogManagementLogApplication blogManagementLog)
          
        {
            BlogManagementLogs = blogManagementLog.GetAll();
            pageNumber = pageNumber - 1;
            var logs = BlogManagementLogs.Skip(pageNumber * pageSize).Take(pageSize).ToList();
            return new JsonResult(logs);


        }
    }
}
