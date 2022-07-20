using _01_Framework.Domain;
using BlogManagement.Application.Contracts.Log;

namespace BlogManagement.Domain.LogAgg
{
    public interface IBlogManagementLogRepository
    {
        void Log(LogBlogManagement logBlogManagement);
        List<BlogManagementLogViewModel> GetAll();

    }
}
