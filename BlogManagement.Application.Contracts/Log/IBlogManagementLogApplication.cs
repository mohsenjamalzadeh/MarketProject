namespace BlogManagement.Application.Contracts.Log
{
    public interface IBlogManagementLogApplication
    {
        void CreateBlogManagementLog(CreateBlogManagementLog command);
        List<BlogManagementLogViewModel> GetAll(BlogManagementLogSearchModel searchModel);
    }
}
