using BlogManagement.Application.Contracts.Log;
using BlogManagement.Domain.LogAgg;

namespace BlogManagement.Application
{
    public class BlogManagementLogApplication:IBlogManagementLogApplication
    {
        private readonly IBlogManagementLogRepository _blogManagementLog;

        public BlogManagementLogApplication(IBlogManagementLogRepository blogManagementLog)
        {
            _blogManagementLog = blogManagementLog;
        }

        public List<BlogManagementLogViewModel> GetAll(BlogManagementLogSearchModel searchModel)
        {
            return _blogManagementLog.GetAll(searchModel);
        }
    }
}
