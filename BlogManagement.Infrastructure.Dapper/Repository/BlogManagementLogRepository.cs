using BlogManagement.Application.Contracts.Log;
using BlogManagement.Domain.LogAgg;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BlogManagement.Infrastructure.Dapper.Repository
{
    public class BlogManagementLogRepository:IBlogManagementLogRepository
    {
        private string connectionString = "Data source=.;Initial catalog=MarketDb;Integrated security=true";

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

        public List<BlogManagementLogViewModel> GetAll(BlogManagementLogSearchModel searchModel)
        {
            var sql = "SELECT * FROM LogsBlogManagement";
            var connection = new SqlConnection(connectionString);
            var query = connection.Query<BlogManagementLogViewModel>(sql);

            if (!string.IsNullOrWhiteSpace(searchModel.MakerOperation))
                query = query.Where(p => p.MakerOperation == searchModel.MakerOperation);

            if (!string.IsNullOrWhiteSpace(searchModel.PlaceOperation))
                query = query.Where(p => p.PlaceOperation == searchModel.PlaceOperation);

            if (!string.IsNullOrWhiteSpace(searchModel.Reason))
                query = query.Where(p => p.Reason.Contains(searchModel.Reason));

            if (searchModel.IsSuccess==false)
                query = query.Where(p => p.IsSuccess==false);

            return query.OrderByDescending(p => p.CreationDate).ToList();
        }
    }
}
