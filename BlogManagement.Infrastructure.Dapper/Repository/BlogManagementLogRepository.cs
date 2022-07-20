using BlogManagement.Application.Contracts.Log;
using BlogManagement.Domain.LogAgg;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BlogManagement.Infrastructure.Dapper.Repository
{
    public class BlogManagementLogRepository:IBlogManagementLogRepository
    {
    

        private string connectionString = "Data source=.;Initial catalog=MarketDb;Integrated security=true" ;

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

        public List<BlogManagementLogViewModel> GetAll()
        {
            var sql = "SELECT * FROM LogsBlogManagement";
            var connection = new SqlConnection(connectionString);
            var query = connection.Query<BlogManagementLogViewModel>(sql);
            return query.OrderByDescending(p => p.CreationDate).ToList();
        }
    }
}
