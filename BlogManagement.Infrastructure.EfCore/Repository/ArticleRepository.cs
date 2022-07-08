using _01_Framework.Infrastructure;
using BlogManagement.Application.Contracts;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure.EfCore.Repository
{
    public class ArticleRepository : RepositoryBase<long, Article>, IArticleRepository
    {
        private readonly BlogContext _context;

        public ArticleRepository(BlogContext context) : base(context)
        {
            _context = context;
        }



        public EditArticle? GetDetails(long id)
        {
            var query = _context.Articles.AsNoTracking().Select(p => new EditArticle
            {
                Id = p.Id,
                Slug = p.Slug,
                Title = p.Title,
                Content = p.Content,
                Picture = p.Picture,
                AuthorId = p.AuthorId,
                KeyWords = p.KeyWords,
                Studytime = p.Studytime,
                PictureAlt = p.PictureAlt,
                PictureTitle = p.PictureTitle,
                MetaDescription = p.MetaDescription,
                ShortDescription = p.ShortDescription,
                CanonicalAddress = p.CanonicalAddress,
                PublishDate = p.PublishDate.ToString(),
                ArticleCategoryId = p.ArticleCategoryId,

            }).FirstOrDefault(p => p.Id == id);

            return query;
        }

        public List<ArticleViewModel> GetAll(ArticleSearchModel searchModel)
        {
            var query = _context.Articles
                .Include(p => p.Author)
                .Include(p => p.ArticleCategory)
                .Select(p => new ArticleViewModel
                {
                    Id = p.Id,
                    Slug = p.Slug,
                    Title = p.Title,
                    NumView = p.NumView,
                    NumVote = p.NumVote,
                    Picture = p.Picture,
                    AuthorId = p.AuthorId,
                    IsActive = p.IsActive,
                    Studytime = p.Studytime,
                    Author = p.Author.Name,
                    ShortDescription = p.ShortDescription,
                    CanonicalAddress = p.CanonicalAddress,
                    PublishDate = p.PublishDate.ToString(),
                    ArticleCategoryId = p.ArticleCategoryId,
                    ArticleCategory = p.ArticleCategory.Name,
                    CreationDate = p.CreationDate.ToShortDateString()


                }).AsNoTracking();


            if (!string.IsNullOrWhiteSpace(searchModel.Title))
                query = query.Where(p => p.Title == searchModel.Title);


            if (!string.IsNullOrWhiteSpace(searchModel.PublishDate))
                query = query.Where(p => p.CreationDate == searchModel.PublishDate);

            if (searchModel.IsActive == false)
                query = query.Where(p => p.IsActive == searchModel.IsActive);

            if (searchModel.ArticleCategory > 0)
                query = query.Where(p => p.ArticleCategoryId == searchModel.ArticleCategory);

            if (searchModel.AuthorId > 0)
                query = query.Where(p => p.AuthorId == searchModel.AuthorId);

            return query.OrderByDescending(p => p.Id).ToList();
        }
    }
}
