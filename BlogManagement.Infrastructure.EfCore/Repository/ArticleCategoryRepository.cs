using _01_Framework.Infrastructure;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure.EfCore.Repository
{
    public class ArticleCategoryRepository:RepositoryBase<long,ArticleCategory>,IArticleCategoryRepository
    {
        private readonly BlogContext _context;
        public ArticleCategoryRepository(BlogContext context) : base(context)
        {
            _context = context;
        }

        public List<ArticleCategoryViewModel> GetAll(ArticleCategorySearchModel searchModel)
        {
            var query = _context.ArticleCategories.Select(p => new ArticleCategoryViewModel
            {
                Name = p.Name,
                Description = p.Description,
                Picture = p.Picture,
                Id = p.Id,
                IsActive = p.IsActive,
                CreationDate = p.CreationDate.ToShortDateString()
            }).AsNoTracking();

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(p => p.Name == searchModel.Name);
            if(searchModel.InActive==false)
                query=query.Where(p => !p.IsActive);

            return query.OrderByDescending(p => p.Id).ToList();
        }

        public EditArticleCategory? GetDetails(long id)
        {
            var query = _context.ArticleCategories.Select(p => new EditArticleCategory
            {
               Name = p.Name,
               Description = p.Description,
               Picture = p.Picture,
               PictureAlt = p.PictureAlt,
               PictureTitle=p.PictureTitle,
               MetaDescription = p.MetaDescription,
               KeyWords = p.KeyWords,
               Slug = p.Slug,
               Id = p.Id,

            }).FirstOrDefault(p => p.Id == id);

            return query;
        }
    }
}
