using System.Security.AccessControl;
using _01_Framework.Infrastructure;
using BlogManagement.Domain.LogAgg;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure.EfCore.Repository
{
    public class BlogManagementLogRepository:RepositoryBase<long,LogBlogManagement>,IBlogManagementLogRepository
    {
        private readonly BlogContext _context;
        public BlogManagementLogRepository(BlogContext context) : base(context)
        {
            _context = context; 
        }
    }
}
