using _01_Framework.Application;

namespace BlogManagement.Application.Contracts.Tag
{
    public interface  ITagApplication
    {
        OperationResult CreateTag(CreateTag command);
        OperationResult EditTag(EditTag command);
        List<TagViewModel> GetAll(TagSearchModel searchModel);
        EditTag GetDetails(long id);
        OperationResult Active(long id);
        OperationResult InActive(long id);
    }
}
