using _01_Framework.Application;

namespace BlogManagement.Application.Contracts.Author
{
    public  interface  IAuthorApplication
    {
        Task<OperationResult> DefineAuthor(DefinitionAuthor command);
        Task<OperationResult> EditAuthor(EditAuthor command);
        List<AuthorViewModel> GetAll(AuthorSearchModel searchModel);
        EditAuthor GetDetails(long id);
    }
}
