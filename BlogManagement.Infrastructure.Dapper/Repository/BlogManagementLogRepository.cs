using BlogManagement.Domain.LogAgg;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BlogManagement.Infrastructure.Dapper.Repository
{
    public class BlogManagementLogRepository:IBlogManagementLogRepository
    {
        string connectionString = "";

        public void Log(LogBlogManagement logBlogManagement)
        {
            var sql = "INSERT INTO LogsBlogManagement (MakerOperation,PlaceOperation,Reason,IsSuccess,CreationDate) VALUES (@MakerOperation,@PlaceOperation,@Reason,@IsSuccess,@CreationDate) ";
            var connection = new SqlConnection(connectionString);
            connection.Execute(sql,
                new
                {
                    MakerOperation=logBlogManagement.MakerOperation,
                    PlaceOperation=logBlogManagement.PlaceOperation,
                    Reason=logBlogManagement.Reason,
                    IsSuccess=logBlogManagement.IsSuccess,
                    CreationDate=logBlogManagement.CreationDate
                });
        }

      

        
    }
}
