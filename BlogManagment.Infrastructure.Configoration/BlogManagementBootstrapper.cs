using BlogManagement.Application;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Application.Contracts.Author;
using BlogManagement.Application.Contracts.Log;
using BlogManagement.Application.Contracts.Tag;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;
using BlogManagement.Domain.AuthorAgg;
using BlogManagement.Domain.LogAgg;
using BlogManagement.Domain.TagAgg;
using BlogManagement.Infrastructure.Dapper.Repository;
using BlogManagement.Infrastructure.EfCore;
using BlogManagement.Infrastructure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlogManagement.Infrastructure.Configuration
{
    public static class BlogManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IBlogManagementLogRepository, BlogManagementLogRepository>();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<ITagRepository, TagRepository>();

            services.AddTransient<IBlogManagementLogApplication, BlogManagementLogApplication>();
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            services.AddTransient<IArticleApplication, ArticleApplication>();
            services.AddTransient<IAuthorApplication, AuthorApplication>();
            services.AddTransient<ITagApplication, TagApplication>();


            services.AddDbContext<BlogContext>(p => p.UseSqlServer(connectionString));
        }
    }
}