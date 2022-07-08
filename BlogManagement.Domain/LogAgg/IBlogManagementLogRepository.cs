using _01_Framework.Domain;

namespace BlogManagement.Domain.LogAgg
{
    public interface IBlogManagementLogRepository
    {
        void Log(LogBlogManagement logBlogManagement);
    }
}
