using _01_Framework.Domain;
using BlogManagement.Application.Contracts.Tag;

namespace BlogManagement.Domain.TagAgg
{
    public interface ITagRepository:IRepository<long,Tag>
    {
        List<TagViewModel> GetAll(TagSearchModel searchModel);
        EditTag GetDetails(long id);
    }


}
