using _01_Framework.Application;

namespace BlogManagement.Application.Contracts.Author
{
    public  interface  IAuthorApplication
    {
        OperationResult DefineAuthor(DefinitionAuthor command);
        OperationResult EditAuthor(EditAuthor command);
        List<AuthorViewModel> GetAll(AuthorSearchModel searchModel);
        EditAuthor GetDetails(long id);
    }
}
