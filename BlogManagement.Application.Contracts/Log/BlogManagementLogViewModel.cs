namespace BlogManagement.Application.Contracts.Log;

public class BlogManagementLogViewModel
{
    public long Id { get; set; }
    public string? MakerOperation { get; set; }
    public string? PlaceOperation { get; set; }
    public string? Reason { get; set; }
    public bool? IsSuccess { get; set; }

}