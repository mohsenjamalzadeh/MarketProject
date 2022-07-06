namespace BlogManagement.Application.Contracts.Log;

public class BlogManagementLogSearchModel
{
    public string? MakerOperation { get; set; }
    public string? PlaceOperation { get; set; }
    public string? Reason { get; set; }
    public bool? IsSuccess { get; set; }

}