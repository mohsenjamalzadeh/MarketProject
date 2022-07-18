namespace BlogManagement.Application.Contracts.Log
{
    public interface IBlogManagementLogApplication
    {
        List<BlogManagementLogViewModel> GetAll(BlogManagementLogSearchModel searchModel);
    }
}
