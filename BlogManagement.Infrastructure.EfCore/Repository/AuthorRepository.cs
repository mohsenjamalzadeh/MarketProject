using _01_Framework.Infrastructure;
using BlogManagement.Application.Contracts.Author;
using BlogManagement.Domain.AuthorAgg;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure.EfCore.Repository
{
    public class AuthorRepository : RepositoryBase<long, Author>, IAuthorRepository
    {
        private readonly BlogContext _context;
        public AuthorRepository(BlogContext context) : base(context)
        {
            _context = context;
        }

        public List<AuthorViewModel> GetAll(AuthorSearchModel searchModel)
        {
            var query = _context.Authors.Select(p => new AuthorViewModel
            {

                Id = p.Id,
                Name = p.Name,
                Picture = p.Picture,
                Description = p.Description,
                CreationDate = p.CreationDate.ToShortDateString()
            }).AsNoTracking();

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(p => p.Name == searchModel.Name);

            return query.OrderByDescending(p => p.Id).ToList();
        }

        public EditAuthor? GetDetails(long id)
        {
            var query = _context.Authors.AsNoTracking().Select(p => new EditAuthor
            {
                Id = p.Id,
                Name = p.Name,
                //Picture = p.Picture,
                PictureAlt = p.PictureAlt,
                Description = p.Description,
                PictureTitle = p.PictureTitle,

            }).FirstOrDefault(p => p.Id == id);

            return query;
        }
    }
}
