using _01_Framework.Infrastructure;
using BlogManagement.Application.Contracts.Tag;
using BlogManagement.Domain.TagAgg;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure.EfCore.Repository
{
    public class TagRepository : RepositoryBase<long, Tag>, ITagRepository
    {
        private readonly BlogContext _context;
        public TagRepository(BlogContext context) : base(context)
        {
            _context = context;
        }

        public List<TagViewModel> GetAll(TagSearchModel searchModel)
        {
            throw new NotImplementedException();
        }

        public EditTag? GetDetails(long id)
        {
            var query = _context.Tags.AsNoTracking().Select(p => new EditTag
            {
                Name = p.Name,
                Id = p.Id
            }).FirstOrDefault(p => p.Id == id);

            return query;
        }
    }
}
