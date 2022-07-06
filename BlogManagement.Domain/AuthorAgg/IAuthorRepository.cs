using _01_Framework.Domain;
using BlogManagement.Application.Contracts.Author;

namespace BlogManagement.Domain.AuthorAgg
{
    public interface  IAuthorRepository:IRepository<long,Author>
    {
        List<AuthorViewModel> GetAll(AuthorSearchModel searchModel);
        EditAuthor GetDetails(long id);
    }
}
